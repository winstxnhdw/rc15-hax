namespace RC15_HAX;
public class Hax : HaxComponents {
    public static bool HaxPaused { get; private set; } = false;

    void Awake() {
        InputListener.onPausePress += this.ToggleHaxPause;
    }

    void Update() {
        if (Hax.HaxPaused || HaxObjects.PlayerRigidbody == null) {
            HaxSettings.ParseDefaultValues = true;
            Global.SetActiveGameObject(Loader.HaxModules, false);
            Global.SetActiveGameObject(Loader.HaxStealthModules, false);
            return;
        }

        else if (MenuOptions.EnableStealth) {
            HaxSettings.ParseDefaultValues = true;
            Global.SetActiveGameObject(Loader.HaxModules, false);
            Global.SetActiveGameObject(Loader.HaxStealthModules, true);
            return;
        }

        HaxSettings.ParseDefaultValues = false;
        Global.SetActiveGameObject(Loader.HaxModules, true);
        Global.SetActiveGameObject(Loader.HaxStealthModules, true);
    }

    void ToggleHaxPause() {
        Hax.HaxPaused = !Hax.HaxPaused;
        Console.Print("Hax paused!");
    }

    void OnDestroy() {
        InputListener.onPausePress -= this.ToggleHaxPause;
    }
}
