using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectricHead.GameVc.TypeActivation
{
    public interface IDependencyResolver
    {
        T CreateInstance<T>();
        object CreateInstance(System.Type t);
    }
}
