using System;
using UnityObject = UnityEngine.Object;

namespace RC15_HAX;

public class ObjectsCache : ObjectCacheBase {
    public UnityObject[] Objects { get; set; }
    Type ObjectType { get; }

    public ObjectsCache(string componentName, float updateInterval = 5.0f) : base(updateInterval) {
        this.ObjectType = Robocraft.GetType(componentName);
        this.FindObject();
    }

    protected override string TypeName() => this.ObjectType.FullName;

    protected override void FindObject() {
        this.Objects = UnityObject.FindObjectsOfType(this.ObjectType);
        if (this.Objects == null) Console.Print($"Unable to find object of type {this.TypeName()}.");
    }
}

public class ObjectsCache<T> : ObjectCacheBase where T : UnityObject {
    public T[] Objects { get; set; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.FindObject();
    }

    protected override string TypeName() => typeof(T).FullName;

    protected override void FindObject() => this.Objects = UnityObject.FindObjectsOfType<T>();
}