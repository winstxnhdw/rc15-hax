using Simulation;

namespace RC15_HAX;
public class Teams : HaxModules {
    public static TargetType Player { get => TargetType.Player; }
    public static Reflector PlayerTeamsContainerReflection { get; set; }
    public static Reflector SpotManagerReflection { get; set; }

    public static int PlayerID { get; set; }

    public static object SpotManager { get; set; }
    public static object PlayerTeamsContainer { get; set; }

    protected override void OnEnable() {
        base.OnEnable();

        this.GetSpotManager();
        this.GetPlayerTeamsContainer();
        this.GetPlayerID();
    }

    protected override void OnDisable() {
        base.OnDisable();
        HaxObjects.Rigidbodies.Stop();
    }

    void GetSpotManager() {
        Teams.SpotManager = new Reflector(FindObjectOfType<SpotCooldownDisplay>()).GetInternalProperty("spotManager");
    }

    void GetPlayerTeamsContainer() {
        Teams.SpotManagerReflection = new Reflector(Teams.SpotManager);
        Teams.PlayerTeamsContainer = Teams.SpotManagerReflection.GetPublicProperty("playerTeamsContainer");
    }

    void GetPlayerID() {
        Teams.PlayerTeamsContainerReflection = new Reflector(Teams.PlayerTeamsContainer);
        Teams.PlayerID = Teams.PlayerTeamsContainerReflection.GetInternalField<int>("_localPlayerId");
    }
}