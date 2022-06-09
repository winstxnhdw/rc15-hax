using System.Collections.Generic;

namespace RC15_HAX;
public static class HaxSettings {
    public static bool ParseDefaultValues { get; set; } = false;

    static string GetParamValue(Params param) => HaxSettings.ParseDefaultValues ? param.Default : param.Current;

    static Params GetParams(string key, string defaultValue = "") {
        if (!HaxSettings.Params.TryGetValue(key, out Params param)) Console.Print($"Invalid key: {key}");
        return param;
    }

    static void StoreDefaultValues(string key, string defaultValue) {
        if (string.IsNullOrWhiteSpace(defaultValue)) return;
        HaxSettings.Params[key] = new Params(GetParams(key).Current, defaultValue); ;
    }

    static void PrintInvalidType<T>(string key, string param) {
        Console.Print($"{key} of type {typeof(T).FullName} is invalid. Value: {param}");
    }

    public static T? GetValue<T>(string key, string defaultValue = "") {
        Dictionary<string, Global.Func<string, T>> valueParserDict = new Dictionary<string, Global.Func<string, T>>() {
            {"System.Boolean", (string paramValue) => {
                if (!bool.TryParse(paramValue, out bool value)) PrintInvalidType<T>(key, paramValue);
                return (T)(object)value;
            }},

            {"System.Int32", (string paramValue) => {
                if (!int.TryParse(paramValue, out int value)) PrintInvalidType<T>(key, paramValue);
                return (T)(object)value;
            }},

            {"System.Single", (string paramValue) => {
                if (!float.TryParse(paramValue, out float value)) PrintInvalidType<T>(key, paramValue);
                return (T)(object)value;
            }},
        };

        HaxSettings.StoreDefaultValues(key, defaultValue);
        string paramValue = GetParamValue(GetParams(key));

        if (string.IsNullOrWhiteSpace(paramValue)) {
            Console.Print($"No default values found for {key}.");
            return default(T);
        }

        if (!valueParserDict.TryGetValue(typeof(T).FullName, out Global.Func<string, T> valueParser)) {
            Console.Print("No valid type specified.");
            return default(T);
        }

        return valueParser(paramValue);
    }

    static Params SetParams(string paramValue) => new Params(paramValue, string.Empty);

    // Max int value is 2147483647
    static Dictionary<string, Params> Params { get; } = new Dictionary<string, Params> {
        // Weapon projectile parameters
        {"EnableProjectileMod",                 SetParams("False")},
        {"ProjectileSpeed",                     SetParams("1000000000000")},
        {"ProjectileRange",                     SetParams("1000000000000")},
        // Weapon accuracy parameters
        {"EnableWeaponMod",                     SetParams("True")},
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
        // SMG parameters
        {"EnableSMGMod",                        SetParams("False")},
        {"groupFirePeriod0",                    SetParams("0")},
        {"groupFirePeriod1",                    SetParams("0")},
        {"groupFirePeriod2",                    SetParams("0")},
        {"groupFirePeriod3",                    SetParams("0")},
        {"groupFirePeriod4",                    SetParams("0")},
        {"laserCannonZoomedFoV",                SetParams("60")},
        // Plasma Cannon parameters
        {"EnablePlasmaMod",                     SetParams("False")},
        {"fireTwice",                           SetParams("True")},
        {"secondFireDelay",                     SetParams("0")},
        {"secondFireDeviation",                 SetParams("0")},
        {"PlasmaProjectileSpeed",               SetParams("250")},
        {"PlasmaProjectileRange",               SetParams("1000000000000")},
        {"plasmaFirePeriod0",                   SetParams("0")},
        {"plasmaFirePeriod1",                   SetParams("0")},
        {"plasmaFirePeriod2",                   SetParams("0")},
        {"plasmaFirePeriod3",                   SetParams("0")},
        {"plasmaFirePeriod4",                   SetParams("0")},
        {"plasmaFirePeriod5",                   SetParams("0")},
        {"plasmaFlamFirePeriod",                SetParams("0.5")},
        {"plasmaCannonZoomedFoV",               SetParams("60")},
        // Rail Launcher parameters
        {"EnableRailMod",                       SetParams("True")},
        {"railReloadDuration0",                 SetParams("0")},
        {"railReloadDuration1",                 SetParams("9")},
        {"railReloadDuration2",                 SetParams("9")},
        {"railReloadDuration3",                 SetParams("9")},
        {"railFirePeriod1",                     SetParams("0.3")},
        {"railFirePeriod2",                     SetParams("0.3")},
        {"railFirePeriod3",                     SetParams("0.3")},
        {"railFirePeriod4",                     SetParams("0.3")},
        {"railFirePeriod5",                     SetParams("0.3")},
        {"railFireDelay",                       SetParams("0.7")},
        {"railGunZoomedFov",                    SetParams("60")},
        // Wheel parameters
        {"EnableWheelMod",                      SetParams("False")},
        {"maxRPM",                              SetParams("1000")},
        {"groundFrictionMultiplier",            SetParams("8")},
        {"stoppingBrakeTorque",                 SetParams("4000")},
        {"maxSteeringAngle",                    SetParams("30")},
        // Aerofoil parameters
        {"EnableAerofoilMod",                   SetParams("False")},
        {"aerofoilMaxCarryingMass",             SetParams("1000000000000")},
        {"horizontalCarryingMassScale",         SetParams("0")},
        // Jet parameters
        {"EnableJetMod",                        SetParams("True")},
        {"ForceMagnitude",                      SetParams("2500")},
        // Rotor parameters
        {"EnableRotorMod",                      SetParams("False")},
        {"rotorMaxCarryingMass",                SetParams("1000000000000")},
        {"driftAcceleration",                   SetParams("0")},
        // Leg parameters
        {"EnableLegMod",                        SetParams("True")},
        {"timeGroundedBeforeJump",              SetParams("0")},
        {"lightLegMass",                        SetParams("0")},
        {"heavyLegMass",                        SetParams("0")},
        {"maxUpwardsForce",                     SetParams("25")},
        {"jumpHeight",                          SetParams("2")},
        {"maxWorkingSpeed",                     SetParams("11")},
        {"maxLateralSpeed",                     SetParams("9")},
        // Fake crosshair
        {"GapSize",                             SetParams("7")},
        {"Thickness",                           SetParams("3")},
        {"Length",                              SetParams("15")},
        // ESP parameters
        {"EnablePlayerESP",                     SetParams("True")},
        {"OutlineBoxSize",                      SetParams("4000")},
        {"TextBottomPadding",                   SetParams("20")},
        // General parameters
        {"NoCameraShake",                       SetParams("True")},
        {"NoFog",                               SetParams("True")}
    };
}
