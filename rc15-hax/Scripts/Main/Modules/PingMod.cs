namespace RC15_HAX;
public class PingMod : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePingMod"); }
    bool EnablePingAll { get => HaxSettings.GetValue<bool>("EnablePingAll"); }

    float PingAllInterval { get => HaxSettings.GetValue<float>("PingAllInterval"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModPing).Init(5.0f);

        if (!this.EnablePingAll) return;
        new ModCoroutine(this, this.PingAllEnemies).Init(this.PingAllInterval);
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