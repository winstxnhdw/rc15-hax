using System;
using System.Collections;
using UnityEngine;

namespace RC15_HAX;

public class ObjectCache : ObjectCacheBase {
    public UnityEngine.Object Object { get; set; }
    public Type ObjectType { get; set; }
    // string TypeName { get => typeof(T).FullName; }

    public ObjectCache(string componentName, float updateInterval = 2.0f) : base(updateInterval) {
        this.ObjectType = Type.GetType(componentName);
        this.Object = GameObject.FindObjectOfType(this.ObjectType);
    }

    IEnumerator ICacheObjects() {
        // Console.Print($"Caching {this.TypeName} object(s)..");

        while (true) {
            this.Object = GameObject.FindObjectOfType(this.ObjectType);
            yield return new WaitForSeconds(base.UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) {
        base.Self = self;
        base.Self.StartCoroutine(this.ICacheObjects());
    }

    public void Stop() {
        base.Self.StopCoroutine(this.ICacheObjects());
        // Console.Print($"Stopping cache for {this.TypeName} object(s).");
    }
}

public class ObjectCache<T> : ObjectCacheBase where T : UnityEngine.Object {
    public T Object { get; set; }
    string TypeName { get => typeof(T).FullName; }

    public ObjectCache(float updateInterval = 2.0f) : base(updateInterval) {
        this.Object = GameObject.FindObjectOfType<T>();
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {this.TypeName} object(s)..");

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