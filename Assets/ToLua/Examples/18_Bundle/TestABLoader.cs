using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using LuaInterface;
using System;

//click Lua/Build lua bundle
public class TestABLoader : MonoBehaviour 
{
    int bundleCount = int.MaxValue;
    string tips = null;

    IEnumerator CoLoadBundle(string name, string path)
    {
        using (WWW www = new WWW(path))
        {
            if (www == null)
            {
                Debugger.LogError(name + " bundle not exists");
                yield break;
            }

            yield return www;

            if (www.error != null)
            {
                Debugger.LogError(string.Format("Read {0} failed: {1}", path, www.error));
                yield break;
            }

            --bundleCount;
            LuaFileUtils.Instance.AddSearchBundle(name, www.assetBundle);
            www.Dispose();
        }                     
    }

    IEnumerator LoadFinished()
    {
        while (bundleCount > 0)
        {
            yield return null;
        }

        OnBundleLoad();
    }

    public IEnumerator LoadBundles()
    {
        string streamingPath = Application.streamingAssetsPath.Replace('\\', '/');

#if UNITY_5 || UNITY_2017 || UNITY_2018
#if UNITY_ANDROID && !UNITY_EDITOR
        string main = streamingPath + "/" + LuaConst.osDir + "/" + LuaConst.osDir;
#else
        string main = "file:///" + streamingPath + "/" + LuaConst.osDir + "/" + LuaConst.osDir;
#endif
        WWW www = new WWW(main);
        yield return www;

        AssetBundleManifest manifest = (AssetBundleManifest)www.assetBundle.LoadAsset("AssetBundleManifest");
        List<string> list = new List<string>(manifest.GetAllAssetBundles());        
#else
        //此处应该配表获取
        List<string> list = new List<string>() { "lua.unity3d", "lua_cjson.unity3d", "lua_system.unity3d", "lua_unityengine.unity3d", "lua_protobuf.unity3d", "lua_misc.unity3d", "lua_socket.unity3d", "lua_system_reflection.unity3d" };
#endif
        bundleCount = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            string str = list[i];

#if UNITY_ANDROID && !UNITY_EDITOR
            string path = streamingPath + "/" + LuaConst.osDir + "/" + str;
#else
            string path = "file:///" + streamingPath + "/" + LuaConst.osDir + "/" + str;
#endif
            string name = Path.GetFileNameWithoutExtension(str);
            StartCoroutine(CoLoadBundle(name, path));            
        }

