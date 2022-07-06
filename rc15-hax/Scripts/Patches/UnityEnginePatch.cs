using System.Reflection.Emit;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace RC15_HAX;

[HarmonyPatch(typeof(Application), "CommitSuicide", typeof(int))]
public static class UnityEnginePatch {
    public static void PatchUnityEngine() {
        Harmony harmony = new Harmony("winstxnhdw.rc15-hax");
        harmony.PatchAll();
    }

    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions) => new List<CodeInstruction>() { new CodeInstruction(OpCodes.Ret) };
}