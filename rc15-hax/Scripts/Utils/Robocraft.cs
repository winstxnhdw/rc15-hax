using System;
using System.Reflection;
using UnityEngine;

namespace RC15_HAX;
public static class Robocraft {
    static Assembly RobocraftAssembly => Assembly.Load("Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null");

    public static Type GetType(string componentName) {
        Type component = Robocraft.RobocraftAssembly.GetType(componentName);

        if (component == null) Console.Print($"Invalid RobocraftType: {componentName}");

        return component;
    }

    public static Component[] GetComponentsInChildren(Component baseComponent, string componentName) => baseComponent.GetComponentsInChildren(Robocraft.GetType(componentName));

    public static Reflector GetReflector(string componentName) => Reflector.Target(Robocraft.GetType(componentName));
}