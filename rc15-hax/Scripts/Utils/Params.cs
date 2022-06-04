namespace RC15_HAX;
public struct Params {
    string Default { get; set; }
    string Current { get; set; }

    public Params(string defaultValue, string currentValue) {
        this.Default = defaultValue;
        this.Current = currentValue;
    }
}