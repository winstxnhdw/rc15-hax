using Simulation;

namespace RC15_HAX;
public class TeslaMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableTeslaMod");

    void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.TeslaObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.TeslaObjects.StopLog();
    }

    void Update() {
        this.ModRotor();
    }

    void ModRotor() {
        if (!ModEnabled) return;

        foreach (CubeTeslaRam cubeTeslaRam in HaxObjects.TeslaObjects.Objects) {
            cubeTeslaRam.damage = HaxSettings.GetInt("TeslaDamage");
            float[] healthPercents = cubeTeslaRam.healthPercents;
            for (int i = 0; i < healthPercents.Length; i++) {
                healthPercents[i] = 9999999.9f;
            }

            cubeTeslaRam.healthPercents = healthPercents;
        }
    }
}