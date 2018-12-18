using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace SpaceInvaders.GameCode.Background
{
    internal class BackgroundRenderer : IGameInterface
    {
        private Panel purpleSpacePanel;
        //private Panel darkPurpleSpacePanel;
        //private Panel blueSpacePanel;
        //private Panel blackSpacePanel;
        private ArrayList panels;

        public void LoadContent(ContentManager content)
        {
            panels = new ArrayList();
            purpleSpacePanel = new Panel("Backgrounds/purple");
            //darkPurpleSpacePanel = new Panel("Backgrounds/darkPurple");
            //blueSpacePanel = new Panel("Backgrounds/blue");
            //blackSpacePanel = new Panel("Backgrounds/black");
            panels.Add(purpleSpacePanel);

            foreach (Panel panel in panels)
            {
                panel.LoadContent(content);
            }
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