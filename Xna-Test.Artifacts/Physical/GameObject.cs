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
        public Vector2 Location { get; set; }
        public ObjectId Id { get; }
        public List<Texture2D> Frames { get; private set; }

        public GameObject(ObjectId id)
        {
            Id = id;
        }

        public GameObject(ObjectId id, Vector2 loc)
        {
            Id = id;
            Location = loc;
        }

        public GameObject(ObjectId id, List<Texture2D> frames)
        {
            Id = id;
            Frames = frames;
        }

        public GameObject(ObjectId id, Texture2D texture, GraphicsDevice graphics)
        {
            Id = id;
            Frames = texture.GetSprites(16, graphics);
        }

        public GameObject(ObjectId id, Vector2 loc, List<Texture2D> frames)
        {
            Id = id;
            Location = loc;
            Frames = frames;
        }

        public GameObject(ObjectId id, Vector2 loc, Texture2D texture, GraphicsDevice graphics)
        {
            Id = id;
            Location = loc;
            Frames = texture.GetSprites(16, graphics);
        }

        public void AssignTexture(Texture2D texture, int frame = 0) => Frames.Set(texture, frame);
        public void AssignSpriteSheet(Texture2D sheet, GraphicsDevice graphics) => Frames = sheet.GetSprites(16, graphics);
    }

    public enum ObjectId
    {
        ENTITY_PLAYER,
        ENTITY_ENEMY_ZOMBIE,
    }
}
