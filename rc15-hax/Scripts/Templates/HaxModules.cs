namespace RC15_HAX;
public class HaxModules : HaxComponents {
    protected virtual bool ModEnabled { get => true; }
    protected bool DefaultStored { get; set; } = false;

    protected virtual void OnEnable() {
        if (!this.ModEnabled) return;
        Console.Print($"{this.GetType().Name} component enabled.");
    }

    protected virtual void OnDisable() {
        if (!this.ModEnabled) return;
        Console.Print($"{this.GetType().Name} component disabled.");
    }

    protected void ModifyValues<T>(ref T value, string keyParam) {
        string defaultValue = string.Empty;

        if (!this.DefaultStored) {
            defaultValue = value!.ToString();
            Console.Print($"Default value of {keyParam}: {defaultValue}");
        }

        value = HaxSettings.GetValue<T>(keyParam, defaultValue)!;
    }
}