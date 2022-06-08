namespace RC15_HAX;
public class DebugCommandBase {
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;

    public DebugCommandBase(string commandName, string commandDescription, string commandFormat) {
        this.Name = commandName;
        this.Description = commandDescription;
        this.Format = commandFormat;
    }
}