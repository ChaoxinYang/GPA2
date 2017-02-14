using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class Invader
    {
        public Vector2 position;
        public Vector2 velocity;
        public Texture2D texture;
       
        //wat houdt dit in ?

        public Invader()

        {

            int i = Global.Random(0, 4);

            switch (i)
            {

                case 0:

                    texture = Global.content.Load<Texture2D>("red_invader");

                    break;

                case 1:


                    texture = Global.content.Load<Texture2D>("blue_invader");

                    break;



                case 2:
                    texture = Global.content.Load<Texture2D>("yellow_invader");
                    break;


                case 3:
                    texture = Global.content.Load<Texture2D>("green_invader");
                    break;


                default:
                    texture = Global.content.Load<Texture2D>("grenn_invader");
                    break; 
            }

           
            

            Init();


        } 
        

        public void Init() {
            
            position.X = Global.Random(100, Global.width - 100);
            position.Y = Global.Random(30, Global.height - 300);

            velocity.X = 3;
            velocity.Y = 10;


            

        }

        


        public void Update() {
           position.X += velocity.X;

            if ((position.X > Global.width - texture.Width) || (position.X < 0))
            {
                position.X -= velocity.X;
                velocity.X = -velocity.X;
                position.Y += velocity.Y;
            }

        }
        public void Draw() {

            Global.spriteBatch.Draw(texture, position, Color.White);


        }

    }
}
