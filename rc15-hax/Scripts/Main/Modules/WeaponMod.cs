using UnityEngine;
namespace RC15_HAX;
public class WeaponMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableWeaponMod"); }
    bool ProjectileModEnabled { get => HaxSettings.GetValue<bool>("EnableProjectileMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        this.ModWeapon();
    }

    void Update() {
        this.ModWeapon();
    }

    void ModWeapon() {
        if (!this.ModEnabled) return;

        foreach (Object baseWeapon in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftObject("BaseWeapon"))) {
            Reflector weaponReflection = new Reflector(baseWeapon);
            WeaponInfo WeaponStats = weaponReflection.GetInternalField<WeaponInfo>("WeaponStats");
            WeaponAccuracy Accuracy = weaponReflection.GetInternalField<WeaponAccuracy>("Accuracy");
            WeaponMoveLimits MoveLimits = weaponReflection.GetInternalField<WeaponMoveLimits>("MoveLimits");

            // Accuracy
            base.ModifyValues(ref WeaponStats.RecoilForce, "RecoilForce");
            base.ModifyValues(ref Accuracy.BaseInAccuracyDegrees, "BaseInAccuracyDegrees");
            base.ModifyValues(ref Accuracy.MovementInAccuracyDegrees, "MovementInAccuracyDegrees");
            base.ModifyValues(ref Accuracy.RepeatFireInAccuracyTotalDegrees, "RepeatFireInAccuracyTotalDegrees");

            // Movement limits
            base.ModifyValues(ref WeaponStats.AimSpeed, "AimSpeed");
            base.ModifyValues(ref MoveLimits.MaxHorizAngle, "MaxHorizAngle");
            base.ModifyValues(ref MoveLimits.MinHorizAngle, "MinHorizAngle");
            base.ModifyValues(ref MoveLimits.MaxVerticalAngle, "MaxVerticalAngle");
            base.ModifyValues(ref MoveLimits.MinVerticalAngle, "MinVerticalAngle");

            // Projectile
            if (this.ProjectileModEnabled) {
                base.ModifyValues(ref WeaponStats.ProjectileSpeed, "ProjectileSpeed");
                base.ModifyValues(ref WeaponStats.ProjectileRange, "ProjectileRange");
            };

            base.DefaultStored = true;
        }
    }
}