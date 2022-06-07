namespace RC15_HAX;
public class HaxModules : HaxComponents {
    protected bool DefaultStored { get; set; } = false;

    protected virtual void OnEnable() {
        Console.Print($"{this.GetType().Name} component enabled.");
    }

    protected virtual void OnDisable() {
        Console.Print($"{this.GetType().Name} component disabled.");
    }

    protected void ModifyValues(ref float value, string keyParam) {
        string defaultValue = !this.DefaultStored ? value.ToString() : "";
        value = HaxSettings.GetFloat(keyParam, defaultValue);
    }

    protected void ModifyValues(ref int value, string keyParam) {
        string defaultValue = !this.DefaultStored ? value.ToString() : "";
        value = HaxSettings.GetInt(keyParam, defaultValue);
    }

    protected void ModifyValues(ref bool value, string keyParam) {
        string defaultValue = !this.DefaultStored ? value.ToString() : "";
        value = HaxSettings.GetBool(keyParam, defaultValue);
    }
}