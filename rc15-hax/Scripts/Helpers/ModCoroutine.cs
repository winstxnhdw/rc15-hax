using System;
using System.Collections;
using UnityEngine;

namespace Hax;
public class ModCoroutine {
    MonoBehaviour Self { get; }
    Action ModFunction { get; }
    float UpdateInterval { get; }

    public ModCoroutine(MonoBehaviour self, Action modFunction) {
        this.Self = self;
        this.ModFunction = modFunction;
    }

    public void Init(float updateInterval) => Self.StartCoroutine(this.IModInvoke(updateInterval));

    public void Init() => Self.StartCoroutine(this.IModInvoke());

    IEnumerator IModInvoke(float updateInterval) {
        while (true) {
            this.ModFunction();
            yield return new WaitForSeconds(updateInterval);
        }
    }

    IEnumerator IModInvoke() {
        while (true) {
            this.ModFunction();
            yield return new WaitForEndOfFrame();
        }
    }

    public static ModCoroutine Create(MonoBehaviour self, Action modFunction) => new ModCoroutine(self, modFunction);
}