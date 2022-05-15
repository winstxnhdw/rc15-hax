using UnityEngine;
using Simulation;

namespace RC15_HAX;
public class Hax : MonoBehaviour {
    Rect windowRect;
    Rigidbody? playerRigidbody;
    bool rigidBodyInstatiated;

    void Awake() {
        this.windowRect = this.GetWindowRect(1000, 1000);
        this.rigidBodyInstatiated = false;
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.Pause)) Loader.Unload();
        if (Input.GetKey(KeyCode.Space)) {
            if (Input.GetKeyUp(KeyCode.Escape)) Settings.menuToggle = !Settings.menuToggle;
        }

        if (Settings.noClipToggle) {
            this.PerformNoClip();
        }

        else {
            this.playerRigidbody!.isKinematic = false;
            this.rigidBodyInstatiated = false;
        }
    }

    void ResetPlayerOrientation() {
        this.playerRigidbody!.rotation = Quaternion.Euler(Main.Camera!.transform.eulerAngles.x, Main.Camera!.transform.eulerAngles.y, 0.0f);
    }

    void OnGUI() {
        if (!Settings.menuToggle) return;
        GUI.Window(0, this.windowRect, this.RenderWindow, "Hax Menu");
    }

    // void DrawBox(Vector2 position, Vector2 size, bool centered = true) {
    //     var upperLeft = centered ? position - size / 2f : position;
    //     GUI.DrawTexture(new Rect(position.x, position.y, size.x, size.y), Texture2D.whiteTexture, ScaleMode.StretchToFill);
    // }

    void PerformNoClip() {
        if (!this.rigidBodyInstatiated) {
            this.playerRigidbody = FindObjectOfType<LocalPlayerRigidbody>().rb;
            this.rigidBodyInstatiated = true;
        }

        this.playerRigidbody!.isKinematic = true;

        if (Input.anyKey) {
            this.ResetPlayerOrientation();

            if (Input.GetKey(KeyCode.W)) {
                this.playerRigidbody.position = this.playerRigidbody.position + Main.Camera!.transform.forward;
            }

            else if (Input.GetKey(KeyCode.A)) {
                this.playerRigidbody.position = this.playerRigidbody.position - Main.Camera!.transform.right;
            }

            else if (Input.GetKey(KeyCode.S)) {
                this.playerRigidbody.position = this.playerRigidbody.position - Main.Camera!.transform.forward;
            }

            else if (Input.GetKey(KeyCode.D)) {
                this.playerRigidbody.position = this.playerRigidbody.position + Main.Camera!.transform.right;
            }
        }
    }

    void ToggleNoRecoil() {
        foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
            weapon.WeaponStats.RecoilForce = 0.0f;
        }
    }

    void ToggleMaxAccurancy() {
        foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
            weapon.Accuracy.BaseInAccuracyDegrees = 0.0f;
            weapon.Accuracy.MovementInAccuracyDegrees = 0.0f;
            weapon.Accuracy.RepeatFireInAccuracyTotalDegrees = 0.0f;
            weapon.Accuracy.FireInstantAccuracyDecayDegrees = 0.0f;
        }
    }

    void ToggleMaxROM() {
        foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
            weapon.MoveLimits.MaxHorizAngle = 180.0f;
            weapon.MoveLimits.MinHorizAngle = -180.0f;
            weapon.MoveLimits.MaxVerticalAngle = 180.0f;
            weapon.MoveLimits.MinVerticalAngle = -180.0f;
        }
    }

    void ToggleDeathLaser() {
        foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
            weapon.WeaponStats.ProjectileRange = 5000.0f;
            weapon.WeaponStats.ProjectileSpeed = 1000.0f;
            weapon.WeaponStats.ProtoniumDamageScale = 100000.0f;
            weapon.WeaponStats.DamageInflicted = 1000000;
            weapon.WeaponStats.ProjectileImpactForce = 100000.0f;
            weapon.WeaponStats.DamageRatioConducted = 10000000.0f;
            weapon.WeaponStats.DamageRatioPassedToChasis = 10000000.0f;
            weapon.WeaponStats.ShootThrough = true;
        }
    }

    void ToggleNoClip() {
        Settings.noClipToggle = !Settings.noClipToggle;
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

        if (GUI.Button(this.CreateButtonRect(5), "No Clip")) {
            this.ToggleNoClip();
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
