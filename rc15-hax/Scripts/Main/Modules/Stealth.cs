namespace RC15_HAX;
public class Stealth : HaxModules {
    bool StealthActivated { get; set; } = false;
    static T GetHaxModules<T>() where T : HaxModules => Loader.HaxModules.GetComponent<T>();
    static HaxModules[] ModulesToDisable => new HaxModules[] {
        GetHaxModules<NoCameraShake>(),
        GetHaxModules<NoFog>(),
        GetHaxModules<PlayerESP>(),
        GetHaxModules<WeaponMod>(),
        GetHaxModules<EnemyRadarMod>(),
    };

    protected override void OnEnable() {
        base.OnEnable();
        new ModCoroutine(this, this.ActivateStealth).Init(2.0f);
    }

    void Update() {
        this.ActivateStealth();
    }

    void ActivateStealth() {
        if (MenuOptions.EnableStealth != this.StealthActivated) return;
        this.SetModulesEnabled(!MenuOptions.EnableStealth);
    }

    void SetModulesEnabled(bool enabled) {
        Console.Print("Stealth setting detected.");
        this.StealthActivated = enabled;

        foreach (HaxModules module in Stealth.ModulesToDisable) {
            Console.Print($"Setting {module.GetType().Name} component to {enabled}.");
            module.enabled = enabled;
        }
    }
}