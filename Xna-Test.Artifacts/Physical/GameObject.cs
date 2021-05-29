using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xna_Test.Extensions;

namespace Xna_Test.Artifacts.Physical
{
    public abstract class GameObject
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Vector2 Location { get; set; }
        public ObjectId ObjectId { get; } = ObjectId.EMPTY;
        public Texture2D Sprite { get; private set; }
        public float Scale { get; set; } = 2f;
        public float Rotation { get; set; } = 0f;
        private List<Texture2D> _frames = new List<Texture2D>();
        protected bool Usable { get; private set; } = false;

        public GameObject(ObjectId id)
        {
            ObjectId = id;
            Id = Guid.NewGuid();
        }

        public void Create(string name, Vector2 loc, Texture2D sprite, float scale = 2f, float rotation = 0f)
        {
            Location = loc;
            Sprite = sprite;
            Name = name;

            Scale = scale;
            Rotation = rotation;

            if (ObjectId != ObjectId.EMPTY && Id != null)
                Usable = true;
        }

        public Texture2D GetFrame(int i, GraphicsDevice device)
        {
            if (_frames.Count == 0)
            {
                _frames = Sprite.GetSprites(16, device);
            }
            return _frames[i];
        }

        public void Move(float x, float y) => Location = new Vector2(Location.X + x, Location.Y + y);
    }

    public enum ObjectId
    {
        EMPTY,
        ENTITY_PLAYER,
        ENTITY_ENEMY_ZOMBIE,
    }
}
