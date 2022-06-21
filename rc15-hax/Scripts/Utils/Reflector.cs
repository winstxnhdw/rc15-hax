using System;
using System.Diagnostics;
using System.Reflection;

namespace RC15_HAX;
public class Reflector {
    const BindingFlags InternalField = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField;
    const BindingFlags InternalProperty = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty;
    const BindingFlags InternalMethod = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod;
    const BindingFlags StaticInternalField = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetField;
    const BindingFlags StaticInternalProperty = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.GetProperty;
    const BindingFlags StaticInternalMethod = BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod;

    const BindingFlags PublicField = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetField;
    const BindingFlags PublicProperty = BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty;
    const BindingFlags PublicMethod = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;
    const BindingFlags PublicStaticField = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField;
    const BindingFlags PublicStaticProperty = BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty;
    const BindingFlags PublicStaticMethod = BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod;

    object Obj { get; }
    Type ObjType { get; }

    public Reflector(object obj) {
        this.Obj = obj;
    }

    public Reflector(Type objType) {
        this.ObjType = objType;
    }

    Type GetObjectType() {
        if (this.ObjType != null) return this.ObjType;
        return this.Obj.GetType();
    }

    public T GetInternalField<T>(string variableName) {
        try {
            return (T)this.GetObjectType()
                          .GetField(variableName, Reflector.InternalField)
                          .GetValue(this.Obj);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public T GetInternalStaticField<T>(string variableName) {
        try {
            return (T)this.GetObjectType()
                          .GetField(variableName, Reflector.StaticInternalField)
                          .GetValue(null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public object GetInternalProperty(string propertyName) {
        try {
            return this.GetObjectType()
                       .GetProperty(propertyName, Reflector.InternalProperty)
                       .GetValue(this.Obj, null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }


    public T GetPublicField<T>(string variableName) {
        try {
            return (T)this.GetObjectType()
                          .GetField(variableName, Reflector.PublicField)
                          .GetValue(this.Obj);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public object GetPublicProperty(string propertyName) {
        try {
            return this.GetObjectType()
                       .GetProperty(propertyName, Reflector.PublicProperty)
                       .GetValue(this.Obj, null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public Reflector SetInternalField(string variableName, object value) {
        try {
            this.GetObjectType()
                .GetField(variableName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField)
                .SetValue(this.Obj, value);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector SetPublicField(string variableName, object value) {
        try {
            this.GetObjectType()
                .GetField(variableName, Reflector.PublicField)
                .SetValue(this.Obj, value);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector SetInternalStaticField(string variableName, object value) {
        try {
            this.GetObjectType()
                .GetField(variableName, Reflector.StaticInternalField)
                .SetValue(null, value);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public Reflector SetPublicProperty(string propertyName, object value) {
        try {
            this.GetObjectType()
                .GetProperty(propertyName, Reflector.PublicProperty)
                .SetValue(this.Obj, value, null);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
        }

        return this;
    }

    public T InvokeInternalMethod<T>(string methodName, params object[] args) {
        try {
            return (T)this.GetObjectType()
                          .GetMethod(methodName, Reflector.InternalMethod)
                          .Invoke(this.Obj, args);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public T InvokePublicMethod<T>(string methodName, params object[] args) {
        try {
            return (T)this.GetObjectType()
                          .GetMethod(methodName, Reflector.PublicMethod)
                          .Invoke(this.Obj, args);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public T InvokePublicStaticMethod<T>(string methodName, params object[] args) {
        try {
            return (T)this.GetObjectType()
                          .GetMethod(methodName, Reflector.PublicStaticMethod)
                          .Invoke(null, args);
        }

        catch (Exception e) {
            this.LogReflectionError(e);
            return default;
        }
    }

    public void LogReflectionError(Exception e) {
        Console.Print($"Reflection Error in {new StackFrame(2).GetMethod().Name}:\n{e}");
    }
}