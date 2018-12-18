using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameCode
{
    class PhysicsObject
    {
        protected int screenWidth, screenHeight;
        protected Vector2 acceleration, velocity, position;
        protected double mass;
        protected float rotation, rotationOffset;

        public PhysicsObject()
        {
        }

        public PhysicsObject(int screenWidth, int screenHeight, Vector2 acceleration, Vector2 velocity, Vector2 position, double mass)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.acceleration = acceleration;
            this.velocity = velocity;
            this.position = position;
            this.mass = mass;
            rotation = 0;
            rotationOffset = 0;
        }
    }
}
