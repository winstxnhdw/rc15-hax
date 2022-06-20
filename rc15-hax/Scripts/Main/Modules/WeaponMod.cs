using Simulation;
using UnityEngine;
namespace RC15_HAX;
public class WeaponMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableWeaponMod"); }
    bool ProjectileModEnabled { get => HaxSettings.GetValue<bool>("EnableProjectileMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.ModWeaponTimingData();
        // HaxObjects.BaseWeaponObjects.Init(this);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
        // HaxObjects.BaseWeaponObjects.StopLog();
        // this.ModWeapon();
    }

    void Update() {
        // this.ModWeapon();
        // foreach (Object baseWeapon in HaxObjects.BaseWeaponObjects.Objects) {
        //     Reflector weaponReflection = new Reflector(baseWeapon);
        //     WeaponInfo weaponStats = weaponReflection.GetInternalField<WeaponInfo>("WeaponStats");
        //     weaponStats.AimSpeed = 100000000.0f;
        //     weaponReflection.SetInternalField("WeaponStats", weaponStats);
        //     Console.Print(weaponReflection.GetInternalField<WeaponInfo>("WeaponStats").AimSpeed);
        // }
    }

    // void ModWeapon() {
    //     if (!this.ModEnabled) return;

    //     foreach (BaseWeapon baseWeapon in HaxObjects.BaseWeaponObjects.Objects) {
    //         // Accuracy
    //         base.ModifyValues(ref baseWeapon.WeaponStats.RecoilForce, "RecoilForce");
    //         base.ModifyValues(ref baseWeapon.Accuracy.BaseInAccuracyDegrees, "BaseInAccuracyDegrees");
    //         base.ModifyValues(ref baseWeapon.Accuracy.MovementInAccuracyDegrees, "MovementInAccuracyDegrees");
    //         base.ModifyValues(ref baseWeapon.Accuracy.RepeatFireInAccuracyTotalDegrees, "RepeatFireInAccuracyTotalDegrees");

    //         // Movement limits
    //         base.ModifyValues(ref baseWeapon.WeaponStats.AimSpeed, "AimSpeed");
    //         base.ModifyValues(ref baseWeapon.MoveLimits.MaxHorizAngle, "MaxHorizAngle");
    //         base.ModifyValues(ref baseWeapon.MoveLimits.MinHorizAngle, "MinHorizAngle");
    //         base.ModifyValues(ref baseWeapon.MoveLimits.MaxVerticalAngle, "MaxVerticalAngle");
    //         base.ModifyValues(ref baseWeapon.MoveLimits.MinVerticalAngle, "MinVerticalAngle");

    //         // Projectile
    //         if (this.ProjectileModEnabled) {
    //             base.ModifyValues(ref baseWeapon.WeaponStats.ProjectileSpeed, "ProjectileSpeed");
    //             base.ModifyValues(ref baseWeapon.WeaponStats.ProjectileRange, "ProjectileRange");
    //         };

    //         base.DefaultStored = true;
    //     }
    // }

    void ModWeaponTimingData() {
        Console.Print("Test");
        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;

        new Reflector(fireTimingData).SetInternalField("accuracyRecoverTime", HaxSettings.GetValue<float>("accuracyRecoverTime"))
                                     .SetInternalField("accuracyDecayTime", HaxSettings.GetValue<float>("accuracyDecayTime"));
        fireTimingData.Start();
        Console.Print("finsihed");

    }
}