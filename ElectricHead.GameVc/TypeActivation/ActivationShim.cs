using System;

namespace ElectricHead.GameVc.TypeActivation
{
    public class ActivationShim : IDependencyResolver
    {
        private readonly Func<Type, object> _create;

        public ActivationShim(Func<Type, object> create)
        {
            _create = create;
        }

        public T CreateInstance<T>()
        {
            return (T) CreateInstance(typeof (T));
        }

        public object CreateInstance(Type t)
        {
            return _create(t);
        }
    }
}