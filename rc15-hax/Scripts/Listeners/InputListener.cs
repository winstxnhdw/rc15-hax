using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : HaxComponents {
    public static event Global.Action? onF8Press;
    public static event Global.Action? onF9Press;
    public static event Global.Action? onF10Press;
    public static event Global.Action? onF11Press;
    public static event Global.Action? onBackquotePress;
    public static event Global.Action? onBackslashPress;
    public static event Global.Action? onLeftAlt;
    public static event Global.Action? onLeftAltUp;
    public static event Global.Action? onEscapePress;
    public static event Global.Action? onPausePress;

    Dictionary<Global.Func<bool>, Global.Action> keyActionsDict = new Dictionary<Global.Func<bool>, Global.Action>() {
        {() => Input.GetKey(KeyCode.LeftAlt),         () => InputListener.onLeftAlt?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.LeftAlt),       () => InputListener.onLeftAltUp?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F8),          () => InputListener.onF8Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F9),          () => InputListener.onF9Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F10),         () => InputListener.onF10Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F11),         () => InputListener.onF11Press?.Invoke()},
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