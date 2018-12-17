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
            if (keyboard.IsKeyDown(Keys.Right))
            {
                destRect.X += 5;
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                destRect.X -= 5;
            }
        }
    }
}