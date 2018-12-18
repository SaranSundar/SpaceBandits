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
        private ArrayList panels;

        public void LoadContent(ContentManager content)
        {
            purpleSpaceTexture = content.Load<Texture2D>("purple");
            darkPurpleSpaceTexture = content.Load<Texture2D>("darkPurple");
            blueSpaceTexture = content.Load<Texture2D>("blue");
            blackSpaceTexture = content.Load<Texture2D>("black");
            panels = new ArrayList();
            panels.Add(new Panel(purpleSpaceTexture));
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            foreach (Panel panel in panels)
            {
                panel.Update(gameTime, keyboard);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Panel panel in panels)
            {
                panel.Draw(gameTime, spriteBatch);
            }
        }
    }
}