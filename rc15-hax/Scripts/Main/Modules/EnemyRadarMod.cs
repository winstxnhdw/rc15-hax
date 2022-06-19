namespace RC15_HAX;
public class EnemyRadarMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableEnemyRadarMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
    }

    void LateUpdate() {
        this.ModEnemyRadar();
    }

    void ModEnemyRadar() {
        if (!this.ModEnabled) return;

        foreach (CubeEnemyRadar enemyRadar in HaxObjects.PlayerRigidbody.gameObject.GetComponentsInChildren<CubeEnemyRadar>()) {
            Global.SetInternalFieldValue(enemyRadar, "_lastTargetCheck", 31);
            Global.SetInternalFieldValue(enemyRadar, "_range", float.MaxValue);
            Global.SetInternalFieldValue(enemyRadar, "antiJammerPower", float.MaxValue);
        }
    }
}