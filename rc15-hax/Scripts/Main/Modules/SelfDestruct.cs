namespace RC15_HAX;
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
        object destructionReporter = Teams.SpotManagerReflection.GetInternalProperty("destructionReporter");
        new Reflector(destructionReporter).InvokeInternalMethod<object>("BroadcastDeath", Teams.PlayerID, Teams.PlayerID, true, Teams.Player);
    }
}