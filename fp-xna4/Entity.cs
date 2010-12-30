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

        public void added() { }
        public void removed() { }

        public Boolean _added = false;
    }
}
