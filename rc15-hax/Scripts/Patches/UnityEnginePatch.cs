using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using HarmonyLib;

namespace Hax;

[HarmonyPatch(typeof(Application), "CommitSuicide", typeof(int))]
public static class UnityEnginePatch {
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> _) => new[] { new CodeInstruction(OpCodes.Ret) };
}