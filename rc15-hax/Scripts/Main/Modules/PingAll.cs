using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class PingAll : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePingAll"); }
    float PingAllInterval { get => HaxSettings.GetValue<float>("PingAllInterval"); }

    ReadOnlyCollection<int> EnemyIDs { get; set; }
    object SpotManager { get; set; }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.GetPlayerID();
        this.StartCoroutine(this.IPingAllEnemies());
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        StopCoroutine(this.IPingAllEnemies());
    }

    void GetPlayerID() {
        // this.SpotManager = Global.GetInternalProperty(FindObjectOfType<SpotCooldownDisplay>(), "spotManager");
        // object playerTeamsContainer = Global.GetPublicProperty(this.SpotManager, "playerTeamsContainer");
        // int playerID = Global.GetInternalField<int>(playerTeamsContainer, "_localPlayerId");
        // int playerTeamID = Global.InvokePublicMethod<int>(playerTeamsContainer, "GetPlayerTeam", new object[] { playerID });
        // this.EnemyIDs = Global.InvokePublicMethod<ReadOnlyCollection<int>>(playerTeamsContainer, "GetPlayersOnTeam", new object[] { TargetType.Player, playerTeamID == 0 ? 1 : 0 });
    }

    IEnumerator IPingAllEnemies() {
        while (true) {
            // this.EnemyIDs.ToList().ForEach(enemyID => Global.InvokeInternalMethod<object>(this.SpotManager, "SendEnemySpotted", new object[] { enemyID }));
            // yield return new WaitForSeconds(this.PingAllInterval);
        }
    }

}
