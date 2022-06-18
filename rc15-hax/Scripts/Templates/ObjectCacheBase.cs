using UnityEngine;

namespace RC15_HAX;
public class ObjectCacheBase<T> where T : Object {
    protected MonoBehaviour Self { get; set; }
    protected float UpdateInterval { get; set; }
    protected bool StopCaching { get; set; }
    protected string TypeName { get => typeof(T).FullName; }

    public ObjectCacheBase(float updateInterval = 5.0f) {
        this.UpdateInterval = updateInterval;
    }
}