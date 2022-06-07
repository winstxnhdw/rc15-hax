using System.Collections.Generic;

namespace RC15_HAX;
public static class HaxSettings {
    public static bool ParseDefaultValues { get; set; } = false;

    static string GetParamValue(Params param) => HaxSettings.ParseDefaultValues ? param.Default : param.Current;

    static void StoreDefaultValues(string key, string defaultValue) {
        if (string.IsNullOrEmpty(defaultValue)) return;

        Params param = GetParams(key);
        param.Default = defaultValue;
        HaxSettings.Params[key] = param;
    }

    static void PrintInvalidType(string key, string type) {
        Console.Print($"{key} is not a {type}");
    }

    public static Params GetParams(string key, string defaultValue = "") {
        if (!HaxSettings.Params.TryGetValue(key, out Params param)) Console.Print($"Invalid key: {key}");
        return param;
    }

    public static bool GetBool(string key, string defaultValue = "") {
        HaxSettings.StoreDefaultValues(key, defaultValue);
        Params param = GetParams(key);
        if (!bool.TryParse(GetParamValue(param), out bool value)) HaxSettings.PrintInvalidType(key, "bool");
        return value;
    }

    public static float GetFloat(string key, string defaultValue = "") {
        HaxSettings.StoreDefaultValues(key, defaultValue);
        Params param = GetParams(key);
        if (!float.TryParse(GetParamValue(param), out float value)) HaxSettings.PrintInvalidType(key, "float");
        return value;
    }

    public static int GetInt(string key, string defaultValue = "") {
        HaxSettings.StoreDefaultValues(key, defaultValue);
        Params param = GetParams(key);
        if (!int.TryParse(GetParamValue(param), out int value)) HaxSettings.PrintInvalidType(key, "int");
        return value;
    }

    static Params SetParams(string paramValue) => new Params(paramValue);

    // Max int value is 2147483647
    static Dictionary<string, Params> Params { get; } = new Dictionary<string, Params> {
        // Weapon projectile parameters
        {"EnableProjectileMod",                 SetParams("false")},
        {"ProjectileSpeed",                     SetParams("1000000000000")},
        {"ProjectileRange",                     SetParams("1000000000000")},
        // Weapon accuracy parameters
        {"EnableWeaponMod",                     SetParams("true")},
        {"RecoilForce",                         SetParams("0")},
        {"BaseInAccuracyDegrees",               SetParams("0")},
        {"MovementInAccuracyDegrees",           SetParams("0")},
        {"RepeatFireInAccuracyTotalDegrees",    SetParams("0")},
        // Weapon movement limits
        {"AimSpeed",                            SetParams("1000000000000")},
        {"MaxHorizAngle",                       SetParams("180")},
        {"MinHorizAngle",                       SetParams("-180")},
        {"MaxVerticalAngle",                    SetParams("180")},
        {"MinVerticalAngle",                    SetParams("-180")},
        // Plasma Cannon parameters
        {"EnablePlasmaMod",                     SetParams("true")},
        {"fireTwice",                           SetParams("true")},
        {"secondFireDelay",                     SetParams("0")},
        {"secondFireDeviation",                 SetParams("0")},
        {"PlasmaProjectileSpeed",               SetParams("250")},
        {"PlasmaProjectileRange",               SetParams("1000000000000")},
        // Wheel parameters
        {"EnableWheelMod",                      SetParams("false")},
        {"maxRPM",                              SetParams("1000")},
        {"groundFrictionMultiplier",            SetParams("8")},
        {"stoppingBrakeTorque",                 SetParams("4000")},
        {"maxSteeringAngle",                    SetParams("30")},
        // Aerofoil parameters
        {"EnableAerofoilMod",                   SetParams("true")},
        {"aerofoilMaxCarryingMass",             SetParams("1000000000000")},
        {"horizontalCarryingMassScale",         SetParams("0")},
        // Jet parameters
        {"EnableJetMod",                        SetParams("true")},
        {"ForceMagnitude",                      SetParams("2500")},
        // Rotor parameters
        {"EnableRotorMod",                      SetParams("false")},
        {"rotorMaxCarryingMass",                SetParams("1000000000000")},
        {"driftAcceleration",                   SetParams("0")},
        // Fake crosshair
        {"GapSize",                             SetParams("7")},
        {"Thickness",                           SetParams("3")},
        {"Length",                              SetParams("15")},
        // ESP parameters
        {"EnablePlayerESP",                     SetParams("true")},
        {"OutlineBoxSize",                      SetParams("4000")},
        {"TextBottomPadding",                   SetParams("20")},
        // General parameters
        {"NoCameraShake",                       SetParams("true")},
        {"NoFog",                               SetParams("true")}
    };
}

