using System.Collections.ObjectModel;
using System.Collections.Generic;
using Simulation;
namespace Hax;
public class Teams : HaxModules {
    const int BlueTeamID = 0;
    const int RedTeamID = 1;

    public const TargetType Player = TargetType.Player;
    public static Reflector PlayerTeamsContainerReflection { get; private set; }
    public static Reflector PlayerNamesContainerReflection { get; private set; }
    public static Reflector LivePlayersContainerReflection { get; private set; }
    public static Reflector SpotManagerReflection { get; set; }

    public static int PlayerID { get; private set; }
    public static int PlayerTeamID { get; private set; }
    public static Dictionary<int, Dictionary<int, string>> AllPlayers { get; } = new Dictionary<int, Dictionary<int, string>>();

    protected override void OnEnable() {
        base.OnEnable();

        this.GetSpotManager();
        this.GetPlayerContainers();
        this.GetPlayerNames();
        ModCoroutine.Create(this, this.GetPlayerInfo).Init(2.0f);
        ModCoroutine.Create(this, this.GetPlayers).Init(2.0f);
    }

    protected override void OnDisable() {
        base.OnDisable();
        HaxObjects.Rigidbodies.Stop();
    }

    ReadOnlyCollection<int> GetPlayersOnTeam(int teamID) =>
        Teams.PlayerTeamsContainerReflection.InvokePublicMethod<ReadOnlyCollection<int>>("GetPlayersOnTeam", Teams.Player, teamID);

    void GetSpotManager() {
        Teams.SpotManagerReflection = Reflector.Target(FindObjectOfType<SpotCooldownDisplay>())
                                               .GetInternalProperty("spotManager");
    }

    void GetPlayerContainers() {
        Teams.PlayerTeamsContainerReflection = Teams.SpotManagerReflection.GetPublicProperty("playerTeamsContainer");
        Teams.LivePlayersContainerReflection = Teams.SpotManagerReflection.GetPublicProperty("livePlayersContainer");
    }

    void GetPlayerInfo() {
        Teams.PlayerID = Teams.PlayerTeamsContainerReflection.GetInternalField<int>("_localPlayerId");
        Teams.PlayerTeamID = Teams.PlayerTeamsContainerReflection.InvokePublicMethod<int>("GetPlayerTeam", Teams.Player, Teams.PlayerID);
    }

    void GetPlayerNames() {
        Teams.PlayerNamesContainerReflection = Teams.SpotManagerReflection.GetPublicProperty("playerNamesContainer");
    }

    void GetPlayers() {
        Teams.AllPlayers.Clear();
        Dictionary<int, string> blueTeamPlayers = new Dictionary<int, string>();
        Dictionary<int, string> redTeamPlayers = new Dictionary<int, string>();

        foreach (int player in this.GetPlayersOnTeam(Teams.BlueTeamID)) {
            blueTeamPlayers.Add(player, Teams.PlayerNamesContainerReflection.InvokePublicMethod<string>("GetPlayerName", player));
        }

        foreach (int player in this.GetPlayersOnTeam(Teams.RedTeamID)) {
            redTeamPlayers.Add(player, Teams.PlayerNamesContainerReflection.InvokePublicMethod<string>("GetPlayerName", player));
        }

        Teams.AllPlayers.Add(BlueTeamID, blueTeamPlayers);
        Teams.AllPlayers.Add(RedTeamID, redTeamPlayers);
    }
}