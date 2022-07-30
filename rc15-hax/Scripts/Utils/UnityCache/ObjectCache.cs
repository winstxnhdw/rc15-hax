using UnityObject = UnityEngine.Object;

namespace Hax;
public class ObjectCache<T> : ObjectCacheBase where T : UnityObject {
    public T Object { get; set; }

    public ObjectCache(float updateInterval = 2.0f) : base(updateInterval) {
        this.FindObject();
    }

    protected override string TypeName() => typeof(T).FullName;

    protected override void FindObject() => this.Object = UnityObject.FindObjectOfType<T>();
}