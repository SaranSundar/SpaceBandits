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
        public Panel(string fileName) : base(fileName, 0)
        {
            acceleration = 0.7f;
            maxSpeed = 12f;
            friction = 0.983f;
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, object player)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Player Player = (Player)player;
            UpdateDirection(Player.Rotation, Player.RotationOffset, keyboard);
            velocity += acceleration * direction;
            if(velocity.LengthSquared() > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            position += velocity;
            velocity *= friction;
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