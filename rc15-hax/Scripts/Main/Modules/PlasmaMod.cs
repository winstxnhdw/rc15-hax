using System.Reflection;
using System.Linq;
using UnityEngine;
using Simulation;
namespace RC15_HAX;
public class PlasmaMod : HaxModules {
    protected override bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlasmaMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;

        base.OnEnable();
        this.ModPlasmaTimingData();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;

        base.OnDisable();
        // this.ModPlasma();
    }

    void Update() {
        this.ModPlasma();
    }

    void ModPlasma() {
        if (!this.ModEnabled) return;

        foreach (Object plasmaCannon in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftType("PlasmaCannon"))) {
            object internalPlasma = new Reflector(plasmaCannon).GetInternalField<object>("_internalWeapon");
            Reflector internalPlasmaReflection = new Reflector(internalPlasma);
            internalPlasmaReflection.SetInternalField("_currentDamage", 1000000)
                                    .SetInternalField("_currentExplosionRadius", 20.0f);

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.fireTwice, "fireTwice");

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDelay, "secondFireDelay");

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDeviation, "secondFireDeviation");

            // base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileSpeed, "PlasmaProjectileSpeed");

            // base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileRange, "PlasmaProjectileRange");

            // base.DefaultStored = true;
        }
    }

    void ModPlasmaTimingData() {
        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        float[] plasmaFirePeriods = (from i in Enumerable.Range(0, 6) select HaxSettings.GetValue<float>($"plasmaFirePeriod{i}")).ToArray();
        new Reflector(fireTimingData).SetInternalField("plasmaFirePeriod", plasmaFirePeriods)
                                     .SetInternalField("plasmaFlamFirePeriod", HaxSettings.GetValue<float>("plasmaFlamFirePeriod"));
        fireTimingData.Start();
    }
}