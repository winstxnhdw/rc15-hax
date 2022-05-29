using UnityEngine;

namespace RC15_HAX;
public class HaxComponents : MonoBehaviour {
    void Start() {
        Console.Print($"{this.GetType().Name} loaded.");
    }
}