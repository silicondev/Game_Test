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
        private static readonly string _start = @"Resources\Textures\";

        private List<Texture> _textures = new List<Texture>()
        {
            new Texture("HUMAN_MALE", _start + @"Entity\Human\Human_Male.png"),
            new Texture("ENV_TILE", _start + @"Tile\env.png")
        };

        public TextureHolder(bool preLoad = false)
        {
            if (preLoad)
                foreach (var tex in _textures)
                {
                    tex.LoadTexture();
                }
        }

        public Texture2D this[string code] => _textures.Any(x => x.Code == code) ? _textures.First(x => x.Code == code).GetTexture() : null;
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

        public Texture2D GetTexture()
        {
            if (!_hasTexture)
                LoadTexture();
            return _texture;
        }

        public void LoadTexture()
        {
            using (var stream = new FileStream(_path, FileMode.Open))
            {
                _texture = Texture2D.FromStream(ProgramStore.GameGraphicsDevice, stream);
            }
            _hasTexture = true;
        }
    }
}
