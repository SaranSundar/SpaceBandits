using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceInvaders.GameCode.Characters
{
    internal class Sprite : PhysicsObject
    {
        protected Texture2D sprite;
        protected string fileName;
        protected Rectangle sourceRect, destRect;

        public Sprite(string fileName)
        {
            this.fileName = fileName;
        }

        public Sprite()
        {
        }

    }
}
