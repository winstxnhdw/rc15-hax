using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : HaxComponents {
    public static event Global.Action? onF8Press;
    public static event Global.Action? onF9Press;
    public static event Global.Action? onF10Press;
    public static event Global.Action? onBackquotePress;
    public static event Global.Action? onBackslashPress;
    public static event Global.Action? onEscapePress;
    public static event Global.Action? onPausePress;

    Dictionary<Global.Func<bool>, Global.Action> keyActionsDict = new Dictionary<Global.Func<bool>, Global.Action>() {
        {() => Input.GetKeyDown(KeyCode.F8),          () => InputListener.onF8Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F9),          () => InputListener.onF9Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F10),         () => InputListener.onF10Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.BackQuote),   () => InputListener.onBackquotePress?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.Backslash),   () => InputListener.onBackslashPress?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.Escape),      () => InputListener.onEscapePress?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.Pause),       () => InputListener.onPausePress?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.End),         () => Loader.Unload()}
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