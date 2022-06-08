using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class ObjectsCache<T> : ObjectCacheBase<T> where T : Object {
    public T[] Objects { get; set; }

    public ObjectsCache(float updateInterval = 5.0f) : base(updateInterval) {
        this.Objects = GameObject.FindObjectsOfType<T>();
    }

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {base.TypeName} object(s)..");
        this.StopCaching = false;

        while (true) {
            if (this.StopCaching) {
                this.StopLog();
                yield break;
            }

            this.Objects = GameObject.FindObjectsOfType<T>();
            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) => self.StartCoroutine(this.ICacheObjects());
}