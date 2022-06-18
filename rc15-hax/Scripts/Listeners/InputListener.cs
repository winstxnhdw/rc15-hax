using System;
using System.Collections.Generic;
using UnityEngine;

namespace RC15_HAX;
public class InputListener : HaxComponents {
    public static event Action onF5Press;
    public static event Action onF8Press;
    public static event Action onF9Press;
    public static event Action onF10Press;
    public static event Action onF11Press;
    public static event Action onBackquotePress;
    public static event Action onBackslashPress;
    public static event Action onAlpha1Press;
    public static event Action onAlpha3Press;
    public static event Action onLeftControl;
    public static event Action onLeftControlUp;
    public static event Action onEscapePress;
    public static event Action onPausePress;

    Dictionary<Func<bool>, Action> keyActionsDict = new Dictionary<Func<bool>, Action>() {
        {() => Input.GetKey(KeyCode.LeftControl),     () => InputListener.onLeftControl?.Invoke()},
        {() => Input.GetKeyUp(KeyCode.LeftControl),   () => InputListener.onLeftControlUp?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F5),          () => InputListener.onF5Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F8),          () => InputListener.onF8Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F9),          () => InputListener.onF9Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F10),         () => InputListener.onF10Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.F11),         () => InputListener.onF11Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.Alpha1),      () => InputListener.onAlpha1Press?.Invoke()},
        {() => Input.GetKeyDown(KeyCode.Alpha3),      () => InputListener.onAlpha3Press?.Invoke()},
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
        foreach (KeyValuePair<Func<bool>, Action> keyAction in this.keyActionsDict) {
            if (!(keyAction.Key())) continue;
            keyAction.Value();
        }
    }
}