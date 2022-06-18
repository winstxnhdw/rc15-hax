using Simulation;

namespace RC15_HAX;
public class PlasmaMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlasmaMod"); }

    protected override void OnEnable() {
        if (!this.ModEnabled) return;
        base.OnEnable();
        this.ModPlamsaTimingData();
        // HaxObjects.PlasmaCannonObjects.Init(this);
    }

    protected override void OnDisable() {
        if (!this.ModEnabled) return;
        base.OnDisable();
        // HaxObjects.PlasmaCannonObjects.StopLog();
        // this.ModPlasma();
    }

    // void Update() {
    //     this.ModPlasma();
    // }

    // void ModPlasma() {
    //     if (!this.ModEnabled) return;

    //     foreach (PlasmaCannon plasmaCannon in HaxObjects.PlasmaCannonObjects.Objects) {
    //         base.ModifyValues(ref plasmaCannon.secondPlasmaShot.fireTwice, "fireTwice");

    //         base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDelay, "secondFireDelay");

    //         base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDeviation, "secondFireDeviation");

    //         base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileSpeed, "PlasmaProjectileSpeed");

    //         base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileRange, "PlasmaProjectileRange");

    //         base.DefaultStored = true;
    //     }

    //     this.ModPlamsaTimingData();
    // }

    void ModPlamsaTimingData() {
        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;

        float[] plasmaFirePeriods = new float[6];

        for (int i = 0; i < 6; i++) {
            plasmaFirePeriods[i] = HaxSettings.GetValue<float>($"plasmaFirePeriod{i}");
        }

        Global.SetInternalFieldValue(fireTimingData, "plasmaFirePeriod", plasmaFirePeriods);
        Global.SetInternalFieldValue(fireTimingData, "plasmaFlamFirePeriod", HaxSettings.GetValue<float>("plasmaFlamFirePeriod"));
        fireTimingData.Start();
    }
}