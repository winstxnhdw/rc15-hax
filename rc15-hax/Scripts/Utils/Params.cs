namespace RC15_HAX;
public class Params {
    public string Default { get; }
    public string Current { get; }

    public Params(string currentValue, string defaultValue) {
        this.Default = defaultValue;
        this.Current = currentValue;
    }
}