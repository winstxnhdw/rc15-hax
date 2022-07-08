using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Enemy : HaxModules {
    public static int EnemyTeamID { get; private set; }
    public static List<int> EnemyIndexList { get; private set; }
    public static Dictionary<int, Body> RigidbodyDict { get; } = new Dictionary<int, Body>();

    Dictionary<int, Body> PreviousRigidbodyDict { get; set; } = new Dictionary<int, Body>();
    int RigidBodyID { get; set; }


    protected override void OnEnable() {
        base.OnEnable();

        InputListener.onF6Press += this.MakeAllEnemiesFire;
        this.RigidBodyID = 0;
        ModCoroutine.Create(this, this.GetAllEnemyID).Init(1.0f);
        HaxObjects.Rigidbodies.Init(this);
    }

    protected override void OnDisable() {
        base.OnDisable();

        InputListener.onF6Press -= this.MakeAllEnemiesFire;
        this.PreviousRigidbodyDict.Clear();
        HaxObjects.Rigidbodies.Stop();
    }

    void FixedUpdate() {
        this.GetEnemyRigidbodies();
    }

    void MakeAllEnemiesFire() {
        foreach (Body body in Enemy.RigidbodyDict.Values) {
            foreach (Object baseWeapon in Robocraft.GetComponentsInChildren(body.Rigidbody, "BaseWeapon")) {
                try {
                    Reflector.Target(baseWeapon)
                             .GetInternalProperty("weapon")
                             .InvokeInternalMethod("FireWeapon");
                }

                catch (System.Exception e) {
                    Console.Print($"Weapon {baseWeapon.name} cannot be forced to fire.\n{e}");
                }
            }
        }
    }

    void GetAllEnemyID() {
        if (Teams.PlayerTeamsContainerReflection == null) return;

        Enemy.EnemyTeamID = Teams.PlayerTeamID == 0 ? 1 : 0;
        Enemy.EnemyIndexList = Teams.PlayerTeamsContainerReflection
                                    .InvokePublicMethod<List<int>>("GetPlayersOnEnemyTeam", Teams.Player);
    }

    void GetEnemyRigidbodies() {
        Enemy.RigidbodyDict.Clear();

        foreach (Rigidbody rigidbody in HaxObjects.Rigidbodies.Objects) {
            if (rigidbody == null) continue;
            if (rigidbody.gameObject.layer != 0) continue;
            if (rigidbody.name == HaxObjects.PlayerRigidbody.name) continue;

            int rigidbodyInstanceID = rigidbody.GetInstanceID();
            Body currentBody;

            if (this.PreviousRigidbodyDict.TryGetValue(rigidbodyInstanceID, out Body body)) {
                currentBody = new Body(body, rigidbody);
            }

            else {
                currentBody = new Body(this.RigidBodyID, rigidbody, Time.fixedDeltaTime);
                this.RigidBodyID++;
            }

            this.PreviousRigidbodyDict[rigidbodyInstanceID] = currentBody;
            Enemy.RigidbodyDict.Add(rigidbodyInstanceID, currentBody);
        }
    }
}