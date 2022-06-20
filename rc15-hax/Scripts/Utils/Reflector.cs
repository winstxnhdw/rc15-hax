using System;
using System.Diagnostics;
using System.Reflection;

namespace RC15_HAX;
public class Reflector {
    const BindingFlags InternalField = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField;
    const BindingFlags InternalProperty = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty;
    const BindingFlags InternalMethod = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod;

    const BindingFlags PublicField = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField;
    const BindingFlags PublicProperty = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
    const BindingFlags PublicMethod = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;

    Type Type { get; }

    public Reflector(object type) {
        this.Type = type.GetType();
    }

    public T GetInternalField<T>(string variableName) {
        try {
            return (T)this.Type.GetField(variableName, Reflector.InternalField)
                               .GetValue(this.Type);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public object GetInternalProperty(string propertyName) {
        try {
            return this.Type.GetProperty(propertyName, Reflector.InternalProperty)
                            .GetValue(this.Type, null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public T GetPublicField<T>(string variableName) {
        try {
            return (T)this.Type.GetField(variableName, Reflector.PublicField)
                               .GetValue(this.Type);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public object GetPublicProperty(string propertyName) {
        try {
            return this.Type.GetProperty(propertyName, Reflector.PublicProperty)
                            .GetValue(this.Type, null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public Reflector SetInternalField(string variableName, object value) {
        try {
            this.Type.GetField(variableName, Reflector.InternalField)
                     .SetValue(this.Type, value);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector SetPublicField(string variableName, object value) {
        try {
            this.Type.GetField(variableName, Reflector.PublicField)
                     .SetValue(this.Type, value);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector InvokeInternalMethod(string methodName, object[] parameters) {
        try {
            this.Type.GetMethod(methodName, Reflector.InternalMethod)
                     .Invoke(this.Type, parameters);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector InvokePublicMethod(string methodName, params object[] args) {
        try {
            this.Type.GetMethod(methodName, Reflector.PublicMethod)
                     .Invoke(this.Type, args);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public void LogReflectionError(Exception e) {
        Console.Print($"Reflection Error in {new StackFrame(2).GetMethod().Name}:\n{e}");
    }
}