namespace RC15_HAX;
public class HaxModules : HaxComponents {
    protected bool DefaultStored { get; set; } = false;

    protected virtual void OnEnable() {
        Console.Print($"{this.GetType().Name} component enabled.");
    }

    protected virtual void OnDisable() {
        Console.Print($"{this.GetType().Name} component disabled.");
    }

    protected void ModifyValues<T>(ref T value, string keyParam) {
        string defaultValue = string.Empty;

        if (!this.DefaultStored) {
            defaultValue = value!.ToString();
            Console.Print($"Default value of {keyParam}: {defaultValue}");
        }

        value = HaxSettings.GetValue<T>(keyParam, defaultValue);
    }
}