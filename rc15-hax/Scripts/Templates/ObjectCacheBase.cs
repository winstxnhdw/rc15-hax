using UnityEngine;

namespace RC15_HAX;
public class ObjectCacheBase {
    protected MonoBehaviour Self { get; set; }
    protected float UpdateInterval { get; set; }
    protected bool StopCaching { get; set; }

    public ObjectCacheBase(float updateInterval) {
        this.UpdateInterval = updateInterval;
    }
}