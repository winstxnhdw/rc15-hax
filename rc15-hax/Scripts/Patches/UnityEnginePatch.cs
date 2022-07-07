using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using HarmonyLib;

namespace RC15_HAX;

[HarmonyPatch(typeof(Application), "CommitSuicide", typeof(int))]
public static class UnityEnginePatch {
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> _) => new[] { new CodeInstruction(OpCodes.Ret) };
}