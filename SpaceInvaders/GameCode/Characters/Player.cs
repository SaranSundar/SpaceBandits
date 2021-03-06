﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.GameCode.Animation;

namespace SpaceInvaders.GameCode.Characters
{
    internal class Player : Sprite, IGameInterface
    {

        private SpriteSheet engineAnimation;

        public Player(string fileName, float rotationOffset) : base(fileName, rotationOffset)
        {
            acceleration = 20f;
            maxSpeed = 12f;
            friction = 0.983f;
            mass = 3;
            engineAnimation = new SpriteSheet("PNG/Effects/fire", MathHelper.ToRadians(-180), 1, 7, 19);
        }

        public void Update(GameTime gameTime, KeyboardState keyboard, object none)
        {
            float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float moveSpeed = (float)moveAmount * elapsedTime;
            drawTranslation = drawPosition - position;
            if (RightDown(keyboard))
            {
                rotation += rotationSpeed;
            }
            else if (LeftDown(keyboard))
            {
                rotation -= rotationSpeed;
            }
            UpdateDirection(Rotation, RotationOffset, keyboard);
            velocity += acceleration * direction * elapsedTime;
            if (velocity.LengthSquared() > maxSpeed * maxSpeed)
            {
                velocity.Normalize();
                velocity *= maxSpeed;
            }
            position += velocity;
            for (int i=0;i<anchorPoints.Count;i++)
            {
                //anchorPoints[i] += velocity;
            }
            velocity *= friction;
            destRect.X = (int)position.X;
            destRect.Y = (int)position.Y;
            engineAnimation.Update(gameTime, keyboard, this);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //DrawSprite(spriteBatch); // For some reason moves a little as it draws
            spriteBatch.Draw(sprite, // Texture
            drawTranslation + position,      // Position
            sourceRect,    // Source rectangle
            Color.White,   // Color
            rotation,      // Rotation
            originVector,   // Origin
            scaleVector,       // Scale
            SpriteEffects.None,  // Mirroring effect
            layerDepth);       // Depth
            engineAnimation.Draw(gameTime, spriteBatch);
        }

        public void LoadContent(ContentManager content)
        {
            LoadSprite(content);
            SetDest(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2, sprite.Width, sprite.Height);
            drawPosition = new Vector2(Constants.ScreenWidth / 2, Constants.ScreenHeight / 2);
            position = new Vector2(-500, -500);
            anchorPoints = new List<Vector2>();
            anchorPoints.Add(new Vector2(destRect.Width/2,destRect.Height));
            engineAnimation.LoadContent(content);
        }

        public float Rotation
        {
            get
            {
                return rotation;
            }
        }

        public float Mass
        {
            get
            {
                return mass;
            }
        }

        public List<Vector2> AnchorPoints
        {
            get
            {
                return anchorPoints;
            }
        }

        public Vector2 OriginVector
        {
            get
            {
                return originVector;
            }
        }

        public Vector2 VelocityVector
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public Rectangle DestRect
        {
            get
            {
                return destRect;
            }
        }

        public int Height
        {
            get
            {
                return destRect.Height;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Vector2 DrawTranslation
        {
            get
            {
                return drawTranslation;
            }
        }

        public float RotationOffset
        {
            get
            {
                return rotationOffset;
            }
        }

    }
}
