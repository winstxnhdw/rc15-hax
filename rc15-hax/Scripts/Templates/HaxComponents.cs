using UnityEngine;

namespace RC15_HAX;
public class HaxComponents : MonoBehaviour {
    protected virtual void OnEnable() {
        Console.Print($"{this.GetType().Name} component enabled.");
    }

    protected virtual void OnDisable() {
        Console.Print($"{this.GetType().Name} component disabled.");
    }

    protected virtual void Start() {
        Console.Print($"{this.GetType().Name} loaded.");
    }
}