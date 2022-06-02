using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : HaxComponents {
    public static event Global.Action? onF8Press;
    public static event Global.Action? onBackquotePress;

    Dictionary<Global.Func<bool>, Global.Action> keyActionsDict = new Dictionary<Global.Func<bool>, Global.Action>() {
        {() => Input.GetKeyUp(KeyCode.F8),          () => InputListener.onF8Press?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.BackQuote),   () => InputListener.onBackquotePress?.Invoke()}
    };

    void Update() {
        this.KeyboardListener();
    }

    void KeyboardListener() {
        foreach (KeyValuePair<Global.Func<bool>, Global.Action> keyAction in this.keyActionsDict) {
            if (!(keyAction.Key())) continue;
            keyAction.Value();
        }
    }
}