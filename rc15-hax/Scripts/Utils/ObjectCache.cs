using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class ObjectCache<T> : ObjectCacheBase<T> where T : Object {
    public T Object { get; set; }

    public ObjectCache(float updateInterval = 2.0f) : base(updateInterval) {
        this.Object = GameObject.FindObjectOfType<T>();
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {base.TypeName} object(s)..");

        while (true) {
            this.Object = GameObject.FindObjectOfType<T>();
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