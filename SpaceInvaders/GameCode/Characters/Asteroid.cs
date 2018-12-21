using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.GameCode.Animation;

namespace SpaceInvaders.GameCode.Characters
{
    internal class Asteroid : Sprite, IGameInterface
    {
        public Asteroid(string fileName, float rotationOffset) : base(fileName, rotationOffset)
        {
            acceleration = 1f;
            maxSpeed = 12f;
            mass = 0.50f;
            friction = 0.983f;
            direction.X = (float)Math.Cos(rotation - rotationOffset);
            direction.Y = (float)Math.Sin(rotation - rotationOffset);
            direction.Normalize();
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, object player)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)moveAmount * elapsedTime;
            velocity += acceleration * direction * elapsedTime;
            if (velocity.LengthSquared() > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            position += velocity;
            velocity *= friction;
            Player Player = (Player)player;
            if (Player.DestRect.Intersects(destRect))
            {
                Vector2 playerVelocity = Player.VelocityVector;
                Vector2 asteroidVelocity = velocity;
                float playerMass = Player.Mass;
                float asteroidMass = mass;
                playerVelocity = (playerMass - asteroidMass) * playerVelocity / (playerMass + asteroidMass);
                asteroidVelocity = 2 * playerMass * playerVelocity / (playerMass + asteroidMass);
                velocity = asteroidVelocity;
                Player.VelocityVector = playerVelocity;
                float playerAngle = Player.Rotation;
                float playerAngleOffset = Player.RotationOffset;
                direction.X = (float)Math.Cos(playerAngle - playerAngleOffset);
                direction.Y = (float)Math.Sin(playerAngle - playerAngleOffset);
                direction.Normalize();
            }
            TranslatePosition(player);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //DrawSprite(spriteBatch); // For some reason moves a little as it draws
            spriteBatch.Draw(sprite, // Texture
            drawTranslation + position,      // Position
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
            SetDest(0, -500, sprite.Width, sprite.Height);
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
        }

        public Vector2 OriginVector
        {
            get
            {
                return originVector;
            }
        }

        public int Height
        {
            get
            {
                return destRect.Height;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
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

    }
}
