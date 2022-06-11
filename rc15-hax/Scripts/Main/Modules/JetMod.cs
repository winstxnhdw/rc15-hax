namespace RC15_HAX;
public class JetMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableJetMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        HaxObjects.CubeJetObjects.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.CubeJetObjects.StopLog();
    }

    void Update() {
        this.ModJet();
    }

    void ModJet() {
        if (!this.ModEnabled) return;

        foreach (CubeJet cubeJet in HaxObjects.CubeJetObjects.Objects) {
            cubeJet.ForceMagnitude = HaxSettings.GetValue<float>("ForceMagnitude");
        }
    }
}