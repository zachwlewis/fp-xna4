using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPX
{
    class World
    {
        //entities to update, remove, and add
        public List<Entity> entities = new List<Entity>();
        private List<Entity> _remove = new List<Entity>();
        private List<Entity> _add = new List<Entity>();

        public Boolean active = true;
        public Boolean visible = true;

        public void begin() { }

        public void update()
        {
            /*
             * This WILL be the update loop, eventually
            Entity e = _updateFirst;
			while (e)
			{
				if (e.active)
				{
					//if (e._tween) e.updateTweens();
					e.update();
				}
				//if (e._graphic && e._graphic.active) e._graphic.update();
				e = e._updateNext;
			}
            */
        }

        public void render()
        {
            /*
             * This will be the render loop, eventually
            Entity e;
            int i =_layerList.length;
			while (i --)
			{
				e = _renderLast[_layerList[i]];
				while (e)
				{
					if (e.visible) e.render();
					e = e._renderPrev;
				}
			}
            */
        }

        /// <summary>
        /// Adds a new entity
        /// </summary>
        public Entity add(Entity e)
		{
			//if (e.world != null) return e;

			_add.Add(e);
			e.world = this;
			return e;
		}

        /// <summary>
        /// Updates the add/remove lists at the end of the frame.
        /// </summary>
        public void updateLists() 
        {

            // remove entities
			if (_remove.Count > 0)
			{
				foreach(Entity e in _remove)
				{
                    if (e._added != true && _add.IndexOf(e) >= 0)
					{
						_add.Remove(e);
						continue;
					}

                    e._added = false;
					e.removed();

					//removeUpdate(e);
					//removeRender(e);

					//if (e._type) removeType(e);
					//if (e.autoClear && e._tween) e.clearTweens();
				}
			}

			// add entities
			if (_add.Count > 0)
			{
				foreach (Entity e in _add)
				{
					e._added = true;
					//addUpdate(e);
					//addRender(e);
					//if (e._type) addType(e);
					e.added();
				}
			}
			
			// sort the depth list
			/*if (_layerSort)
			{
				if (_layerList.length > 1) FP.sort(_layerList, true);
				_layerSort = false;
			}*/
        }

        public void end() { }

        
    }
}
