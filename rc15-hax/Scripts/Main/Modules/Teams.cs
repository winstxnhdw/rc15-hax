using System.Collections.ObjectModel;
using System.Collections.Generic;
using Simulation;
namespace RC15_HAX;
public class Teams : HaxModules {
    public static TargetType Player { get => TargetType.Player; }
    public static Reflector PlayerTeamsContainerReflection { get; set; }
    public static Reflector SpotManagerReflection { get; set; }

    public static int PlayerID { get; set; }
    public static int PlayerTeamID { get; set; }
    public static Dictionary<int, Dictionary<int, string>> AllPlayers { get; } = new Dictionary<int, Dictionary<int, string>>();

    public static object SpotManager { get; set; }
    public static object PlayerTeamsContainer { get; set; }
    public static object PlayerNamesContainer { get; set; }
    public static object LivePlayersContainer { get; set; }

    protected override void OnEnable() {
        base.OnEnable();

        this.GetSpotManager();
        this.GetPlayerContainers();
        this.GetPlayerInfo();
        this.GetPlayers();
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
        Teams.PlayerNamesContainer = Teams.SpotManagerReflection.GetPublicProperty("playerNamesContainer");
        Teams.LivePlayersContainer = Teams.SpotManagerReflection.GetPublicProperty("livePlayersContainer");
    }

    void GetPlayerInfo() {
        Teams.PlayerTeamsContainerReflection = new Reflector(Teams.PlayerTeamsContainer);
        Teams.PlayerID = Teams.PlayerTeamsContainerReflection.GetInternalField<int>("_localPlayerId");
        Teams.PlayerTeamID = Teams.PlayerTeamsContainerReflection.InvokePublicMethod<int>("GetPlayerTeam", Teams.Player, Teams.PlayerID);
    }

    void GetPlayers() {
        ReadOnlyCollection<int> blueTeam = Teams.PlayerTeamsContainerReflection.InvokePublicMethod<ReadOnlyCollection<int>>("GetPlayersOnTeam", Teams.Player, 0);
        ReadOnlyCollection<int> redTeam = Teams.PlayerTeamsContainerReflection.InvokePublicMethod<ReadOnlyCollection<int>>("GetPlayersOnTeam", Teams.Player, 1);

        Dictionary<int, string> blueTeamPlayers = new Dictionary<int, string>();
        Dictionary<int, string> redTeamPlayers = new Dictionary<int, string>();

        foreach (int player in blueTeam) {
            blueTeamPlayers.Add(player, new Reflector(Teams.PlayerNamesContainer).InvokePublicMethod<string>("GetPlayerName", player));
        }

        foreach (int player in redTeam) {
            redTeamPlayers.Add(player, new Reflector(Teams.PlayerNamesContainer).InvokePublicMethod<string>("GetPlayerName", player));
        }

        Teams.AllPlayers.Add(0, blueTeamPlayers);
        Teams.AllPlayers.Add(1, redTeamPlayers);
    }
}