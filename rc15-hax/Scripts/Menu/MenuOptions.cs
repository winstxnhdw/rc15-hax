namespace Hax;
public static class MenuOptions {
    public static bool EnableStealth { get; set; } = HaxSettings.GetValue<bool>("EnableStealth");

    public static bool EnablePlayerESP { get; set; } = HaxSettings.GetValue<bool>("EnablePlayerESP");

    public static bool UseFakeCrosshair { get; set; } = false;

    public static bool EnableNetworkDesync { get; set; } = false;
}