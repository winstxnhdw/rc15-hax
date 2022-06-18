using UnityEngine;

namespace RC15_HAX;
public class Hax : HaxComponents {
    public static bool HaxPaused { get; set; } = false;

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
    }

    void Update() {
        if (Hax.HaxPaused || HaxObjects.PlayerRigidbody == null) {
            HaxSettings.ParseDefaultValues = true;
            SetActiveGameObject(Loader.HaxModules, false);
            return;
        }

        HaxSettings.ParseDefaultValues = false;
        SetActiveGameObject(Loader.HaxModules, true);
    }

    void SetActiveGameObject(GameObject go, bool isActive) {
        if (go.activeSelf == isActive) return;
        go.SetActive(isActive);
    }

    void ToggleHaxPause() {
        Hax.HaxPaused = !Hax.HaxPaused;
        Console.Print("Hax paused!");
    }

    void OnDestroy() {
        InputListener.onPausePress -= this.ToggleHaxPause;
    }
}
