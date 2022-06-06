namespace RC15_HAX;
public class WeaponMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnableWeaponMod");

    void OnEnable() {
        if (!this.ModEnabled) return;
        HaxObjects.BaseWeaponObjects.Init(this);
    }

    void OnDisable() {
        print("Disabling Weapon Mod");
        HaxObjects.BaseWeaponObjects.StopLog();
    }

    void Update() {
        this.ModWeapon();
    }

    void ModWeapon() {
        if (!this.ModEnabled) return;

        foreach (BaseWeapon baseWeapon in HaxObjects.BaseWeaponObjects.Objects) {
            // Projectile
            baseWeapon.WeaponStats.ProjectileSpeed = HaxSettings.GetFloat("ProjectileSpeed");
            baseWeapon.WeaponStats.ProjectileRange = HaxSettings.GetFloat("ProjectileRange");

            // Accuracy
            baseWeapon.WeaponStats.RecoilForce = HaxSettings.GetFloat("RecoilForce");
            baseWeapon.Accuracy.BaseInAccuracyDegrees = HaxSettings.GetFloat("BaseInAccuracyDegrees");
            baseWeapon.Accuracy.MovementInAccuracyDegrees = HaxSettings.GetFloat("MovementInAccuracyDegrees");
            baseWeapon.Accuracy.RepeatFireInAccuracyTotalDegrees = HaxSettings.GetFloat("RepeatFireInAccuracyTotalDegrees");

            // Movement limits
            baseWeapon.WeaponStats.AimSpeed = HaxSettings.GetFloat("AimSpeed");
            baseWeapon.MoveLimits.MaxHorizAngle = HaxSettings.GetFloat("MaxHorizAngle");
            baseWeapon.MoveLimits.MinHorizAngle = HaxSettings.GetFloat("MinHorizAngle");
            baseWeapon.MoveLimits.MaxVerticalAngle = HaxSettings.GetFloat("MaxVerticalAngle");
            baseWeapon.MoveLimits.MinVerticalAngle = HaxSettings.GetFloat("MinVerticalAngle");
        }
    }
}