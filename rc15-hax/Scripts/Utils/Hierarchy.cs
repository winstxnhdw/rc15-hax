using UnityEngine;

namespace RC15_HAX;
public static class Hierarchy {
    public static void PrintAllAncestors(Transform transform) {
        Console.Print($"Layer {transform.gameObject.layer}: {transform.name}");
        if (transform.parent != null) Hierarchy.PrintAllAncestors(transform.parent);
    }

    public static void PrintAllDescendents(Transform transform) {
        Console.Print($"Layer {transform.gameObject.layer}: {transform.name}");
        foreach (Transform child in transform) Hierarchy.PrintAllDescendents(child);
    }
}