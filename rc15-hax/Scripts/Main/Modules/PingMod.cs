namespace RC15_HAX;
public class PingMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnablePingMod");
    bool EnablePingAll => HaxSettings.GetValue<bool>("EnablePingAll");
    float PingAllInterval => HaxSettings.GetValue<float>("PingAllInterval");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        ModCoroutine.Create(this, this.ModPing).Init(5.0f);

        if (!this.EnablePingAll) return;
        ModCoroutine.Create(this, this.PingAllEnemies).Init(this.PingAllInterval);
    }

    void ModPing() {
        if (Teams.SpotManagerReflection == null) return;

        Teams.SpotManagerReflection.SetInternalField("_playerLastFailedSpotAttempt", -float.MaxValue)
                                   .SetInternalField("_playerLastSpotAttempt", -float.MaxValue);
    }

    void PingAllEnemies() {
        if (Enemy.EnemyIndexList == null || Teams.SpotManagerReflection == null) return;
        Enemy.EnemyIndexList.ForEach(enemy => Teams.SpotManagerReflection.InvokeInternalMethod<object>("SendEnemySpotted", enemy));
    }
}