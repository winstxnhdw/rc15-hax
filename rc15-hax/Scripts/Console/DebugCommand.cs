namespace RC15_HAX;
public class DebugCommand : DebugCommandBase {
    Global.Action Command { get; set; }

    public DebugCommand(string commandName, string commandDescription, string commandFormat, Global.Action command) : base(commandName, commandDescription, commandFormat) {
        this.Command = command;
    }

    public void Invoke() {
        this.Command.Invoke();
    }
}

public class DebugCommand<T> : DebugCommandBase {
    Global.Action<T> Command { get; set; }

    public DebugCommand(string commandName, string commandDescription, string commandFormat, Global.Action<T> command) : base(commandName, commandDescription, commandFormat) {
        this.Command = command;
    }

    public void Invoke(T value) => this.Command.Invoke(value);
}