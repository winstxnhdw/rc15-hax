using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : MonoBehaviour {
    delegate bool boolFunction();
    delegate void voidFunction();

    public delegate void OnBackquotePressDelegate();
    public delegate void onEnterPressDelegate();
    public static event onEnterPressDelegate? onEnterPress;
    public static event OnBackquotePressDelegate? onBackquotePress;

    Dictionary<boolFunction, voidFunction> keyActionsDict = new Dictionary<boolFunction, voidFunction>() {
        {() => Input.GetKeyUp(KeyCode.Return),      () => InputListener.onEnterPress?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.BackQuote),   () => InputListener.onBackquotePress?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.Pause),       () => Loader.Unload()}
    };

    void Update() {
        this.KeyboardListener();
    }

    void KeyboardListener() {
        foreach (KeyValuePair<boolFunction, voidFunction> keyAction in this.keyActionsDict) {
            if (!(keyAction.Key())) continue;
            keyAction.Value();
        }
    }
}