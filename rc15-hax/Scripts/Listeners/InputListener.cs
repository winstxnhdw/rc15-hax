using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : MonoBehaviour {
    delegate bool BoolFunction();

    public static event Global.Action? onF4Press;
    public static event Global.Action? onBackquotePress;

    Dictionary<BoolFunction, Global.Action> keyActionsDict = new Dictionary<BoolFunction, Global.Action>() {
        {() => Input.GetKeyUp(KeyCode.F4),      () => InputListener.onF4Press?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.BackQuote),   () => InputListener.onBackquotePress?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.Pause),       () => Loader.Unload()}
    };

    void Update() {
        this.KeyboardListener();
    }

    void KeyboardListener() {
        foreach (KeyValuePair<BoolFunction, Global.Action> keyAction in this.keyActionsDict) {
            if (!(keyAction.Key())) continue;
            keyAction.Value();
        }
    }
}