using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameCode
{
    interface IGameInterface
    {
        void Update(GameTime gameTime, KeyboardState keyboard);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void LoadContent(ContentManager content);
    }
}