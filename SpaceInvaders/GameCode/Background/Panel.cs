using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders.GameCode.Background
{
    internal class Panel : IGameInterface
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

        public void Initialize(int screenWidth, int screenHeight)
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            
        }
    }
}