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
        public Guid Id { get; }
        public string Name { get; }
        public Vector2 Location { get; set; }
        public ObjectId ObjectId { get; }
        public Texture2D Sprite { get; }
        public float Scale { get; set; } = 2f;
        public float Rotation { get; set; } = 0f;
        private List<Texture2D> _frames = new List<Texture2D>();

        public GameObject(ObjectId id, string name, Vector2 loc, Texture2D sprite)
        {
            ObjectId = id;
            Location = loc;
            Sprite = sprite;
            Name = name;
            Id = Guid.NewGuid();
        }

        public GameObject(ObjectId id, string name, Vector2 loc, Texture2D sprite, float scale, float rotation)
        {
            ObjectId = id;
            Location = loc;
            Sprite = sprite;
            Name = name;
            Id = Guid.NewGuid();

            Scale = scale;
            Rotation = rotation;
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
        ENTITY_PLAYER,
        ENTITY_ENEMY_ZOMBIE,
    }
}
