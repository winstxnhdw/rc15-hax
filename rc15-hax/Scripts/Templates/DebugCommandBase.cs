namespace RC15_HAX;
public class DebugCommandBase {
    protected string Name { get; set; } = string.Empty;
    protected string Description { get; set; } = string.Empty;
    protected string Format { get; set; } = string.Empty;

    public DebugCommandBase(string commandName, string commandDescription, string commandFormat) {
        this.Name = commandName;
        this.Description = commandDescription;
        this.Format = commandFormat;
    }
}