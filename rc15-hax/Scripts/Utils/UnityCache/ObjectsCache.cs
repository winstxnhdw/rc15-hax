using UnityObject = UnityEngine.Object;

namespace Hax;
public class ObjectsCache<T> : ObjectCacheBase where T : UnityObject {
    public T[] Objects { get; set; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.FindObject();
    }

    protected override string TypeName() => typeof(T).FullName;

    protected override void FindObject() => this.Objects = UnityObject.FindObjectsOfType<T>();
}