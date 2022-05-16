using System.Linq;
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

        if (Input.GetKeyUp(KeyCode.Backslash)) {
            FindObjectOfType<LocalPlayerRigidbody>().rb.rotation = Quaternion.Euler(0.0f, Main.Camera!.transform.eulerAngles.y, 0.0f);
        }

        // if (Settings.aimBotToggle) {
        //     if (Input.GetMouseButton(0)) {
        //         Rigidbody closestRigidBody = FindObjectsOfType<Rigidbody>().OrderBy(rb => Vector3.Distance(Main.Camera!.transform.position, rb.worldCenterOfMass)).First();
        //         Vector2 w2s = Camera.main.WorldToScreenPoint(closestRigidBody.worldCenterOfMass);
        //         Vector2 translatedCursorPosition = w2s - ScreenInfo.GetScreenCentre2D();
        //         Main.Camera!.transform.localEulerAngles = new Vector3(-translatedCursorPosition.y, translatedCursorPosition.x, 0.0f);
        //     }
        // }
    }

    void ResetPlayerOrientation() {
        this.playerRigidbody!.rotation = Quaternion.Euler(Main.Camera!.transform.eulerAngles.x, Main.Camera!.transform.eulerAngles.y, 0.0f);
    }

    void OnGUI() {
        if (Settings.espToggle) {
            foreach (Rigidbody body in FindObjectsOfType<Rigidbody>()) {
                Vector3 w2s = Camera.main.WorldToScreenPoint(body.worldCenterOfMass);
                if (w2s.z <= 0.0f) continue;
                DrawBox(new Vector2(w2s.x, Screen.height - w2s.y), new Vector2(50.0f, 50.0f), true);
            }
        }

        if (!Settings.menuToggle) return;
        GUI.Window(0, this.windowRect, this.RenderWindow, "Hax Menu");
    }

    void DrawBox(Vector2 position, Vector2 size, bool centered = true) {
        Vector2 upperLeft = centered ? position - size / 2f : position;
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, 0.2f);
        GUI.DrawTexture(new Rect(position.x - upperLeft.x, position.y - upperLeft.y, size.x, size.y), Texture2D.whiteTexture, ScaleMode.StretchToFill);
    }

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

            if (Input.GetKey(KeyCode.Space)) {
                this.playerRigidbody.position = this.playerRigidbody.position + Main.Camera!.transform.up;
            }

            else if (Input.GetKey(KeyCode.LeftShift)) {
                this.playerRigidbody.position = this.playerRigidbody.position - Main.Camera!.transform.up;
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
            weapon.WeaponStats.AimSpeed = float.MaxValue;
        }
    }

    void ToggleDeathLaser() {
        foreach (BaseWeapon weapon in FindObjectsOfType<BaseWeapon>()) {
            weapon.WeaponStats.ProjectileRange = float.MaxValue;
            weapon.WeaponStats.ProjectileSpeed = 1000.0f;
            weapon.WeaponStats.ProtoniumDamageScale = float.MaxValue;
            weapon.WeaponStats.ProjectileImpactForce = float.MaxValue;
            weapon.WeaponStats.DamageRatioConducted = float.MaxValue;
            weapon.WeaponStats.DamageRatioPassedToChasis = float.MaxValue;
            weapon.WeaponStats.ShootThrough = true;
        }
    }

    void ToggleUltimateNanoBeam() {
        foreach (NanoBeam nanoBeam in FindObjectsOfType<NanoBeam>()) {
            nanoBeam.beamStats.damagePerSecond = 1000000;
            nanoBeam.beamStats.healPerSecond = 1000000;
            nanoBeam.WeaponStats.ProjectileRange = float.MaxValue;
            nanoBeam.WeaponStats.ProjectileSpeed = 1000.0f;
            nanoBeam.WeaponStats.ProtoniumDamageScale = float.MaxValue;
            nanoBeam.WeaponStats.DamageInflicted = int.MaxValue;
            nanoBeam.WeaponStats.ProjectileImpactForce = float.MaxValue;
            nanoBeam.WeaponStats.DamageRatioConducted = float.MaxValue;
            nanoBeam.WeaponStats.DamageRatioPassedToChasis = float.MaxValue;
            nanoBeam.WeaponStats.ShootThrough = true;
        }
    }

    void ToggleNoClip() {
        Settings.noClipToggle = !Settings.noClipToggle;
    }

    void ToggleAimBot() {
        Settings.aimBotToggle = !Settings.aimBotToggle;
    }

    void ToggleESP() {
        Settings.espToggle = !Settings.espToggle;
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

        if (GUI.Button(this.CreateButtonRectRow2(0), "Ultimate NanoBeam")) {
            this.ToggleUltimateNanoBeam();
        }

        if (GUI.Button(this.CreateButtonRectRow2(1), "Dejavu")) {
            foreach (CubeWheel cubeWheel in FindObjectsOfType<CubeWheel>()) {
                cubeWheel.maxRPM = 2000.0f;
                cubeWheel.friction.groundFrictionMultiplier = 3.0f;
            }
        }

        if (GUI.Button(this.CreateButtonRectRow2(2), "Boost")) {
            foreach (CubeAerofoil cubeAerofoil in FindObjectsOfType<CubeAerofoil>()) {
                cubeAerofoil.dragMinVelocity = float.MaxValue;
                cubeAerofoil.dragMaxVelocity = float.MaxValue;
            }

            foreach (CubeJet cubeJet in FindObjectsOfType<CubeJet>()) {
                cubeJet.ForceMagnitude = 15000.0f;
                cubeJet.MaxVelocity = float.MaxValue;
            }
        }

        if (GUI.Button(this.CreateButtonRectRow2(3), "ESP")) {
            this.ToggleESP();
        }

        if (GUI.Button(this.CreateButtonRectRow2(4), "AimBot")) {
            this.ToggleAimBot();
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

    Rect CreateButtonRectRow2(int index) {
        int padding = 60;
        int width = 150;
        int height = 30;
        int x = (int)this.windowRect.x - ((int)windowRect.width / 2) + padding + (index * width);
        int y = (int)this.windowRect.y + height * 2;

        return new Rect(x, y, width, height);
    }

    Rect GetWindowRect(int width, int height) {
        int x = (Screen.width - width) / 2;
        int y = (Screen.height - height) / 2;

        return new Rect(x, y, width, height);
    }
}
