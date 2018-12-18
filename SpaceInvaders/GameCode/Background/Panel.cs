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
            int moveSpeed = 1;
            for (int i = 0; i < 100; i++)
            {
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    destRect.X -= moveSpeed;
                    if (destRect.X + destRect.Width <= 0)
                    {
                        destRect.X = destRect.Width;
                    }

                }
                else if (keyboard.IsKeyDown(Keys.Left))
                {
                    destRect.X += moveSpeed;
                    if (destRect.X >= Constants.ScreenWidth)
                    {
                        destRect.X = -destRect.Width;
                    }
                }
                if (keyboard.IsKeyDown(Keys.Up))
                {
                    destRect.Y += moveSpeed;
                    if (destRect.Y >= Constants.ScreenHeight)
                    {
                        destRect.Y = -destRect.Height;
                    }
                }
                else if (keyboard.IsKeyDown(Keys.Down))
                {
                    destRect.Y -= moveSpeed;
                    if (destRect.Y + destRect.Height <= 0)
                    {
                        destRect.Y = destRect.Height;
                    }
                }
            }

        }
    }
}