using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Xna_Test.Artifacts.Physical;

namespace Xna_Test.Game
{
    public static class Graphics
    {
        private static List<GameObject> LoadedObjects = new List<GameObject>();
        private static SpriteBatch Batch;

        public static BeginState BeginState { get; } = new BeginState();
        
        public static GameObject Get(string name) => LoadedObjects.FirstOrDefault(x => x.Name == name);

        public static void Initialize(GraphicsDevice device)
        {
            LoadedObjects = new List<GameObject>();
            Batch = new SpriteBatch(device);
        }

        public static void LoadObject(GameObject obj)
        {
            LoadedObjects.Add(obj);
        }

        public static void UnloadObject(GameObject obj)
        {
            UnloadObject(obj.Id);
        }

        public static void UnloadObject(Guid id)
        {
            LoadedObjects.RemoveAll(x => x.Id == id);
        }

        public static void UnloadObject(string name)
        {
            LoadedObjects.RemoveAll(x => x.Name == name);
        }

        public static void Draw()
        {

            if (BeginState.Effect == null)
                Batch.Begin(BeginState.SpriteSortMode, BeginState.BlendState, BeginState.SamplerState, BeginState.DepthStencilState, BeginState.RasterizerState);
            else if (BeginState.TransformMatrix == null)
                Batch.Begin(BeginState.SpriteSortMode, BeginState.BlendState, BeginState.SamplerState, BeginState.DepthStencilState, BeginState.RasterizerState, BeginState.Effect);
            else
                Batch.Begin(BeginState.SpriteSortMode, BeginState.BlendState, BeginState.SamplerState, BeginState.DepthStencilState, BeginState.RasterizerState, BeginState.Effect, BeginState.TransformMatrix.Value);

            foreach (var obj in LoadedObjects)
            {
                Batch.Draw(obj.GetFrame(0, Batch.GraphicsDevice), obj.Location, null, Color.White, 0f, default, obj.Scale, SpriteEffects.None, obj.Rotation);
            }

            Batch.End();
        }
    }

    public class BeginState
    {
        public SpriteSortMode SpriteSortMode { get; set; } = SpriteSortMode.Deferred;
        public BlendState BlendState { get; set; } = BlendState.NonPremultiplied;
        public SamplerState SamplerState { get; set; } = SamplerState.PointClamp;
        public DepthStencilState DepthStencilState { get; set; } = DepthStencilState.Default;
        public RasterizerState RasterizerState { get; set; } = RasterizerState.CullNone;
        public Effect Effect { get; set; } = null;
        public Matrix? TransformMatrix { get; set; } = null;
    }
}
