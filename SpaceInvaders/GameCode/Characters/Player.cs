using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameCode.Characters
{
    internal class Player : Sprite, IGameInterface
    {

        public Player(string fileName, float rotationOffset) : base(fileName, rotationOffset)
        {
            acceleration = 20f;
            maxSpeed = 12f;
            friction = 0.983f;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //DrawSprite(spriteBatch); // For some reason moves a little as it draws
            spriteBatch.Draw(sprite, // Texture
                drawPosition,      // Position
                sourceRect,    // Source rectangle
                Color.White,   // Color
                rotation,      // Rotation
                originVector,   // Origin
                scaleVector,       // Scale
                SpriteEffects.None,  // Mirroring effect
                layerDepth);       // Depth
        }

        public void LoadContent(ContentManager content)
        {
            LoadSprite(content);
            SetDest(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2, sprite.Width, sprite.Height);
            drawPosition = new Vector2(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2);
            position = new Vector2(-500, -500);
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
        }

        public Vector2 DrawTranslation
        {
            get
            {
                return drawTranslation;
            }
        }

        public float RotationOffset
        {
            get
            {
                return rotationOffset;
            }
        }


        public void Update(GameTime gameTime, KeyboardState keyboard, object none)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)moveAmount * elapsedTime;
            drawTranslation = drawPosition - position;
            if (RightDown(keyboard))
            {
                rotation += rotationSpeed;
            }
            else if (LeftDown(keyboard))
            {
                rotation -= rotationSpeed;
            }
            UpdateDirection(Rotation, RotationOffset, keyboard);
            velocity += acceleration * direction * elapsedTime;
            if (velocity.LengthSquared() > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            position += velocity;
            velocity *= friction;
            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;
        }
    }
}
