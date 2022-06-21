using System;
using System.Collections;
using UnityEngine;

public class ModCoroutine {
    Action ModFunction { get; }
    float UpdateInterval { get; }

    public ModCoroutine(MonoBehaviour self, Action modFunction, float updateInterval = 2.0f) {
        this.ModFunction = modFunction;
        this.UpdateInterval = updateInterval;
        self.StartCoroutine(this.IModInvoke());
    }

    IEnumerator IModInvoke() {
        while (true) {
            this.ModFunction();
            yield return new WaitForSeconds(this.UpdateInterval);
        }
    }
}