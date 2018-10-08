using System;
using System.Linq;
using System.Reflection;
using Microsoft.Xna.Framework;

namespace ElectricHead.GameVc.Rendering
{
    public class RenderASceneProxy
    {
        private readonly object _rendererInstance;
        private readonly MethodInfo _drawMethod;

        public RenderASceneProxy(object rendererInstance)
        {
            _rendererInstance = rendererInstance;

            // This is nasty but it allows me to keep the IRenderAScene<IScene> type constraints, allowing
            // users to not have to directly inherit from Scene or other "frameworkey" bits in their code.
            _drawMethod = rendererInstance.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Single(x => x.Name == "Draw");
        }

        public void Draw(RenderingContext context, object currentScene, GameTime now)
        {
            if (currentScene is IRenderAScene selfRenderer)
            {
                selfRenderer.Draw(context, now);
                return;
            }

            _drawMethod.Invoke(_rendererInstance, new[] { context, currentScene, now });
        }
    }
}
