using System.Collections.Generic;
using System.Linq;

namespace Ara3D.Utils
{
    public class IndexedSet<T> : Dictionary<T, int>
    {
        public bool Contains(T x)
            => ContainsKey(x);

        public int IndexOf(T x)
        {
            if (TryGetValue(x, out var tmp))
                return tmp;
            return -1;
        }

        public int Add(T key)
        {
            if (TryGetValue(key, out var val))
                return val;
            var tmp = Count;
            Add(key, tmp);
            return tmp;
        }

        public IEnumerable<T> OrderedMembers()
            => this.OrderBy(kv => kv.Value).Select(kv => kv.Key);
    }
}