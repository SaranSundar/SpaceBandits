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

        public Panel(Texture2D backgroundTexture)
        {
            this.backgroundTexture = backgroundTexture;
            sourceRect = new Rectangle(0, 0, backgroundTexture.Width, backgroundTexture.Height);
            destRect = new Rectangle(0, 0, Constants.ScreenWidth, Constants.ScreenHeight);
            position = new Vector2(destRect.X, destRect.Y);
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            float elpasedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)1000 * elpasedTime;

            if (keyboard.IsKeyDown(Keys.Right))
            {
                position.X += moveSpeed;
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                position.X -= moveSpeed;
            }
            if (keyboard.IsKeyDown(Keys.Up))
            {
                position.Y -= moveSpeed;

            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                position.Y += moveSpeed;
            }

            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //https://www.david-gouveia.com/scrolling-textures-in-xna
            spriteBatch.Draw(backgroundTexture, Vector2.Zero, destRect, Color.White);

            //http://www.david-amador.com/2010/04/making-big-grass-tiles-in-xna/
        }

        public void LoadContent(ContentManager content)
        {

        }
    }
}