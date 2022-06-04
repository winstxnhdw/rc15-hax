using System.Collections.Generic;

namespace RC15_HAX;
public static class HaxSettings {
    public static Dictionary<string, string> Params { get; } = new Dictionary<string, string> {
        // Weapon projectile parameters
        {"ProjectileSpeed",                     "1000000"},
        {"ProjectileImpactForce",               "1000000"},
        {"ProjectileRange",                     "1000000"},
        {"ProtoniumDamageScale",                "1000000"},
        // Weapon accuracy parameters
        {"RecoilForce",                         "1000000"},
        {"BaseInAccuracyDegrees",               "0"},
        {"MovementInAccuracyDegrees",           "0"},
        {"RepeatFireInAccuracyTotalDegrees",    "0"},
        // Weapon movement limits
        {"AimSpeed",                            "1000000"},
        {"MaxHorizAngle",                       "180"},
        {"MinHorizAngle",                       "-180"},
        {"MaxVerticalAngle",                    "180"},
        {"MinVerticalAngle",                    "-180"},
        // Wheel parameters
        {"maxRPM",                              "2000"},
        {"groundFrictionMultiplier",            "3"},
        // Aerofoil parameters
        {"dragMinVelocity",                     "1000000"},
        {"dragMaxVelocity",                     "1000000"},
        // Jet parameters
        {"ForceMagnitude",                      "15000"},
        {"MaxVelocity",                         "1000000"},
        // General parameters
        {"EnableESP",                           "true"}
    };
}