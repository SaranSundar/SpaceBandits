using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.GameCode.Characters;

namespace SpaceInvaders.GameCode.Background
{
    internal class Panel : Sprite, IGameInterface
    {

        public Panel(string fileName) : base(fileName, 0){}

        public void Update(GameTime gameTime, KeyboardState keyboard, object player)
        {
            float elpasedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)moveAmount * elpasedTime;
            var Player = (Player)(player);
            //if (RightDown(keyboard))
            //{
            //    position.X += moveSpeed;
            //}
            //else if (LeftDown(keyboard))
            //{
            //    position.X -= moveSpeed;
            //}
            if (UpDown(keyboard))
            {
                //position.Y -= moveSpeed;
                MoveEntity(moveSpeed, Player.Rotation, Player.RotationOffset);

            }
            else if (DownDown(keyboard))
            {
                //position.Y += moveSpeed;
                MoveEntity(-moveSpeed, Player.Rotation, Player.RotationOffset);
            }

            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;

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
            destRect = new Rectangle(0, 0, Constants.ScreenWidth, Constants.ScreenHeight);
            position = new Vector2(destRect.X, destRect.Y);
        }
    }
}