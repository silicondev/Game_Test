using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SiliconGameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xna_Test.Artifacts.Physical.Entities
{
    public class Player : GameObject
    {
        public Player() : base(ObjectId.ENTITY_PLAYER)
        {

        }

        public override void Draw()
        {
            Physics.SetExertionEnable("exertion:gravity", Location.Y < 100);
        }
    }
}
