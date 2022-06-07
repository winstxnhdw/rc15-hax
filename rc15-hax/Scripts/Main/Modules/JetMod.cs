namespace RC15_HAX;
public class JetMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableJetMod");

    protected override void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.CubeJetObjects.Init(this);
    }

    protected override void OnDisable() {
        HaxObjects.CubeJetObjects.StopLog();
    }

    void Update() {
        this.ModJet();
    }

    void ModJet() {
        if (!ModEnabled) return;

        foreach (CubeJet cubeJet in HaxObjects.CubeJetObjects.Objects) {
            cubeJet.ForceMagnitude = HaxSettings.GetFloat("ForceMagnitude");
        }
    }
}