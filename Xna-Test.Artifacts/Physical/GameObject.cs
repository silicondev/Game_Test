using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xna_Test.Artifacts.Physical
{
    public abstract class GameObject
    {
        public (float x, float y) Location { get; set; }
        public ObjectId Id { get; }

        public GameObject(ObjectId id)
        {
            Id = id;
        }

        public GameObject(ObjectId id, (float x, float y) loc)
        {
            Id = id;
            Location = loc;
        }
    }

    public enum ObjectId
    {
        ENTITY_PLAYER,
        ENTITY_ENEMY_ZOMBIE,
    }
}
