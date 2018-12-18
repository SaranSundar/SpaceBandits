using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace SpaceInvaders.GameCode.Background
{
    internal class BackgroundRenderer : IGameInterface
    {
        private Texture2D purpleSpaceTexture;
        private Texture2D darkPurpleSpaceTexture;
        private Texture2D blueSpaceTexture;
        private Texture2D blackSpaceTexture;

        private Rectangle sourceRect;
        private Rectangle destRect;
        private ArrayList panels;


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           foreach(Panel panel in panels)
           {
                panel.Draw(gameTime, spriteBatch);
           }
        }

        public void LoadContent(ContentManager content)
        {
            purpleSpaceTexture = content.Load<Texture2D>("purple");
            darkPurpleSpaceTexture = content.Load<Texture2D>("darkPurple");
            blueSpaceTexture = content.Load<Texture2D>("blue");
            blackSpaceTexture = content.Load<Texture2D>("black");
            panels = new ArrayList();
            for (int i = -1; i < 2; i++)
            {
                // Left Middle Right
                int panelWidth = Constants.ScreenWidth;
                int panelHeight = Constants.ScreenHeight;
                sourceRect = new Rectangle(0, 0, purpleSpaceTexture.Width, purpleSpaceTexture.Height);
                destRect = new Rectangle((i*panelWidth), 0, panelWidth, panelHeight);
                Panel panel = new Panel(purpleSpaceTexture, sourceRect, destRect);
                panel.LoadContent(content);
                panels.Add(panel);
            }
            for (int i = -1; i < 2; i++)
            {
                // Left Middle Right
                int panelWidth = Constants.ScreenWidth;
                int panelHeight = Constants.ScreenHeight;
                sourceRect = new Rectangle(0, 0, purpleSpaceTexture.Width, purpleSpaceTexture.Height);
                destRect = new Rectangle((i * panelWidth), -panelHeight, panelWidth, panelHeight);
                Panel panel = new Panel(purpleSpaceTexture, sourceRect, destRect);
                panel.LoadContent(content);
                panels.Add(panel);
            }
            for (int i = -1; i < 2; i++)
            {
                // Left Middle Right
                int panelWidth = Constants.ScreenWidth;
                int panelHeight = Constants.ScreenHeight;
                sourceRect = new Rectangle(0, 0, purpleSpaceTexture.Width, purpleSpaceTexture.Height);
                destRect = new Rectangle((i * panelWidth), panelHeight, panelWidth, panelHeight);
                Panel panel = new Panel(purpleSpaceTexture, sourceRect, destRect);
                panel.LoadContent(content);
                panels.Add(panel);
            }
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            foreach (Panel panel in panels)
            {
                panel.Update(gameTime, keyboard);
            }
        }
    }
}