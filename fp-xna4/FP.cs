using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPX
{
	class FP
	{
		public static int width;
		public static int height;

        public static Engine engine;
        public static Screen screen;

        //world
        public static World _world;
        public static World _goto = null;

        public static World world
        {
            get
            {
                return _world;
            }

            set
            {
                _goto = value;
            }
        }
        

	}
}
