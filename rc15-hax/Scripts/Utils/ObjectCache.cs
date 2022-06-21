using System;
using System.Collections;
using UnityEngine;

namespace RC15_HAX;

public class ObjectCache : ObjectCacheBase {
    public UnityEngine.Object Object { get; set; }
    Type ObjectType { get; }

    public ObjectCache(string componentName, float updateInterval = 2.0f) : base(updateInterval) {
        this.ObjectType = Global.GetRobocraftType(componentName);
        try {
            this.FindObject();
        }

        catch (Exception e) {
            Console.Print($"Unable to find object of type {this.TypeName()}:\n{e}");
        }
    }

    protected override string TypeName() => this.ObjectType.FullName;

    protected override void FindObject() => this.Object = GameObject.FindObjectOfType(this.ObjectType);
}

public class ObjectCache<T> : ObjectCacheBase where T : UnityEngine.Object {
    public T Object { get; set; }

    public ObjectCache(float updateInterval = 2.0f) : base(updateInterval) {
        this.FindObject();
    }

    protected override string TypeName() => typeof(T).FullName;

    protected override void FindObject() => this.Object = GameObject.FindObjectOfType<T>();
}