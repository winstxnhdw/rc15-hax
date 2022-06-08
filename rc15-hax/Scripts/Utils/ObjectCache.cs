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
        base.StopCaching = false;

        while (true) {
            if (base.StopCaching) {
                base.StopLog();
                yield break;
            }

            this.Object = GameObject.FindObjectOfType<T>();
            yield return new WaitForSeconds(base.UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) => self.StartCoroutine(this.ICacheObjects());
}