using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xna_Test.Textures
{
    public class TextureHolder
    {
        private GraphicsDevice _device;
        private static string _start = @"Resources\Textures\";
        private bool _preLoaded;

        private List<Texture> _textures = new List<Texture>()
        {
            new Texture("HUMAN_MALE", _start + @"Entity\Human\Human_Male.png")
        };

        public TextureHolder(GraphicsDevice grDevice, bool preLoad = false)
        {
            _device = grDevice;
            _preLoaded = preLoad;
            if (preLoad)
                foreach (var tex in _textures)
                {
                    tex.LoadTexture(_device);
                }
        }

        public Texture2D this[string path]
        {
            get
            {
                if (_preLoaded)
                    return _textures.Find(x => x.Code == path).GetTexture();
                else
                    return _textures.Find(x => x.Code == path).GetTexture(_device);
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

        public Texture2D GetTexture(GraphicsDevice device)
        {
            if (!_hasTexture)
            {
                using (FileStream stream = File.Open(_path, FileMode.Open))
                {
                    _texture = Texture2D.FromStream(device, stream);
                }
                _hasTexture = true;
            }
            return _texture;
        }

        public Texture2D GetTexture()
        {
            if (!_hasTexture)
                return null;
            return _texture;
        }

        public void LoadTexture(GraphicsDevice device)
        {
            using (FileStream stream = File.Open(_path, FileMode.Open))
            {
                _texture = Texture2D.FromStream(device, stream);
            }
            _hasTexture = true;
        }
    }
}
