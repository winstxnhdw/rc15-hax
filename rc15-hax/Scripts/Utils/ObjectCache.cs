using System.Collections;
using UnityEngine;

namespace RC15_HAX;
class ObjectCache<T> where T : Object {
    float UpdateInterval { get; set; }
    bool StopCaching { get; set; } = false;
    public T[] Objects { get; set; } = new T[0];

    public ObjectCache(float updateInterval = 5.0f) {
        this.UpdateInterval = updateInterval;
    }

    IEnumerator ICacheObjects() {
        Console.Print("Caching object(s)..");

        while (true) {
            if (this.StopCaching) yield break;

            try {
                this.Objects = GameObject.FindObjectsOfType<T>();
            }

            catch {
                Console.Print($"Failed to cache {typeof(T).FullName} object(s)..");
            }

            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) => self.StartCoroutine(this.ICacheObjects());

    public void Stop() => this.StopCaching = !this.StopCaching;
}