using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.GameCode
{
    interface IGameInterface
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        void Initialize(int screenWidth, int screenHeight);
        void LoadContent(ContentManager content);
    }
}