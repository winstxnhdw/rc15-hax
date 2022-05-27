using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RC15_HAX;
public static class Utils {
    public static IEnumerable<(int index, T value)> Enumerate<T>(IEnumerable<T> coll) => coll.Select((i, val) => (val, i));
    public static bool IsEnumerableType(dynamic type) => (!(type is string) && type.GetInterface(nameof(IEnumerable)) != null);
}