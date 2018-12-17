using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.GameCode.Background
{
    internal class BackgroundRenderer : IGameInterface
    {
        private Texture2D _purpleSpaceTexture;
        private Texture2D darkPurpleSpaceTexture;
        private Texture2D blueSpaceTexture;
        private Texture2D blackSpaceTexture;

        private Rectangle _sourceRect;
        private Rectangle _destRect;
        private Panel _panel;
        int _screenWidth, _screenHeight;


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _panel.Draw(gameTime, spriteBatch);
        }

        public void Initialize(int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
        }

        public void LoadContent(ContentManager content)
        {
            _purpleSpaceTexture = content.Load<Texture2D>("purple");
            darkPurpleSpaceTexture = content.Load<Texture2D>("darkPurple");
            blueSpaceTexture = content.Load<Texture2D>("blue");
            blackSpaceTexture = content.Load<Texture2D>("black");

            _sourceRect = new Rectangle(0, 0, _purpleSpaceTexture.Width, _purpleSpaceTexture.Height);
            _destRect = new Rectangle(0, 0, _screenWidth, _screenHeight);
            _panel = new Panel(_purpleSpaceTexture, _sourceRect, _destRect);
            _panel.Initialize(_screenWidth, _screenHeight);
            _panel.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            _panel.Update(gameTime);
        }
    }
}