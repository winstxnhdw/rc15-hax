using System;
using System.Reflection;
using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class Hax : MonoBehaviour {
    Rect windowRect;

    void Awake() {
        this.windowRect = this.GetWindowRect(1000, 1000);
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Pause)) Loader.Unload();

        if (Input.GetKey(KeyCode.Space)) {
            if (Input.GetKeyUp(KeyCode.Escape)) Settings.menuToggle = !Settings.menuToggle;
        }

    }

    void OnGUI() {
        if (!Settings.menuToggle) return;
        GUI.Window(0, this.windowRect, this.RenderWindow, "Hax Menu");
    }

    void ToggleNoRecoil() {
        foreach (UnityEngine.Object weapon in FindObjectsOfType<BaseWeapon>()) {
            BaseWeapon? currentWeapon = weapon as BaseWeapon;
            if (currentWeapon == null) continue;

            currentWeapon.WeaponStats.RecoilForce = 0.0f;
        }
    }

    void ToggleMaxAccurancy() {
        foreach (UnityEngine.Object weapon in FindObjectsOfType<BaseWeapon>()) {
            BaseWeapon? currentWeapon = weapon as BaseWeapon;
            if (currentWeapon == null) continue;

            currentWeapon.Accuracy.BaseInAccuracyDegrees = 0.0f;
            currentWeapon.Accuracy.MovementInAccuracyDegrees = 0.0f;
            currentWeapon.Accuracy.RepeatFireInAccuracyTotalDegrees = 0.0f;
            currentWeapon.Accuracy.FireInstantAccuracyDecayDegrees = 0.0f;
        }
    }

    void ToggleMaxROM() {
        foreach (UnityEngine.Object weapon in FindObjectsOfType<BaseWeapon>()) {
            BaseWeapon? currentWeapon = weapon as BaseWeapon;
            if (currentWeapon == null) continue;

            currentWeapon.MoveLimits.MaxHorizAngle = 180.0f;
            currentWeapon.MoveLimits.MinHorizAngle = -180.0f;
            currentWeapon.MoveLimits.MaxVerticalAngle = 180.0f;
            currentWeapon.MoveLimits.MinVerticalAngle = -180.0f;
        }
    }

    void ToggleDeathLaser() {
        foreach (UnityEngine.Object weapon in FindObjectsOfType<BaseWeapon>()) {
            BaseWeapon? currentWeapon = weapon as BaseWeapon;
            if (currentWeapon == null) continue;

            currentWeapon.WeaponStats.ProjectileRange = 5000.0f;
            currentWeapon.WeaponStats.ProjectileSpeed = 1000.0f;
            currentWeapon.WeaponStats.ProtoniumDamageScale = 100000.0f;
            currentWeapon.WeaponStats.DamageInflicted = 1000000;
            currentWeapon.WeaponStats.ProjectileImpactForce = 100000.0f;
            currentWeapon.WeaponStats.DamageRatioConducted = 10000000.0f;
            currentWeapon.WeaponStats.DamageRatioPassedToChasis = 10000000.0f;
            currentWeapon.WeaponStats.ShootThrough = true;
        }
    }

    void ToggleCameraShake() {
        CameraShake cameraShakeObject = FindObjectOfType<CameraShake>();
        cameraShakeObject.enabled = !cameraShakeObject.enabled;
    }

    void RenderWindow(int windowIndex) {
        if (GUI.Button(this.CreateButtonRect(0), "Toggle CameraShake")) {
            this.ToggleCameraShake();
        }

        if (GUI.Button(this.CreateButtonRect(1), "No recoil")) {
            this.ToggleNoRecoil();
        }

        if (GUI.Button(this.CreateButtonRect(2), "100% Accuracy")) {
            this.ToggleMaxAccurancy();
        }

        if (GUI.Button(this.CreateButtonRect(3), "No ROM")) {
            this.ToggleMaxROM();
        }

        if (GUI.Button(this.CreateButtonRect(4), "Death Laser")) {
            this.ToggleDeathLaser();
        }
    }

    Rect CreateButtonRect(int index) {
        int padding = 60;
        int width = 150;
        int height = 30;
        int x = (int)this.windowRect.x - ((int)windowRect.width / 2) + padding + (index * width);
        int y = (int)this.windowRect.y;

        return new Rect(x, y, width, height);
    }

    Rect GetWindowRect(int width, int height) {
        int x = (Screen.width - width) / 2;
        int y = (Screen.height - height) / 2;

        return new Rect(x, y, width, height);
    }
}
