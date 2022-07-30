using System;
using UnityObject = UnityEngine.Object;

namespace Hax;
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