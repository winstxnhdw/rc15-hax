using System.Collections.ObjectModel;
using System.Collections.Generic;
using Simulation;
namespace RC15_HAX;
public class Teams : HaxModules {
    const int blueTeamId = 0;
    const int redTeamId = 1;

    public static TargetType Player => TargetType.Player;
    public static Reflector PlayerTeamsContainerReflection { get; private set; }
    public static Reflector PlayerNamesContainerReflection { get; private set; }
    public static Reflector SpotManagerReflection { get; set; }

    public static int PlayerID { get; private set; }
    public static int PlayerTeamID { get; private set; }
    public static Dictionary<int, Dictionary<int, string>> AllPlayers { get; } = new Dictionary<int, Dictionary<int, string>>();

    public static object SpotManager { get; private set; }
    public static object PlayerTeamsContainer { get; private set; }
    public static object PlayerNamesContainer { get; private set; }
    public static object LivePlayersContainer { get; private set; }

    protected override void OnEnable() {
        base.OnEnable();

        this.GetSpotManager();
        this.GetPlayerContainers();
        this.GetPlayerNames();
        new ModCoroutine(this, this.GetPlayerInfo).Init(2.0f);
        new ModCoroutine(this, this.GetPlayers).Init(2.0f);
    }

    protected override void OnDisable() {
        base.OnDisable();
        HaxObjects.Rigidbodies.Stop();
    }

    void GetSpotManager() {
        Teams.SpotManager = new Reflector(FindObjectOfType<SpotCooldownDisplay>()).GetInternalProperty("spotManager");
    }

    void GetPlayerContainers() {
        Teams.SpotManagerReflection = new Reflector(Teams.SpotManager);
        Teams.PlayerTeamsContainer = Teams.SpotManagerReflection.GetPublicProperty("playerTeamsContainer");
        Teams.PlayerTeamsContainerReflection = new Reflector(Teams.PlayerTeamsContainer);
        Teams.LivePlayersContainer = Teams.SpotManagerReflection.GetPublicProperty("livePlayersContainer");
    }

    void GetPlayerInfo() {
        Teams.PlayerID = Teams.PlayerTeamsContainerReflection.GetInternalField<int>("_localPlayerId");
        Teams.PlayerTeamID = Teams.PlayerTeamsContainerReflection.InvokePublicMethod<int>("GetPlayerTeam", Teams.Player, Teams.PlayerID);
    }

    void GetPlayerNames() {
        Teams.PlayerNamesContainer = Teams.SpotManagerReflection.GetPublicProperty("playerNamesContainer");
        Teams.PlayerNamesContainerReflection = new Reflector(Teams.PlayerNamesContainer);
    }

    void GetPlayers() {
        Teams.AllPlayers.Clear();
        Dictionary<int, string> blueTeamPlayers = new Dictionary<int, string>();
        Dictionary<int, string> redTeamPlayers = new Dictionary<int, string>();

        foreach (int player in Teams.PlayerTeamsContainerReflection.InvokePublicMethod<ReadOnlyCollection<int>>("GetPlayersOnTeam", Teams.Player, Teams.blueTeamId)) {
            blueTeamPlayers.Add(player, Teams.PlayerNamesContainerReflection.InvokePublicMethod<string>("GetPlayerName", player));
        }

        foreach (int player in Teams.PlayerTeamsContainerReflection.InvokePublicMethod<ReadOnlyCollection<int>>("GetPlayersOnTeam", Teams.Player, Teams.redTeamId)) {
            redTeamPlayers.Add(player, Teams.PlayerNamesContainerReflection.InvokePublicMethod<string>("GetPlayerName", player));
        }

        Teams.AllPlayers.Add(blueTeamId, blueTeamPlayers);
        Teams.AllPlayers.Add(redTeamId, redTeamPlayers);
    }
}