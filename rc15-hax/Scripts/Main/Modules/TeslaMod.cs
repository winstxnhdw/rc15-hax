using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class TeslaMod : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableTeslaMod"); }
    bool UsingTeslaField { get; set; } = false;
    bool RenderTeslaField { get; set; } = false;
    int TeslaFieldStateIndex { get; set; } = 0;
    float TeslaFieldOffset { get => Global.twoPi / TeslaBladeTransformList.Count; }
    float TeslaFieldRadius { get => HaxSettings.GetValue<float>("TeslaFieldRadius"); }
    float TeslaFieldRate { get => HaxSettings.GetValue<float>("TeslaFieldRate"); }
    float TeslaRendererOffset { get => HaxSettings.GetValue<float>("TeslaRendererOffset"); }

    List<Transform> TeslaBladeTransformList { get; } = new List<Transform>();

    string[] TeslaFieldStates {
        get => new string[] {
            "Enabled",
            "Render",
            "Disabled"
        };
    }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModTesla).Init(2.0f);
        InputListener.onF5Press += this.CycleTeslaFieldStates;
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        InputListener.onF5Press -= this.CycleTeslaFieldStates;
    }

    void Update() {
        this.NoCollisionTesla();
    }

    void ModTesla() {
        foreach (CubeTeslaRam teslaRam in HaxObjects.PlayerRigidbody.GetComponentsInChildren<CubeTeslaRam>()) {
            object internalTesla = new Reflector(teslaRam).GetInternalProperty("internalTeslaRam");
            new Reflector(internalTesla).SetInternalField("_damage", HaxSettings.GetValue<int>("TeslaDamage"))
                                        .SetInternalField("_selfDamage", HaxSettings.GetValue<int>("TeslaSelfDamage"));
        }
    }

    void NoCollisionTesla() {
        if (!this.ModEnabled) return;

        this.TeslaBladeTransformList.Clear();
        foreach (Collider collider in HaxObjects.PlayerRigidbody.GetComponentsInChildren<Collider>()) {
            string colliderName = collider.transform.name;
            if (colliderName.StartsWith("CollisionArm")) {
                collider.enabled = false;
            }

            if (colliderName == "blade1Collision" && this.UsingTeslaField) {
                this.TeslaBladeTransformList.Add(collider.transform.parent.parent);
            }
        }
    }

    void TeslaShark() {
        int maxTeslaPerRow = 10;
        int teslaRows = (int)Mathf.Ceil(TeslaBladeTransformList.Count / maxTeslaPerRow);

        for (int i = 0; i < this.TeslaBladeTransformList.Count; i++) {

        }
    }

    IEnumerator ITeslaField() {
        Rigidbody playerBody = HaxObjects.PlayerRigidbody;
        Transform cameraT = Global.Camera.transform;

        while (true) {
            for (int i = 0; i < this.TeslaBladeTransformList.Count; i++) {
                float teslaTimer = Time.time + (this.TeslaFieldOffset * i);
                Vector3 pointAlongCircle = new Vector3(this.TeslaFieldRadius * Mathf.Cos(teslaTimer * Global.twoPi), 0, this.TeslaFieldRadius * Mathf.Sin(teslaTimer * Global.twoPi));
                Vector3 teslaPosition = playerBody.transform.InverseTransformPoint(playerBody.worldCenterOfMass) + Quaternion.Euler(0, 0, teslaTimer * 90.0f) * pointAlongCircle;

                Transform teslaBladeT = this.TeslaBladeTransformList[i];
                teslaBladeT.localScale = new Vector3(3, 3, 20);
                teslaBladeT.up = teslaBladeT.position - playerBody.worldCenterOfMass;
                teslaBladeT.localPosition = teslaPosition;

                if (!this.RenderTeslaField) continue;
                Transform teslaRendererT = teslaBladeT.GetChild(0);
                teslaRendererT.localScale = new Vector3(0.11f, 0.11f, 1.0f / 60.0f) * 0.25f;
                teslaRendererT.position = cameraT.up * 5f + (playerBody.worldCenterOfMass + cameraT.forward * 7.5f) + cameraT.right * ((-this.TeslaBladeTransformList.Count / 2.0f + (i * 1.0f)) * this.TeslaRendererOffset);
            }

            yield return new WaitForSeconds(this.TeslaFieldRate);
        }
    }

    void CycleTeslaFieldStates() {
        switch (this.TeslaFieldStates[this.TeslaFieldStateIndex % this.TeslaFieldStates.Length]) {
            case "Enabled":
                this.RenderTeslaField = false;
                this.UsingTeslaField = true;
                StartCoroutine(this.ITeslaField());
                break;

            case "Render":
                this.RenderTeslaField = true;
                break;

            case "Disabled":
                this.UsingTeslaField = false;
                StopCoroutine(this.ITeslaField());
                break;
        }

        this.TeslaFieldStateIndex++;
    }
}