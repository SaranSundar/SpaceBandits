using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameCode.Background
{
    internal class Panel : BaseObject, IGameInterface
    {
        private Texture2D backgroundTexture;
        private Rectangle sourceRect, destRect;

        public Panel(Texture2D backgroundTexture, Rectangle sourceRect, Rectangle destRect)
        {
            this.backgroundTexture = backgroundTexture;
            this.sourceRect = sourceRect;
            this.destRect = destRect;
            position = new Vector2(destRect.X, destRect.Y);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, destRect, sourceRect, Color.White);
        }

        public void LoadContent(ContentManager content)
        {

        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            float elpasedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)250;// * elpasedTime;

            if (keyboard.IsKeyDown(Keys.Right))
            {
                position.X -= moveSpeed;
                if (position.X + destRect.Width <= 0)
                {
                    position.X = destRect.Width;
                }

            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                position.X += moveSpeed;
                if (position.X >= Constants.ScreenWidth)
                {
                    position.X = -destRect.Width;
                }
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                position.Y += moveSpeed;
                if (position.Y >= Constants.ScreenHeight)
                {
                    position.Y = -destRect.Height;
                }
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                position.Y -= moveSpeed;
                if (position.Y + destRect.Height <= 0)
                {
                    position.Y = destRect.Height;
                }
            }

            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;

        }
    }
}