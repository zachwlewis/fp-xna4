using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPX
{
    class Entity
    {

        public Boolean active = true;
        public Boolean visible = true;
        public Boolean collidable = true;

        public int x = 0;
        public int y = 0;

        public int width;
        public int height;

        public int originX;
        public int originY;

        public World world;

        public Entity(int x, int y /*, Graphic graphic, Mask mask*/)
        {
            this.x = x;
            this.y = y;


        }

        /// <summary>
        /// Called when Entity is added to the world
        /// </summary>
        public void added() { }

        /// <summary>
        /// Called when Entity is removed from the world
        /// </summary>
        public void removed() { }

        /// <summary>
        /// Updates the Entity
        /// </summary>
        public void update() { }

        /// <summary>
        /// Renders the Entity. If you override this for special behaviour,
        /// remember to call super.render() to render the Entity's graphic.
        /// </summary>
        public void render() 
        {

        }

        /// <summary>
        /// The rendering layer of this Entity. Higher layers are rendered first.
        /// </summary>
        public int layer
        {
            get
            {
                return _layer;
            }

            set 
            {
                if(_layer == value) { return; }

			    if (!_added)
			    {
				    _layer =  value;
				    return;
			    }
			    //world.removeRender(this);
			    _layer = value;
			    //_world.addRender(this);
            }
        }

        public Boolean _added = false;
        public Entity _renderPrev;
        public Entity _renderNext;
        public int _layer = 0;
    }
}
