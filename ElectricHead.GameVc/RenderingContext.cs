using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ElectricHead.GameVc
{
    public class RenderingContext
    {
        public Game Game { get; set; }
        public GraphicsDeviceManager GraphicsDevice { get; set; }
        public SpriteBatch SpriteBatch { get; set; }
        public string ContentDirectory { get; set; }

        public Texture2D Load(string path)
        {
            var fullPath = Path.Combine(ContentDirectory, path);
            using (var fileStream = new FileStream(fullPath, FileMode.Open))
            {
                return Texture2D.FromStream(GraphicsDevice.GraphicsDevice, fileStream);
            }
        }
    }
}