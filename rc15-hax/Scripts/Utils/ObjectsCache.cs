using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class ObjectsCache<T> : ObjectCacheBase<T> where T : Object {
    public T[] Objects { get; set; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.Objects = GameObject.FindObjectsOfType<T>();
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {base.TypeName} object(s)..");

        while (true) {
            this.Objects = GameObject.FindObjectsOfType<T>();
            yield return new WaitForSeconds(base.UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) {
        base.Self = self;
        base.Self.StartCoroutine(this.ICacheObjects());
    }

    public void Stop() {
        base.Self.StopCoroutine(this.ICacheObjects());
        Console.Print($"Stopping cache for {this.TypeName} object(s).");
    }
}