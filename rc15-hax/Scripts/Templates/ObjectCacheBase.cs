using UnityEngine;

namespace RC15_HAX;
public class ObjectCacheBase<T> where T : Object {
    protected float UpdateInterval { get; set; }
    protected bool StopCaching { get; set; }
    protected string TypeName { get => typeof(T).FullName; }

    public ObjectCacheBase(float updateInterval = 5.0f) {
        this.UpdateInterval = updateInterval;
    }

    public void Stop() => this.StopCaching = true;

    public void StopLog() => Console.Print($"Stopping cache for {this.TypeName} object(s).");

    public bool IsStopped() => this.StopCaching;
}