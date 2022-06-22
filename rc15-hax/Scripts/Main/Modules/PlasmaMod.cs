using System.Linq;
using UnityEngine;
using Simulation;
namespace RC15_HAX;
public class PlasmaMod : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlasmaMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        new ModCoroutine(this, this.ModPlasma).Init(5.0f);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        this.ModPlasma();
    }

    void ModPlasma() {
        foreach (Object plasmaCannon in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftType("PlasmaCannon"))) {
            Reflector plasmaCannonReflection = new Reflector(plasmaCannon);
            WeaponInfo WeaponStats = plasmaCannonReflection.GetInternalField<WeaponInfo>("WeaponStats");
            SecondPlasmaShot secondPlasmaShot = plasmaCannonReflection.GetInternalField<SecondPlasmaShot>("secondPlasmaShot");

            base.ModifyValues(ref secondPlasmaShot.fireTwice, "fireTwice");

            base.ModifyValues(ref secondPlasmaShot.secondFireDelay, "secondFireDelay");

            base.ModifyValues(ref secondPlasmaShot.secondFireDeviation, "secondFireDeviation");

            base.ModifyValues(ref WeaponStats.ProjectileSpeed, "PlasmaProjectileSpeed");

            base.ModifyValues(ref WeaponStats.ProjectileRange, "PlasmaProjectileRange");

            base.DefaultStored = true;

            object internalPlasma = plasmaCannonReflection.GetInternalField<object>("_internalWeapon");
            Reflector internalPlasmaReflection = new Reflector(internalPlasma);
            internalPlasmaReflection.SetInternalField("_currentDamage", HaxSettings.GetValue<int>("PlasmaDamage"))
                                    .SetInternalField("_currentExplosionRadius", HaxSettings.GetValue<float>("ExplosionRadius"));
        }

        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;

        float[] plasmaFirePeriods = (from i in Enumerable.Range(0, 6) select HaxSettings.GetValue<float>($"plasmaFirePeriod{i}")).ToArray();
        new Reflector(fireTimingData).SetInternalField("plasmaFirePeriod", plasmaFirePeriods)
                                     .SetInternalField("plasmaFlamFirePeriod", HaxSettings.GetValue<float>("plasmaFlamFirePeriod"));
        fireTimingData.Start();
    }
}