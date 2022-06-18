using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class TeslaMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableTeslaMod"); }
    bool UsingTeslaField { get; set; } = false;
    float TeslaFieldOffset { get => Global.twoPi / TeslaBladeTransformList.Count; }
    float TeslaFieldRadius { get => 7.0f; }

    List<Transform> TeslaBladeTransformList { get; } = new List<Transform>();

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        InputListener.onF5Press += this.ToggleTeslaField;
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        InputListener.onF5Press -= this.ToggleTeslaField;
    }

    void Update() {
        this.ModTesla();
    }

    void ModTesla() {
        if (!this.ModEnabled) return;
        this.TeslaBladeTransformList.Clear();

        foreach (Collider collider in HaxObjects.PlayerRigidbody.gameObject.GetComponentsInChildren<Collider>()) {
            string colliderName = collider.transform.name;

            if (colliderName == "blade" || colliderName.StartsWith("CollisionArm")) {
                collider.enabled = false;
            }

            if (colliderName == "blade1Collision" && this.UsingTeslaField) {
                this.TeslaBladeTransformList.Add(collider.transform.parent.parent);
            }
        }
    }

    IEnumerator ITeslaField() {
        Rigidbody playerBody = HaxObjects.PlayerRigidbody;
        Transform cameraT = Global.Camera.transform;
        float teslaRendererOffset = 0.5f;

        while (true) {
            for (int i = 0; i < this.TeslaBladeTransformList.Count; i++) {
                float teslaTimer = Time.time + (this.TeslaFieldOffset * i);
                Vector3 pointAlongCircle = new Vector3(this.TeslaFieldRadius * Mathf.Cos(teslaTimer * Global.twoPi), 0, this.TeslaFieldRadius * Mathf.Sin(teslaTimer * Global.twoPi));
                Vector3 teslaPosition = playerBody.transform.InverseTransformPoint(playerBody.worldCenterOfMass) + Quaternion.Euler(0, 0, teslaTimer * 90.0f) * pointAlongCircle;

                Transform teslaBladeT = this.TeslaBladeTransformList[i];
                teslaBladeT.localScale = new Vector3(3, 3, 20);
                teslaBladeT.up = teslaBladeT.position - playerBody.worldCenterOfMass;
                teslaBladeT.localPosition = teslaPosition;

                Transform teslaRendererT = teslaBladeT.GetChild(0);
                teslaRendererT.localScale = new Vector3(0.11f, 0.11f, 1.0f / 60.0f) * 0.25f;
                teslaRendererT.position = cameraT.up * 5f + (playerBody.worldCenterOfMass + cameraT.forward * 7.5f) + cameraT.right * ((-this.TeslaBladeTransformList.Count / 2.0f + (i * 1)) * teslaRendererOffset);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    void ToggleTeslaField() {
        this.UsingTeslaField = !this.UsingTeslaField;
        StartCoroutine(this.ITeslaField());

        if (!this.UsingTeslaField) StopCoroutine(this.ITeslaField());
    }
}