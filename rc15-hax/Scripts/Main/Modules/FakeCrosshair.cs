using UnityEngine;

namespace RC15_HAX;
public class FakeCrosshair : HaxComponents {
    bool UseFakeCrosshair { get; set; } = false;
    float GapSize { get; } = HaxSettings.GetFloat("GapSize");
    float Thickness { get; } = HaxSettings.GetFloat("Thickness");
    float Length { get; } = HaxSettings.GetFloat("Length");

    void OnEnable() {
        InputListener.onF11Press += this.ToggleCrosshair;
    }

    void OnDisable() {
        InputListener.onF11Press -= this.ToggleCrosshair;
    }

    void OnGUI() {
        this.RenderFakeCrosshair();
    }

    void RenderFakeCrosshair() {
        if (!this.UseFakeCrosshair) return;

        float halfWidth = 0.5f * this.Thickness;
        float lengthToCentre = this.GapSize + this.Length;
        Vector2 screenCentre = ScreenInfo.GetScreenCentre();

        // Top crosshair
        Vector2 topCrosshairPosition = new Vector2(screenCentre.x - halfWidth, screenCentre.y - lengthToCentre);
        GUIHelper.DrawBox(topCrosshairPosition, new Size(this.Thickness, this.Length));

        // Right crosshair
        Vector2 rightCrosshairPosition = new Vector2(screenCentre.x + this.GapSize, screenCentre.y - halfWidth);
        GUIHelper.DrawBox(rightCrosshairPosition, new Size(this.Length, this.Thickness));

        // Bottom crosshair
        Vector2 bottomCrosshairPosition = new Vector2(screenCentre.x - halfWidth, screenCentre.y + this.GapSize);
        GUIHelper.DrawBox(bottomCrosshairPosition, new Size(this.Thickness, this.Length));

        // Left crosshair
        Vector2 leftCrosshairPosition = new Vector2(screenCentre.x - lengthToCentre, screenCentre.y - halfWidth);
        GUIHelper.DrawBox(leftCrosshairPosition, new Size(this.Length, this.Thickness));
    }

    void ToggleCrosshair() => this.UseFakeCrosshair = !this.UseFakeCrosshair;
}