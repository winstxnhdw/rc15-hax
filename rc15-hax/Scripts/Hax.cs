using UnityEngine;

namespace RC15_HAX;
public class Hax : MonoBehaviour {
    void Update() {
        if (Input.GetKeyUp(KeyCode.F8)) {
            Settings.menuToggle = !Settings.menuToggle;
        }
    }
    void OnGUI() {
        // Make a background box
        if (!Settings.menuToggle) return;

        GUI.Box(new Rect(10, 10, 100, 90), "Hax Menu");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if (GUI.Button(new Rect(20, 40, 80, 20), "Disable fog")) {
            FindObjectOfType<GlobalFog>().startDistance = 99999999999f;
        }

        // Make the second button.
        if (GUI.Button(new Rect(20, 70, 80, 20), "Railgun no delay")) {
            // Simulation.RailGunWeaponManager
        }
    }
}
