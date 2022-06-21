using System.Reflection;
using System.Linq;
using UnityEngine;
using Simulation;
namespace RC15_HAX;
public class NanoMod : HaxModules {
    bool ModEnabled { get => true; }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
        // this.ModPlasma();
    }

    void Update() {
        this.ModNano();
    }

    void ModNano() {

        if (!this.ModEnabled) return;

        foreach (Object nanoBeam in HaxObjects.PlayerRigidbody.GetComponentsInChildren(Global.GetRobocraftType("Simulation.NanoBeam"))) {
            object internalNano = new Reflector(nanoBeam).GetInternalField<object>("_internalWeapon");

            Reflector internalNanoReflection = new Reflector(internalNano).SetInternalField("_damagePerSecond", 1000000)
                                                         .SetInternalField("_healPerSecond", 1000000)
                                                         .SetInternalField("_range", float.MaxValue);

            Console.Print(internalNanoReflection.GetInternalField<float>("_range"));
            // object actualRefirePeriodProperty = new Reflector(weaponManager).GetInternalProperty("actualRefirePeriod");
            // new Reflector(actualRefirePeriodProperty).SetInternalField(0.1f);

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.fireTwice, "fireTwice");

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDelay, "secondFireDelay");

            // base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDeviation, "secondFireDeviation");

            // base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileSpeed, "PlasmaProjectileSpeed");

            // base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileRange, "PlasmaProjectileRange");

            // base.DefaultStored = true;
        }
    }
}