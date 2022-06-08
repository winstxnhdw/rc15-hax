using System.Collections.Generic;

namespace RC15_HAX;
public class DebugController : HaxComponents {
    public static List<object> CommandList { get; set; } = new List<object>();

    void Awake() {
        this.InitialiseCommands();
    }

    void InitialiseCommands() {
        DebugCommand help = new DebugCommand("help", "Shows a list of commands.", "help", () => {
            Console.Print("Available commands:");

            foreach (DebugCommandBase command in DebugController.CommandList) {
                Console.Print($"{command.Format} — {command.Description}");
            }
        });

        DebugCommand clear = new DebugCommand("clear", "Clears the console.", "clear", Console.ClearConsole);

        DebugCommand pause = new DebugCommand("pause", "Pauses the console.", "pause", Console.PauseConsole);

        DebugController.CommandList = new List<object>() {
            help,
            clear,
            pause
        };
    }
}