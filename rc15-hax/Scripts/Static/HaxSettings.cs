using System.Collections.Generic;

namespace RC15_HAX;
public static class HaxSettings {
    static void PrintInvalidKey(string key) {
        Console.Print($"Invalid key: {key}");
    }

    static void PrintInvalidType(string key, string type) {
        Console.Print($"{key} is not a {type}");
    }

    public static bool GetBool(string key) {
        if (!HaxSettings.Params.TryGetValue(key, out string param)) HaxSettings.PrintInvalidKey(key);
        if (!bool.TryParse(param, out bool value)) HaxSettings.PrintInvalidType(key, "bool");
        return value;
    }

    public static float GetFloat(string key) {
        if (!HaxSettings.Params.TryGetValue(key, out string param)) HaxSettings.PrintInvalidKey(key);
        if (!float.TryParse(param, out float value)) HaxSettings.PrintInvalidType(key, "float");
        return value;
    }

    public static int GetInt(string key) {
        if (!HaxSettings.Params.TryGetValue(key, out string param)) HaxSettings.PrintInvalidKey(key);
        if (!int.TryParse(param, out int value)) HaxSettings.PrintInvalidType(key, "int");
        return value;
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
        {"secondFireDelay",                     "0"},
        {"secondFireDeviation",                 "0"},
        {"PlasmaProjectileSpeed",               "200"},
        {"PlasmaProjectileRange",               "1000000"},
        // Tesla parameters
        {"EnableTeslaMod",                      "false"},
        {"TeslaDamage",                         "1000000"},
        // Wheel parameters
        {"EnableWheelMod",                      "false"},
        {"maxRPM",                              "1500"},
        {"groundFrictionMultiplier",            "8"},
        {"stoppingBrakeTorque",                 "4000"},
        {"maxSteeringAngle",                    "30"},
        // Aerofoil parameters
        {"EnableAerofoilMod",                   "true"},
        {"massWithFullLift",                    "0"},
        {"massWithNoLift",                      "0"},
        {"aerofoilMaxCarryingMass",             "1000000"},
        // Jet parameters
        {"EnableJetMod",                        "true"},
        {"ForceMagnitude",                      "2000"},
        // Rotor parameters
        {"EnableRotorMod",                      "false"},
        {"rotorMaxCarryingMass",                "1000000"},
        {"driftAcceleration",                   "0"},
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

