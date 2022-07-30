namespace Hax;
public class EnemyRadarMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnableEnemyRadarMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        ModCoroutine.Create(this, this.ModEnemyRadar).Init();
    }

    void ModEnemyRadar() {
        if (!this.ModEnabled) return;

        foreach (CubeEnemyRadar enemyRadar in HaxObjects.PlayerRigidbody.gameObject.GetComponentsInChildren<CubeEnemyRadar>()) {
            Reflector.Target(enemyRadar)
                     .SetInternalField("_lastTargetCheck", 31)
                     .SetInternalField("_range", HaxSettings.GetValue<float>("EnemyRadarRange"))
                     .SetPublicField("antiJammerPower", HaxSettings.GetValue<float>("antiJammerPower"));
        }
    }
}