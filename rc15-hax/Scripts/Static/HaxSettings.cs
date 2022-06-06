using System.Collections.Generic;

namespace RC15_HAX;
public static class HaxSettings {
    static void PrintInvalidKey(string key) {
        Console.Print($"Invalid key: {key}");
    }

    public static bool GetBool(string key) {
        if (!HaxSettings.Params.TryGetValue(key, out string param)) HaxSettings.PrintInvalidKey(key);
        return bool.Parse(param);
    }

    public static float GetFloat(string key) {
        if (!HaxSettings.Params.TryGetValue(key, out string param)) HaxSettings.PrintInvalidKey(key);
        return float.Parse(param);
    }

    static Dictionary<string, string> Params { get; } = new Dictionary<string, string> {
        // Weapon projectile parameters
        {"EnableProjectileMod",                 "false"},
        {"ProjectileSpeed",                     "1000000"},
        {"ProjectileRange",                     "1000000"},
        // Weapon accuracy parameters
        {"EnableWeaponMod",                     "true"},
        {"RecoilForce",                         "0"},
        {"BaseInAccuracyDegrees",               "0"},
        {"MovementInAccuracyDegrees",           "0"},
        {"RepeatFireInAccuracyTotalDegrees",    "0"},
        // Weapon movement limits
        {"AimSpeed",                            "1000000"},
        {"MaxHorizAngle",                       "180"},
        {"MinHorizAngle",                       "-180"},
        {"MaxVerticalAngle",                    "180"},
        {"MinVerticalAngle",                    "-180"},
        // Plasma Cannon parameters
        {"EnablePlasmaMod",                     "true"},
        {"fireTwice",                           "true"},
        {"secondFireDelay",                     "0.1"},
        {"secondFireDeviation",                 "0"},
        {"PlasmaProjectileSpeed",               "5000"},
        {"PlasmaProjectileRange",               "1000000"},
        // Wheel parameters
        {"EnableWheelMod",                      "false"},
        {"maxRPM",                              "2000"},
        {"groundFrictionMultiplier",            "3"},
        // Aerofoil parameters
        {"EnableAerofoilMod",                   "false"},
        {"dragMinVelocity",                     "1000000"},
        {"dragMaxVelocity",                     "1000000"},
        // Jet parameters
        {"EnableJetMod",                        "false"},
        {"ForceMagnitude",                      "15000"},
        {"MaxVelocity",                         "1000000"},
        // Fake crosshair
        {"GapSize",                             "7"},
        {"Thickness",                           "3"},
        {"Length",                              "15"},
        // General parameters
        {"EnableESP",                           "true"},
        {"NoCameraShake",                       "true"},
        {"IronWall",                            "true"},
        {"IronWallIntervals",                   "1"},
    };
}

