using System.Collections;
using UnityEngine;

namespace Hax;
public class ObjectCacheBase {
    protected float UpdateInterval { get; }
    protected MonoBehaviour Self { get; set; }
    protected bool StopCaching { get; set; }

    public ObjectCacheBase(float updateInterval) {
        this.UpdateInterval = updateInterval;
    }

    protected virtual string TypeName() => "";

    protected virtual void FindObject() { }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {this.TypeName()} object(s)..");

        while (true) {
            this.FindObject();
            yield return new WaitForSeconds(this.UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) {
        this.Self = self;
        this.Self.StartCoroutine(this.ICacheObjects());
    }

    public void Stop() {
        this.Self.StopCoroutine(this.ICacheObjects());
        Console.Print($"Stopping cache for {this.TypeName()} object(s).");
    }
}