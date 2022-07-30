using UnityEngine;

namespace Hax;
public class HaxComponents : MonoBehaviour {
    protected virtual void Start() {
        Console.Print($"{this.GetType().Name} started.");
    }
}