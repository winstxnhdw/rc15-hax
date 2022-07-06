using UnityEngine;
namespace RC15_HAX;
public class WeaponMod : HaxModules {
    protected override bool ModEnabled => HaxSettings.GetValue<bool>("EnableWeaponMod");
    bool ProjectileSpeedModEnabled => HaxSettings.GetValue<bool>("EnableProjectileSpeedMod");

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModWeapon).Init(2.0f);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        this.ModWeapon();
    }

    void ModWeapon() {
        foreach (Object baseWeapon in Robocraft.GetComponentsInChildren(HaxObjects.PlayerRigidbody, "BaseWeapon")) {
            Reflector weaponReflection = new Reflector(baseWeapon);
            WeaponInfo WeaponStats = weaponReflection.GetInternalField<WeaponInfo>("WeaponStats");
            WeaponAccuracy Accuracy = weaponReflection.GetInternalField<WeaponAccuracy>("Accuracy");
            WeaponMoveLimits MoveLimits = weaponReflection.GetInternalField<WeaponMoveLimits>("MoveLimits");

            // Accuracy
            base.ModifyValues(ref WeaponStats.RecoilForce, "RecoilForce");
            base.ModifyValues(ref Accuracy.BaseInAccuracyDegrees, "BaseInAccuracyDegrees");
            base.ModifyValues(ref Accuracy.MovementInAccuracyDegrees, "MovementInAccuracyDegrees");
            base.ModifyValues(ref Accuracy.RepeatFireInAccuracyTotalDegrees, "RepeatFireInAccuracyTotalDegrees");
            base.ModifyValues(ref WeaponStats.ProjectileRange, "ProjectileRange");

            // Movement limits
            base.ModifyValues(ref WeaponStats.AimSpeed, "AimSpeed");
            base.ModifyValues(ref MoveLimits.MaxHorizAngle, "MaxHorizAngle");
            base.ModifyValues(ref MoveLimits.MinHorizAngle, "MinHorizAngle");
            base.ModifyValues(ref MoveLimits.MaxVerticalAngle, "MaxVerticalAngle");
            base.ModifyValues(ref MoveLimits.MinVerticalAngle, "MinVerticalAngle");

            // Projectile
            if (this.ProjectileSpeedModEnabled) {
                base.ModifyValues(ref WeaponStats.ProjectileSpeed, "ProjectileSpeed");
            }

            base.DefaultStored = true;
        }
    }
}