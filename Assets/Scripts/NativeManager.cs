
using System;
using UnityEngine;


/// <summary>
/// 平台native接口管理器
/// </summary>
public class NativeMgr
{
// #if UNITY_OPENHARMONY && !UNITY_EDITOR
    /// <summary>
    /// 静态调用native函数,无返回值
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    public static void CallStatic(string clazz, string method, params object[] param)
    {
        Debug.Log(String.Format("NativeBridge CallStatic by Editor -> [clazz]:{0}, [method]:{1}, [param]:{2}",
            clazz, method, param));
        OpenHarmonyJSClass openHarmonyJsClass = new OpenHarmonyJSClass(clazz);
        openHarmonyJsClass.CallStatic(method, param);
    }

    public static object Callback(params OpenHarmonyJSObject[] args)
    {
        foreach (var arg in args)
        {
            Debug.Log(
                $"NativeBridge OpenHarmonyJSCallback msg: {arg.Get<string>("msg")} err: {arg.Get<string>("err")}");
        }

        return "";
    }

    /// <summary>
    /// 调用实例方法
    /// </summary>
    /// <param name="clazz"></param>
    /// <param name="method"></param>
    /// <param name="param"></param>
    public static void Call(string clazz, string method, params object[] param)
    {
        var jsObject = new OpenHarmonyJSObject(clazz);
        jsObject.Call(method, param);
    }
    
    /// <summary>
    /// 返回指定类型的调用
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>T</returns>
    public static T CallValue<T>(string clazz, string method, params object[] param)
    {
        var jsObject = new OpenHarmonyJSObject(clazz);
        return jsObject.Call<T>(method, param);
    }

    /// <summary>
    /// 静态调用native函数,返回值string
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <returns>string</returns>
    public static string CallStaticStringDefault(string clazz, string method, params object[] param)
    {
        return CallStaticValue<string>(clazz, method, param);
    }

    /// <summary>
    /// 静态调用native函数,返回值int
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <returns>int</returns>
    public static int CallStaticIntDefault(string clazz, string method, params object[] param)
    {
        return CallStaticValue<int>(clazz, method, param);
    }

    /// <summary>
    /// 静态调用native函数,返回值bool
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <returns>bool</returns>
    public static bool CallStaticBoolDefault(string clazz, string method, params object[] param)
    {
        return CallStaticValue<bool>(clazz, method, param);
    }

    /// <summary>
    /// 静态调用native函数,返回值long
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <param name="defaultValue">默认值</param>
    /// <returns>long</returns>
    public static long CallStaticLongDefault(string clazz, string method, params object[] param)
    {
        return CallStaticValue<long>(clazz, method, param);
    }

    /// <summary>
    /// 静态调用native函数,返回值float
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <param name="defaultValue">默认值</param>
    /// <returns>float</returns>
    public static float CallStaticFloatDefault(string clazz, string method, params object[] param)
    {
        return CallStaticValue<float>(clazz, method, param);
    }

    /// <summary>
    /// 返回指定类型的静态native调用
    /// </summary>
    /// <param name="clazz">类型</param>
    /// <param name="method">方法</param>
    /// <param name="param">参数</param>
    /// <typeparam name="T">类型</typeparam>
    /// <returns>T</returns>
    private static T CallStaticValue<T>(string clazz, string method, params object[] param)
    {
        Debug.Log(String.Format("NativeBridge CallStatic by Editor -> [clazz]:{0}, [method]:{1}, [param]:{2}",
            clazz, method, param));
        OpenHarmonyJSClass openHarmonyJsClass = new OpenHarmonyJSClass(clazz);
        return openHarmonyJsClass.CallStatic<T>(method, param);
    }
// #endif
}
