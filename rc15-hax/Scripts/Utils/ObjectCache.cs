using System.Collections;
using UnityEngine;

namespace RC15_HAX;
public class ObjectCache<T> where T : Object {
    float UpdateInterval { get; set; }
    bool StopCaching { get; set; } = false;
    public T[] Objects { get; set; } = new T[0];

    public ObjectCache(float updateInterval = 5.0f) => this.UpdateInterval = updateInterval;

    IEnumerator ICacheObjects() {
        Console.Print($"Caching {typeof(T).FullName} object(s)..");
        this.StopCaching = true;

        while (true) {
            if (this.StopCaching) yield break;
            this.Objects = GameObject.FindObjectsOfType<T>();
            yield return new WaitForSeconds(UpdateInterval);
        }
    }

    public void Init(MonoBehaviour self) => self.StartCoroutine(this.ICacheObjects());

    public void Stop() => this.StopCaching = false;
}