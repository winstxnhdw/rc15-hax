using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class ObjectCache<T> where T : Object {
    float UpdateInterval { get; set; }
    bool StopCaching { get; set; }
    public T[] Objects { get; set; } = new T[0];
    public string TypeName { get; } = typeof(T).FullName;

    public ObjectCache(float updateInterval = 5.0f) => this.UpdateInterval = updateInterval;

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {this.TypeName} object(s)..");
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

    public void StopLog() => Console.Print($"Stopping cache for {this.TypeName} object(s).");

    public void Init(MonoBehaviour self) => self.StartCoroutine(this.ICacheObjects());

    public void Stop() => this.StopCaching = true;
}