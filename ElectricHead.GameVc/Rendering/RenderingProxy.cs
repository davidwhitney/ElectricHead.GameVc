using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Rendering
{
    public class RenderingProxy
    {
        private readonly object _scene;
        private readonly Type _rendererType;
        private readonly MethodInfo _renderer;

        public RenderingProxy(object scene, Type rendererType)
        {
            _scene = scene;
            _rendererType = rendererType;

            // This is nasty but it allows me to keep the IRenderAScene<IScene> type constraints, allowing
            // users to not have to directly inherit from Scene or other "frameworkey" bits in their code.
            _renderer = _rendererType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Single(x => x.Name == "Draw");
        }

        public void Render(RenderingContext ctx, GameTime time)
        {
            var rendererInstance = Activator.CreateInstance(_rendererType);
            _renderer.Invoke(rendererInstance, new[] {ctx, _scene, time});
        }
    }
}
