using System;
using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : MonoBehaviour {
    public static event Action? onEnterPress;
    public static event Action? onBackquotePress;

    Dictionary<Func<bool>, Action> keyActionsDict = new Dictionary<Func<bool>, Action>() {
        {() => Input.GetKeyUp(KeyCode.Return),      () => InputListener.onEnterPress?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.BackQuote),   () => InputListener.onBackquotePress?.Invoke()}
    };

    void Update() {
        this.KeyboardListener();
    }

    void KeyboardListener() {
        foreach (KeyValuePair<Func<bool>, Action> keyAction in this.keyActionsDict) {
            if (!(keyAction.Key())) continue;
            keyAction.Value();
        }
    }
}