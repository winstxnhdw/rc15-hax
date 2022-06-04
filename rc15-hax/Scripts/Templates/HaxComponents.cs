using UnityEngine;

namespace RC15_HAX;
public class HaxComponents : MonoBehaviour {
    protected virtual void Start() {
        Console.Print($"{this.GetType().Name} loaded.");
    }
}