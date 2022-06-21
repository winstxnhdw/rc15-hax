using System;
using System.Collections;
using UnityEngine;

namespace RC15_HAX;

public class ObjectsCache : ObjectCacheBase {
    public UnityEngine.Object[] Objects { get; set; }
    Type ObjectType { get; }

    public ObjectsCache(string componentName, float updateInterval = 5.0f) : base(updateInterval) {
        this.ObjectType = Global.GetRobocraftType(componentName);

        try {
            this.FindObject();
        }

        catch (Exception e) {
            Console.Print($"Unable to find object of type {this.TypeName()}:\n{e}");
        }
    }

    protected override string TypeName() => this.ObjectType.FullName;

    protected override void FindObject() => this.Objects = GameObject.FindObjectsOfType(this.ObjectType);
}
public class ObjectsCache<T> : ObjectCacheBase where T : UnityEngine.Object {
    public T[] Objects { get; set; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.FindObject();
    }

    protected override string TypeName() => typeof(T).FullName;

    protected override void FindObject() => this.Objects = GameObject.FindObjectsOfType<T>();
}