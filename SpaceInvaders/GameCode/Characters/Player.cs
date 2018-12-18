using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameCode.Characters
{
    internal class Player : Sprite, IGameInterface
    {
        public Player(string fileName, float rotationOffset) : base(fileName, rotationOffset){}

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            DrawSprite(spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            LoadSprite(content);
            SetDest(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2, sprite.Width, sprite.Height);

        }

        public float Rotation
        {
            get
            {
                return rotation;
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
            float elpasedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)moveAmount * elpasedTime;

            if (RightDown(keyboard))
            {
                rotation += rotationSpeed;
            }
            else if (LeftDown(keyboard))
            {
                rotation -= rotationSpeed;
            }
            if (UpDown(keyboard))
            {
                //accelerate here
                //MoveEntity(moveSpeed, rotation);

            }
            else if (DownDown(keyboard))
            {
                //decccelerate here
                //MoveEntity(-moveSpeed, rotation);
            }
        }
    }
}
