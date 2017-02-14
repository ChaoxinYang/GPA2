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
        public Vector2 velocity;
        public Texture2D texture;
        int width= Global.width /4;
        int height = Global.height/3;

        public shield()
        {
            texture = Global.content.Load<Texture2D>("shield");
            Init();


        }


        public void Init ()
        {

            position.X = width;
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
