using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xna_Test.Game
{
    public class TextureHolder
    {
        private GraphicsDevice _graphics;
        private static readonly string _start = @"Resources\Textures\";
        private bool _preLoaded;

        private List<Texture> _textures = new List<Texture>()
        {
            new Texture("HUMAN_MALE", _start + @"Entity\Human\Human_Male.png")
        };

        public TextureHolder(GraphicsDevice graphics, bool preLoad = false)
        {
            _graphics = graphics;
            _preLoaded = preLoad;
            if (preLoad)
                foreach (var tex in _textures)
                {
                    tex.LoadTexture(_graphics);
                }
        }

        public Texture2D this[string path]
        {
            get
            {
                if (_preLoaded)
                    return _textures.Find(x => x.Code == path).GetTexture();
                else
                    return _textures.Find(x => x.Code == path).GetTexture(_graphics);
            }
        }
    }

    internal class Texture
    {
        private string _path;
        public string Code { get; }
        public Texture(string code, string path)
        {
            Code = code;
            _path = path;
        }

        private Texture2D _texture;
        private bool _hasTexture = false;

        public Texture2D GetTexture(GraphicsDevice graphics)
        {
            if (!_hasTexture)
            {
                LoadTexture(graphics);
            }
            return _texture;
        }

        public Texture2D GetTexture()
        {
            if (!_hasTexture)
                return null;
            return _texture;
        }

        public void LoadTexture(GraphicsDevice graphics)
        {
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                _texture = Texture2D.FromStream(graphics, stream);
            }
            _hasTexture = true;
        }
    }
}
