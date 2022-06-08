using System.Collections.Generic;
using UnityEngine;
using Simulation;

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

        DebugCommand status = new DebugCommand("status", "Shows the status of the cheat.", "status", () => {
            Console.Print($"HaxSettings.ParseDefaultValues: {HaxSettings.ParseDefaultValues}");
            Console.Print($"HaxPaused: {Hax.HaxPaused}");
        });

        DebugCommand player = new DebugCommand("player", "Shows your status.", "player", () => {
            LocalPlayerRigidbody playerRigidbody = HaxObjects.PlayerRigidbody.Object;

            if (playerRigidbody == null) {
                Console.Print("Exists: false");
                return;
            }

            Rigidbody rigidbody = playerRigidbody.rb;
            Console.Print("Exists: true");
            Console.Print($"Position: x: {rigidbody.worldCenterOfMass.x}, y: {rigidbody.worldCenterOfMass.y}, z: {rigidbody.worldCenterOfMass.z}");
            Console.Print($"Velocity: {rigidbody.velocity} m/s");
        });

        DebugCommand clear = new DebugCommand("clear", "Clears the console.", "clear", Console.ClearConsole);

        DebugCommand pause = new DebugCommand("pause", "Pauses the console.", "pause", Console.PauseConsole);

        DebugController.CommandList = new List<object>() {
            help,
            clear,
            pause,
            status,
            player
        };
    }
}