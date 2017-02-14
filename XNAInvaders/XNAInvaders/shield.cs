using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class shield
    {


        public Vector2 position;
        public Texture2D texture;
        int width= Global.width /4;
        int height = Global.height-200;
       

        public shield()
        {
            texture = Global.content.Load<Texture2D>("shield");
            Init();


        }
       

        public void Init ()
        {

            position.X = Global.Random(0, Global.width-100);


            position.Y = height;


            



        }
        

        public void Update ()
        {


        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);


        }




    }
}
