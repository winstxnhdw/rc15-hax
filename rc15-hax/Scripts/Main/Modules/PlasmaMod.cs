using Simulation;

namespace RC15_HAX;
public class PlasmaMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnablePlasmaMod"); }

    protected override void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.PlasmaCannonObjects.Init(this);
        this.ModPlamsaTimingData();
    }

    protected override void OnDisable() {
        this.ModPlasma();
        HaxObjects.PlasmaCannonObjects.StopLog();
    }

    void Update() {
        this.ModPlasma();
    }

    void ModPlasma() {
        if (!ModEnabled) return;

        foreach (PlasmaCannon plasmaCannon in HaxObjects.PlasmaCannonObjects.Objects) {
            base.ModifyValues(ref plasmaCannon.secondPlasmaShot.fireTwice, "fireTwice");

            base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDelay, "secondFireDelay");

            base.ModifyValues(ref plasmaCannon.secondPlasmaShot.secondFireDeviation, "secondFireDeviation");

            base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileSpeed, "PlasmaProjectileSpeed");

            base.ModifyValues(ref plasmaCannon.WeaponStats.ProjectileRange, "PlasmaProjectileRange");

            base.DefaultStored = true;
        }

        this.ModPlamsaTimingData();
    }

    void ModPlamsaTimingData() {
        float[] plasmaFirePeriods = new float[6];
        for (int i = 0; i < 6; i++) {
            plasmaFirePeriods[i] = HaxSettings.GetValue<float>($"plasmaFirePeriod{i}");
        }

        FireTimingData fireTimingData = HaxObjects.FireTimingDataObject.Object;
        if (fireTimingData == null) return;
        fireTimingData.plasmaFirePeriod = plasmaFirePeriods;
        fireTimingData.plasmaFlamFirePeriod = HaxSettings.GetValue<float>("plasmaFlamFirePeriod");
    }
}