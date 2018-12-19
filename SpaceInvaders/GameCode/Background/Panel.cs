using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.GameCode.Characters;
using System;

namespace SpaceInvaders.GameCode.Background
{
    internal class Panel : Sprite, IGameInterface
    {
        private float secondsPassed, secondsLetGo;
        private float moveSpeed;
        private readonly float maxAccelerationTime = 2.5f;
        private readonly float accelerationSpeed = 3;
        private readonly float deaccelerationSpeed = -0.3f;
        public Panel(string fileName) : base(fileName, 0)
        {
            acceleration = accelerationSpeed;
            secondsPassed = 0;
            secondsLetGo = 0; 
            velocity = 0;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, object player)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if(secondsPassed >= maxAccelerationTime)
            {
                acceleration = 0;
                //Terminal Velocity
                velocity = moveSpeed;
            }
            var Player = (Player)(player);
            if (UpDown(keyboard))
            {
                moveSpeed = velocity + (acceleration * secondsPassed);
  
                secondsPassed += elapsedTime;
                secondsLetGo = 0;
                if(secondsPassed < maxAccelerationTime)
                {
                    acceleration = accelerationSpeed;
                }
            }
            else
            {
                secondsPassed = 0;
                secondsLetGo += elapsedTime;
                if (moveSpeed > 1)
                {
                    acceleration = deaccelerationSpeed;
                    velocity = moveSpeed;
                }
                else
                {
                    acceleration = 0;
                    velocity = 0;
                }
                moveSpeed = velocity + (acceleration * secondsLetGo);
            }
            if((int)moveSpeed == 0)
            {
                moveSpeed = 0.3f;
            }
            MoveEntity(moveSpeed, Player.Rotation, Player.RotationOffset);
            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //https://www.david-gouveia.com/scrolling-textures-in-xna
            spriteBatch.Draw(sprite, Vector2.Zero, destRect, Color.White);

            //http://www.david-amador.com/2010/04/making-big-grass-tiles-in-xna/
        }

        public void LoadContent(ContentManager content)
        {
            LoadSprite(content);
            destRect = new Rectangle(0, 0, Constants.ScreenWidth, Constants.ScreenHeight);
            position = new Vector2(destRect.X, destRect.Y);
        }
    }
}