using UnityEngine;

namespace RC15_HAX;
public class Hax : MonoBehaviour {
    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 40), "This is a very useful cheat");
    }
}
