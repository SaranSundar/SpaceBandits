using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.GameCode.Characters;

namespace SpaceInvaders.GameCode.Animation
{
    internal class SpriteSheet : Sprite, IGameInterface
    {
        private int startCount, endCount, maxCount;
        private List<Texture2D> sprites;
        private int frame;
        private float msecondsPassed;
        private readonly float mstimeLimit;

        public SpriteSheet(string fileName, float rotationOffset, int startCount, int endCount, int maxCount) : base(fileName, rotationOffset)
        {
            this.startCount = startCount;
            this.endCount = endCount;
            this.maxCount = maxCount;
            this.fileName = fileName;
            frame = 0;
            msecondsPassed = 0;
            mstimeLimit = 100;

        }

        public void Update(GameTime gameTime, KeyboardState keyboard, object anything)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            msecondsPassed += elapsedTime;
            if(msecondsPassed >= mstimeLimit)
            {
                msecondsPassed = 0;
                frame++;
                if(frame >= sprites.Count)
                {
                    frame = 0;
                }
            }
            if (anything is Player)
            {
                Player Player = ((Player)anything);
                position = Player.Position;

                //approach1 = take difference between anchor point and player position
                //approach2 = make offset place u at anchor point


                //position = Player.Position;
                rotation = Player.Rotation;
                //rotation += MathHelper.ToRadians(180);
                //originVector = new Vector2(0, 0);
                //originVector = Player.OriginVector - Player.AnchorPoints[0];
                originVector = new Vector2(Player.OriginVector.X - Player.AnchorPoints[0].X + sourceRect.Width/2,
                Player.OriginVector.Y - Player.AnchorPoints[0].Y);
                //originVector = new Vector2(sourceRect.Width * (.50f), -(sourceRect.Height) * (1.2f));
                //originVector = new Vector2(7, 70);
                TranslatePosition(anything);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprites[frame], drawTranslation + position, null, Color.White, rotation, originVector, 1f, 0, 0);

        }

        public void LoadContent(ContentManager content)
        {
            sprites = new List<Texture2D>();
            int maxLength = ("" + maxCount).Length;
            for(int i = startCount; i <= endCount; i++)
            {
                int currLength = ("" + i).Length;
                int diff = maxLength - currLength;
                string zeros = "";
                for(int s = 0; s < diff; s++)
                {
                    zeros += "0";
                }
                Texture2D spriteL = content.Load<Texture2D>(fileName+zeros+i);
                sprites.Add(spriteL);
            }
            sprite = sprites[0];
            LoadSprite(sprite);
            SetDest(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2, (int)(sprite.Width * 1.5), (int)(sprite.Height * 1.5));
            //originVector = new Vector2(0, 100);
        }
    }
}
