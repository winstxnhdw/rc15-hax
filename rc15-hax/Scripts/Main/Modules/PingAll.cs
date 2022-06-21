using System.Linq;
using System.Collections;
using System.Collections.Generic;

using System.Collections.ObjectModel;
using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class PingAll : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePingAll"); }
    float PingAllInterval { get => HaxSettings.GetValue<float>("PingAllInterval"); }
    int teamId = 0;
    ReadOnlyCollection<int> EnemyIDs { get; set; }
    object SpotManager { get; set; }
    public static object playerteam;
    public static int playerId;

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        InputListener.onF4Press += () => {
            if (teamId == 0) {
                teamId = 1;
            }
            else {
                teamId = 0;
            }
        };

        base.OnEnable();
        // this.StartCoroutine(this.IPingAllEnemies());
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        // StopCoroutine(this.IPingAllEnemies());
    }

    void Update() {
        this.GetPlayerID();

    }

    void GetPlayerID() {
        this.SpotManager = new Reflector(FindObjectOfType<SpotCooldownDisplay>()).GetInternalProperty("spotManager");
        // object liveplayers = new Reflector(this.SpotManager).GetPublicProperty("livePlayersContainer");
        // Dictionary<TargetType, List<int>> dict = new Reflector(liveplayers).GetInternalField<Dictionary<TargetType, List<int>>>("_livePlayers");
        // Console.Print(dict[TargetType.Player]);
        PingAll.playerteam = new Reflector(this.SpotManager).GetPublicProperty("playerTeamsContainer");

        PingAll.playerId = new Reflector(PingAll.playerteam).GetInternalField<int>("_localPlayerId");
        Console.Print($"playerID: {PingAll.playerId}");
        Console.Print($"teamID: {teamId}");
        new Reflector(PingAll.playerteam).InvokePublicMethod("ChangePlayerTeam", new object[] { TargetType.Player, PingAll.playerId, teamId });
        // int playerTeamID = Global.InvokePublicMethod<int>(playerTeamsContainer, "GetPlayerTeam", new object[] { playerID });
        // this.EnemyIDs = Global.InvokePublicMethod<ReadOnlyCollection<int>>(playerTeamsContainer, "GetPlayersOnTeam", new object[] { TargetType.Player, playerTeamID == 0 ? 1 : 0 });
    }

    // IEnumerator IPingAllEnemies() {
    //     while (true) {
    //         // this.EnemyIDs.ToList().ForEach(enemyID => Global.InvokeInternalMethod<object>(this.SpotManager, "SendEnemySpotted", new object[] { enemyID }));
    //         // yield return new WaitForSeconds(this.PingAllInterval);
    //     }
    // }

}
