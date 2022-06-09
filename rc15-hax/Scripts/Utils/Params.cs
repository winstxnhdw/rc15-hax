namespace RC15_HAX;
public struct Params {
    public string Default { get; }
    public string Current { get; }

    public Params(string currentValue, string defaultValue) {
        this.Default = defaultValue;
        this.Current = currentValue;
    }
}