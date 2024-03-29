namespace Hax;
public class SelfDestruct : HaxModules {
    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onF12Press += this.DestructSelf;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onF12Press += this.DestructSelf;
    }

    void DestructSelf() {
        Teams.SpotManagerReflection.GetInternalProperty("destructionReporter")
                                   .InvokeInternalMethod("BroadcastDeath", Teams.PlayerID, Teams.PlayerID, true, Teams.Player);
    }
}