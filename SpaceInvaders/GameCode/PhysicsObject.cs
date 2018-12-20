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
        protected Vector2 velocity, position, direction;
        protected double mass;
        protected float acceleration, maxSpeed, friction;
        protected float rotation, rotationOffset;

        public PhysicsObject()
        {
            rotation = 0;
            rotationOffset = 0;
            velocity = new Vector2(0, 0);
            direction = new Vector2(0, 0);
        }
    }
}
