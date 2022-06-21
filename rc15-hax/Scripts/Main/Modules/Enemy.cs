using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Enemy : HaxModules {
    public static Dictionary<int, Body> RigidbodyDict { get; } = new Dictionary<int, Body>();
    Dictionary<int, Body> PreviousRigidbodyDict { get; set; } = new Dictionary<int, Body>();
    int RigidBodyID { get; set; }

    protected override void OnEnable() {
        base.OnEnable();

        this.RigidBodyID = 0;
        HaxObjects.Rigidbodies.Init(this);
    }

    protected override void OnDisable() {
        base.OnDisable();

        this.PreviousRigidbodyDict.Clear();
        HaxObjects.Rigidbodies.Stop();
    }

    void FixedUpdate() {
        this.GetEnemyRigidbodies();
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