using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class Voodoo : HaxModules {
    static Voodoo Instance { get; set; }
    float VoodooForwardOffset => HaxSettings.GetValue<float>("VoodooForwardOffset");
    public bool IsDoingBlackMagic { get; set; } = false;
    public int CycleIndex { get; set; } = 0;
    public List<Body> VoodooBodies { get; set; } = new List<Body>(Enemy.RigidbodyDict.Values);
    public Vector3 SpawnPoint { get; set; } = Vector3.zero;
    public Vector3 CameraForwardSpawnPoint { get; set; } = Vector3.zero;

    void Awake() {
        Voodoo.Instance = this;
    }

    public static Voodoo GetVoodoo() {
        return Voodoo.Instance;
    }

    protected override void OnEnable() {
        base.OnEnable();
        InputListener.onF7Press += this.ToggleVoodoo;
    }

    protected override void OnDisable() {
        base.OnDisable();
        InputListener.onF7Press -= this.ToggleVoodoo;
        this.DestroyVoodooInstance();
        this.IsDoingBlackMagic = false;
        this.CycleIndex = 0;
    }

    void ToggleVoodoo() {
        this.IsDoingBlackMagic = !this.IsDoingBlackMagic;
        this.VoodooBodies = new List<Body>(Enemy.RigidbodyDict.Values);
        this.SpawnPoint = HaxObjects.PlayerRigidbody.worldCenterOfMass;
        this.CameraForwardSpawnPoint = Global.Camera.transform.forward * this.VoodooForwardOffset;

        if (!this.IsDoingBlackMagic) {
            this.CycleIndex++;
            this.DestroyVoodooInstance();
        }

        else {
            Loader.HaxModules.AddComponent<VoodooInstance>();
        }
    }

    void DestroyVoodooInstance() {
        VoodooInstance voodooInstance = Loader.HaxModules.GetComponent<VoodooInstance>();
        Destroy(voodooInstance);
    }
}

public class VoodooInstance : MonoBehaviour {
    Voodoo Voodoo { get; set; }

    void OnEnable() {
        this.Voodoo = Voodoo.GetVoodoo();
    }

    void Update() {
        this.SummonVoodoo();
    }

    void FixedUpdate() {
        this.SummonVoodoo();
    }

    void SummonVoodoo() {
        if (!Voodoo.IsDoingBlackMagic) return;

        Rigidbody rigidbody = Voodoo.VoodooBodies[Voodoo.CycleIndex % Voodoo.VoodooBodies.Count].Rigidbody;
        Transform rigidbodyT = rigidbody.transform;
        Transform simulationBoardT = rigidbodyT.parent;
        Vector3 desiredPosition = Voodoo.SpawnPoint + Voodoo.CameraForwardSpawnPoint;

        rigidbodyT.position = desiredPosition;
        rigidbodyT.localRotation = Quaternion.identity;
        simulationBoardT.position = desiredPosition;
    }
}