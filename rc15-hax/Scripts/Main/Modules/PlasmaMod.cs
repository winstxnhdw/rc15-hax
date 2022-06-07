namespace RC15_HAX;
public class PlasmaMod : HaxModules {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnablePlasmaMod");

    protected override void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.PlasmaCannonObjects.Init(this);
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
    }
}