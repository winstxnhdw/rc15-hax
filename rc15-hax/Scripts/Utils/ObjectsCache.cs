using System;
using System.Collections;
using UnityEngine;

namespace RC15_HAX;

public class ObjectsCache : ObjectCacheBase {
    public UnityEngine.Object[] Objects { get; set; }
    Type ObjectType { get; set; }
    string TypeName { get => this.ObjectType.FullName; }

    public ObjectsCache(string componentName, float updateInterval = 5.0f) : base(updateInterval) {
        this.ObjectType = Global.GetRobocraftType(componentName);

        try {
            this.Objects = GameObject.FindObjectsOfType(this.ObjectType);
        }

        catch (Exception e) {
            Console.Print($"Unable to find object of type {this.TypeName}:\n{e}");
        }
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {this.TypeName} object(s)..");

        while (true) {
            this.Objects = GameObject.FindObjectsOfType(this.ObjectType);
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
public class ObjectsCache<T> : ObjectCacheBase where T : UnityEngine.Object {
    public T[] Objects { get; set; }
    string TypeName { get => typeof(T).FullName; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.Objects = GameObject.FindObjectsOfType<T>();
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {this.TypeName} object(s)..");

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