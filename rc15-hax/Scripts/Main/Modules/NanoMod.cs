using System.Collections;
using Simulation;

namespace RC15_HAX;
public class NanoMod : HaxModules {
    bool ModEnabled { get => HaxSettings.GetValue<bool>("EnableSMGMod"); }

    protected override void OnEnable() {
        HaxObjects.NanoBeamObjects.Init(this);
        this.ModNano();
    }

    protected override void OnDisable() {
        HaxObjects.NanoBeamObjects.StopLog();
    }

    void ModNano() {
        // if (!this.ModEnabled) return;
        foreach (NanoBeam nanoBeam in HaxObjects.NanoBeamObjects.Objects) {
            nanoBeam.beamStats.damagePerSecond = int.MaxValue;
            StartCoroutine(this.IRestartComponent(nanoBeam));
        }
    }

    IEnumerator IRestartComponent(NanoBeam nanoBeam) {
        nanoBeam.enabled = false;
        yield return null;
        nanoBeam.enabled = true;
    }

}