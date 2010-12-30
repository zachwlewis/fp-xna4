using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FPX
{
    class Screen
    {
        public Color color = Color.CornflowerBlue;

        //screen angle (for rotation of the screen)
        public float angle = 0f;

        //screen scale (to scale screen)
        public float scaleX = 0f;
        public float scaleY = 0f;

        //screen size
        public readonly int width;
        public readonly int height;

        /// <summary>
        /// Constructor function
        /// </summary>
        public Screen()
        {
            width = FP.width;
            height = FP.height;
        }

        /// <summary>
        /// "Refreshes" the screen. Paints over the screen with a color. (FP.screen.color)
        /// </summary>
        public void refresh()
        {
            FP.engine.GraphicsDevice.Clear(color);
        }
    }

    
}
