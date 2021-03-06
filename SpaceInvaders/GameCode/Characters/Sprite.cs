﻿using System;
using System.Collections.Generic;
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
        protected Rectangle sourceRect, destRect, drawRect;
        protected float layerDepth = 1.0f;
        protected Vector2 scaleVector, originVector;
        protected float rotationSpeed;
        protected float moveAmount = 0;
        protected Vector2 drawPosition, drawTranslation;
        protected List<Vector2> anchorPoints;

        public Sprite(string fileName, float rotationOffset)
        {
            this.fileName = fileName;
            this.rotationOffset = rotationOffset;
            rotationSpeed = (float)DegreeToRadian(5);
        }

        public void DrawSprite(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, // Texture
                drawTranslation + position,      // Position
                sourceRect,    // Source rectangle
                Color.White,   // Color
                rotation,      // Rotation
                originVector,   // Origin
                scaleVector,       // Scale
                SpriteEffects.None,  // Mirroring effect
                layerDepth);       // Depth
        }

        public void TranslatePosition(Object player)
        {
            Player Player = (Player)player;
            drawTranslation = Player.DrawTranslation;
            drawPosition = position - drawTranslation;
            drawRect.X = (int)drawPosition.X;
            drawRect.Y = (int)drawPosition.Y;
            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;
        }

        public void LoadSprite(ContentManager content)
        {
            sprite = content.Load<Texture2D>(fileName);
            sourceRect = new Rectangle(0, 0, sprite.Width, sprite.Height);
            scaleVector = new Vector2(1, 1);
            originVector = new Vector2(sprite.Width / 2 * scaleVector.X, sprite.Height / 2 * scaleVector.Y);
        }

        public void LoadSprite(Texture2D sprite)
        {
            sourceRect = new Rectangle(0, 0, sprite.Width, sprite.Height);
            scaleVector = new Vector2(1, 1);
            originVector = new Vector2(sprite.Width / 2 * scaleVector.X, sprite.Height / 2 * scaleVector.Y);
        }

        public void SetDest(int dX, int dY, int dW, int dH)
        {
            destRect = new Rectangle(dX, dY, dW, dH);
            position = new Vector2(destRect.X, destRect.Y);
            drawRect = new Rectangle(dX, dY, dW, dH);
        }

        // This method applies the effects of movement to our entity.
        // Speed is the number of pixels the object should move per call.
        //https://gamedev.stackexchange.com/questions/50793/moving-a-sprite-in-the-direction-its-facing-xna
        public void UpdateDirection(float rotation, float rotationOffset, KeyboardState keyboard)
        {
            if (UpDown(keyboard))
            {
                direction.X = (float)Math.Cos(rotation - rotationOffset);
                direction.Y = (float)Math.Sin(rotation - rotationOffset);
                direction.Normalize();
            }
            else
            {
                direction.X = 0;
                direction.Y = 0;
            }
        }

        public bool RightDown(KeyboardState keyboard)
        {
            return keyboard.IsKeyDown(Keys.Right);
        }

        public bool LeftDown(KeyboardState keyboard)
        {
            return keyboard.IsKeyDown(Keys.Left);
        }

        public bool UpDown(KeyboardState keyboard)
        {
            return keyboard.IsKeyDown(Keys.Up);
        }

        public bool DownDown(KeyboardState keyboard)
        {
            return keyboard.IsKeyDown(Keys.Down);
        }
        public float DegreeToRadian(double angle)
        {
            return (float)(Math.PI * angle / 180.0);
        }

    }
}
