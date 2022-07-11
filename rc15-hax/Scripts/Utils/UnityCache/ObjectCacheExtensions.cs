using System;
using UnityObject = UnityEngine.Object;

namespace RC15_HAX;
public class ObjectCache : ObjectCacheBase {
    public UnityObject Object { get; set; }
    Type ObjectType { get; }

    public ObjectCache(string componentName, float updateInterval = 2.0f) : base(updateInterval) {
        this.ObjectType = Robocraft.GetType(componentName);
        this.FindObject();
    }

    protected override string TypeName() => this.ObjectType.FullName;

    protected override void FindObject() {
        this.Object = UnityObject.FindObjectOfType(this.ObjectType);
        if (this.Object == null) Console.Print($"Unable to find object of type {this.TypeName()}.");
    }
}