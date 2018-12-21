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
        public Panel(string fileName) : base(fileName, 0){}

        public void Update(GameTime gameTime, KeyboardState keyboard, object player)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            TranslatePosition(player);
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
            SetDest(0, 0, Constants.ScreenWidth, Constants.ScreenHeight);
        }
    }
}