        yield return StartCoroutine(LoadFinished());
    }

    void Awake()
    {
#if UNITY_5 || UNITY_2017 || UNITY_2018
        Application.logMessageReceived += ShowTips;
#else
        Application.RegisterLogCallback(ShowTips);
#endif
        LuaFileUtils file = new LuaFileUtils();
        file.beZip = true;
#if UNITY_ANDROID && UNITY_EDITOR
        if (IntPtr.Size == 8)
        {
            throw new Exception("can't run this in unity5.x process for 64 bits, switch to pc platform, or run it in android mobile");
        }
#endif
        StartCoroutine(LoadBundles());
    }

    void ShowTips(string msg, string stackTrace, LogType type)
    {
        tips += msg;
        tips += "\r\n";
    }
    

    void OnApplicationQuit()
    {
#if UNITY_5 || UNITY_2017 || UNITY_2018
        Application.logMessageReceived -= ShowTips;
#else
        Application.RegisterLogCallback(null);
        state.Dispose();
        state = null;
#endif
    }

    private LuaState state;
    
    void OnBundleLoad()
    {                
        state = new LuaState();
        state.Start();
        state.DoString("print('hello tolua#:'..tostring(Vector3.zero))");
        state.DoFile("TestPerf.lua"); 
        state.DoFile("Main.lua");
        LuaFunction func = state.GetFunction("Main");
        func.Call();
        func.Dispose();
	}	
    
     void OnGUI()
    {        
        GUI.Label(new Rect(Screen.width / 2 - 220, Screen.height / 2 - 200, 400, 400), tips);

        if (GUI.Button(new Rect(50, 50, 120, 45), "Test1"))
        {
            float time = Time.realtimeSinceStartup;            

            for (int i = 0; i < 200000; i++)
            {
                Vector3 v = transform.position;
                transform.position = v + Vector3.one;
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("c# Transform getset cost time: " + time);            
            transform.position = Vector3.zero;

            LuaFunction func = state.GetFunction("Test1");
            func.BeginPCall();
            func.Push(transform);
            func.PCall();
            func.EndPCall();
            func.Dispose();
            func = null;            
        }
        else if (GUI.Button(new Rect(50, 150, 120, 45), "Test2"))
        {
            float time = Time.realtimeSinceStartup;

            for (int i = 0; i < 200000; i++)
            {
                transform.Rotate(Vector3.up, 1);
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("c# Transform.Rotate cost time: " + time);

            LuaFunction func = state.GetFunction("Test2");
            func.BeginPCall();
            func.Push(transform);
            func.PCall();
            func.EndPCall();
            func.Dispose();
            func = null;    
        }
        else if (GUI.Button(new Rect(50, 250, 120, 45), "Test3"))
        {
            float time = Time.realtimeSinceStartup;            

            for (int i = 0; i < 2000000; i++)
            {
                new Vector3(i, i, i);
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("c# new Vector3 cost time: " + time);            

            LuaFunction func = state.GetFunction("Test3");
            func.Call();
            func.Dispose();
            func = null;  
        }
        else if (GUI.Button(new Rect(50, 350, 120, 45), "Test4"))
        {
            float time = Time.realtimeSinceStartup;

            for (int i = 0; i < 20000; i++)
            {
                new GameObject();
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("c# new GameObject cost time: " + time);

            //光gc了
            LuaFunction func = state.GetFunction("Test4");
            func.Call();
            func.Dispose();
            func = null;
        }
        else if (GUI.Button(new Rect(50, 450, 120, 45), "Test5"))
        {            
            int[] array = new int[1024];

            for (int i = 0; i < 1024; i++)
            {
                array[i] = i;
            }

            float time = Time.realtimeSinceStartup;
            int total = 0;

            for (int j = 0; j < 100000; j++)
            {
                for (int i = 0; i < 1024; i++)
                {
                    total += array[i];
                }
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("Array cost time: " + time);

            List<int> list = new List<int>(array);
            time = Time.realtimeSinceStartup;
            total = 0;

            for (int j = 0; j < 100000; j++)
            {
                for (int i = 0; i < 1024; i++)
                {
                    total += list[i];
                }
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("Array cost time: " + time);

            LuaFunction func = state.GetFunction("TestTable");
            func.Call();
            func.Dispose();
            func = null;            
        }
        else if (GUI.Button(new Rect(50, 550, 120, 40), "Test7"))
        {            
            float time = Time.realtimeSinceStartup;
            Vector3 v1 = Vector3.zero;

            for (int i = 0; i < 200000; i++)
            {
                Vector3 v = new Vector3(i,i,i);
                v = Vector3.Normalize(v);
                v1 = v + v1;
            }

            time = Time.realtimeSinceStartup - time;            
            tips = "";
            Debugger.Log("Vector3 New Normalize cost: " + time);
            LuaFunction func = state.GetFunction("Test7");
            func.Call();
            func.Dispose();
            func = null;  
        }
        else if (GUI.Button(new Rect(250, 50, 120, 40), "Test8"))
        {
            float time = Time.realtimeSinceStartup;

            for (int i = 0; i < 200000; i++)
            {
		        Quaternion q1 = Quaternion.Euler(i, i, i);
                Quaternion q2 = Quaternion.Euler(i * 2, i * 2, i * 2);
                Quaternion.Slerp(q1, q2, 0.5f);
            }

            time = Time.realtimeSinceStartup - time;
            tips = "";
            Debugger.Log("Quaternion Euler Slerp cost: " + time);

            LuaFunction func = state.GetFunction("Test8");
            func.Call();
            func.Dispose();
            func = null;
        }
        else if (GUI.Button(new Rect(250, 150, 120, 40), "Test9"))
        {
            tips = "";
            LuaFunction func = state.GetFunction("Test9");
            func.Call();
            func.Dispose();
            func = null;
        }
        else if (GUI.Button(new Rect(250, 250, 120, 40), "Quit"))
        {
            Application.Quit();
        }

        if (state != null)
        {
            state.CheckTop();
            state.Collect();
        }
    }
}
