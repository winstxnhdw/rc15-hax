using System.Collections.Generic;
using UnityEngine;

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

        DebugCommand me = new DebugCommand("player", "Shows your status.", "player", () => {
            Rigidbody rigidbody = HaxObjects.PlayerRigidbody;

            if (rigidbody == null) {
                Console.Print("Exists: false");
                return;
            }

            Console.Print("Exists: true");
            Console.Print($"Player ID: {Teams.PlayerID}");
            Console.Print($"Team ID: {Teams.PlayerTeamID}");
            Console.Print($"Position: x: {rigidbody.worldCenterOfMass.x}, y: {rigidbody.worldCenterOfMass.y}, z: {rigidbody.worldCenterOfMass.z}");
            Console.Print($"Velocity: {rigidbody.velocity} m/s");
        });

        DebugCommand<string> players = new DebugCommand<string>("players", "Shows player information.", "players <arg>", (string arg) => {
            switch (arg) {
                case "all":
                    foreach (KeyValuePair<int, Dictionary<int, string>> team in Teams.AllPlayers) {
                        Console.Print($"\nTeam {team.Key}:");
                        foreach (KeyValuePair<int, string> player in team.Value) {
                            Console.Print($"#{player.Key}: {player.Value}");
                        }
                    }
                    return;

                case "team":
                    foreach (KeyValuePair<int, string> player in Teams.AllPlayers[Teams.PlayerTeamID]) {
                        Console.Print($"Your team:\n#{player.Key}: {player.Value}");
                    }
                    return;

                case "enemy":
                    foreach (KeyValuePair<int, string> player in Teams.AllPlayers[Enemy.EnemyTeamID]) {
                        Console.Print($"Enemy team:\n#{player.Key}: {player.Value}");
                    }
                    return;

                default:
                    Console.Print($"Invalid argument.");
                    return;
            }
        });

        DebugCommand clear = new DebugCommand("clear", "Clears the console.", "clear", Console.ClearConsole);

        DebugCommand pause = new DebugCommand("pause", "Pauses the console.", "pause", Console.PauseConsole);

        DebugController.CommandList = new List<object>() {
            help,
            clear,
            pause,
            status,
            me,
            players,
        };

        this.ConvertSettingsToCommands();
    }

    void ConvertSettingsToCommands() {
        foreach (KeyValuePair<string, Params> settings in HaxSettings.Params) {
            DebugCommand<string> command = new DebugCommand<string>(settings.Key, $"Sets the value of {settings.Key}", $"{settings.Key} <value>",
            (string newValue) => {
                HaxSettings.Params[settings.Key] = new Params(newValue, settings.Value.Default);
                Console.Print($"{settings.Key} is now set from {settings.Value.Current} to {newValue}.");
            });

            DebugController.CommandList.Add(command);
        }
    }
}