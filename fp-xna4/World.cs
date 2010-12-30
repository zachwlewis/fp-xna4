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

        /// <summary>
        /// Updates all the entities
        /// </summary>
        public void update()
        {

            foreach (Entity e in entities)
            {
                if (e.active)
                {
                    //if(e._tween) { e.updateTweens(); }
                    e.update();
                }

                //this is how the graphics are updated seperately from the entities
                //if (e._graphic && e._graphic.active) e._graphic.update();
            }
        }

        /// <summary>
        /// Renders all the entities
        /// </summary>
        public void render()
        {
            foreach (Entity e in entities)
            {
                if (e.visible)
                {
                    e.render();
                }
            }
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

                    _remove.Remove(e);

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
					//if (e._type) addType(e);
					e.added();

                    _add.Remove(e);
				}
			}
			
			// sort the depth list
            // Do we even need to do this?
			/*if (_layerSort)
			{
				if (_layerList.length > 1) FP.sort(_layerList, true);
				_layerSort = false;
			}*/
        }

        public void end() { }

        
    }
}
