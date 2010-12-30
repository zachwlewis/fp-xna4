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

        public World world;

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

        public Boolean _added = false;
    }
}
