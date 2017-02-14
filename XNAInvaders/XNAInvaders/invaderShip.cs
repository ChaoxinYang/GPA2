using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace XNAInvaders
{
    class invaderShip
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
        

        public invaderShip()
        {

            texture= Global.content.Load<Texture2D>("enemy_ship");

            Init();

        }

        public void Init()
        {

            position.X = Global.width / 2;
            position.Y = 0 ;

            velocity.X = 4;
            

           

        }

        public void Death()
        {

            this.position.X = Global.width * 2;
            velocity.X = 0;

        }


        public void Update()
        {
            position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                
            }

        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
        }



    }
}
