using System;

namespace RC15_HAX;
public class DebugCommand : DebugCommandBase {
    Action Command { get; set; }

    public DebugCommand(string commandName, string commandDescription, string commandFormat, Action command) : base(commandName, commandDescription, commandFormat) {
        this.Command = command;
    }

    public void Invoke() {
        this.Command();
    }
}

public class DebugCommand<T> : DebugCommandBase {
    Action<T> Command { get; set; }

    public DebugCommand(string commandName, string commandDescription, string commandFormat, Action<T> command) : base(commandName, commandDescription, commandFormat) {
        this.Command = command;
    }

    public void Invoke(T value) => this.Command(value);
}