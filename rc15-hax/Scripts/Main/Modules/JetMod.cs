namespace RC15_HAX;
public class JetMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableJetMod");

    void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.CubeJetObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.CubeJetObjects.Stop();
    }

    void Update() {
        this.ModJet();
    }

    void ModJet() {
        if (!ModEnabled) return;

        foreach (CubeJet cubeJet in HaxObjects.CubeJetObjects.Objects) {
            cubeJet.ForceMagnitude = HaxSettings.GetFloat("ForceMagnitude");
            cubeJet.MaxVelocity = HaxSettings.GetFloat("MaxVelocity");
        }
    }
}