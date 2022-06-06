namespace RC15_HAX;
public class PlasmaMod : HaxComponents {
    bool ModEnabled { get; } = HaxSettings.GetBool("EnablePlasmaMod");

    void OnEnable() {
        if (!ModEnabled) return;
        HaxObjects.PlasmaCannonObjects.Init(this);
    }

    void OnDisable() {
        HaxObjects.PlasmaCannonObjects.StopLog();
    }

    void Update() {
        this.ModPlasma();
    }

    void ModPlasma() {
        if (!ModEnabled) return;

        foreach (PlasmaCannon plasmaCannon in HaxObjects.PlasmaCannonObjects.Objects) {
            plasmaCannon.secondPlasmaShot.fireTwice = HaxSettings.GetBool("fireTwice");

            plasmaCannon.secondPlasmaShot.secondFireDelay = HaxSettings.GetFloat("secondFireDelay");

            plasmaCannon.secondPlasmaShot.secondFireDeviation = HaxSettings.GetFloat("secondFireDeviation");

            plasmaCannon.WeaponStats.ProjectileSpeed = HaxSettings.GetFloat("PlasmaProjectileSpeed");

            plasmaCannon.WeaponStats.ProjectileRange = HaxSettings.GetFloat("PlasmaProjectileRange");
        }
    }
}