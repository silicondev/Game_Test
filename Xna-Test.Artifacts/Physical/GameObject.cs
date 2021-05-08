using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xna_Test.Artifacts.Physical
{
    public abstract class GameObject
    {
        public Vector2 Location { get; set; }
        public ObjectId Id { get; }
        public Texture2D Texture { get; private set; }

        public GameObject(ObjectId id)
        {
            Id = id;
        }

        public GameObject(ObjectId id, Vector2 loc)
        {
            Id = id;
            Location = loc;
        }

        public GameObject(ObjectId id, Texture2D texture)
        {
            Id = id;
            Texture = texture;
        }

        public GameObject(ObjectId id, Vector2 loc, Texture2D texture)
        {
            Id = id;
            Location = loc;
            Texture = texture;
        }

        public void AssignTexture(Texture2D texture) => Texture = texture;
    }

    public enum ObjectId
    {
        ENTITY_PLAYER,
        ENTITY_ENEMY_ZOMBIE,
    }
}
