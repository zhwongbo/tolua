﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_AnimationClipWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.AnimationClip), typeof(UnityEngine.Object));
		L.RegFunction("SampleAnimation", new LuaCSFunction(SampleAnimation));
		L.RegFunction("SetCurve", new LuaCSFunction(SetCurve));
		L.RegFunction("EnsureQuaternionContinuity", new LuaCSFunction(EnsureQuaternionContinuity));
		L.RegFunction("ClearCurves", new LuaCSFunction(ClearCurves));
		L.RegFunction("IsCloudResource", new LuaCSFunction(IsCloudResource));
		L.RegFunction("AddEvent", new LuaCSFunction(AddEvent));
		L.RegFunction("New", new LuaCSFunction(_CreateUnityEngine_AnimationClip));
		L.RegFunction("__eq", new LuaCSFunction(op_Equality));
		L.RegFunction("__tostring", new LuaCSFunction(ToLua.op_ToString));
		L.RegVar("length", new LuaCSFunction(get_length), null);
		L.RegVar("frameRate", new LuaCSFunction(get_frameRate), new LuaCSFunction(set_frameRate));
		L.RegVar("wrapMode", new LuaCSFunction(get_wrapMode), new LuaCSFunction(set_wrapMode));
		L.RegVar("localBounds", new LuaCSFunction(get_localBounds), new LuaCSFunction(set_localBounds));
		L.RegVar("legacy", new LuaCSFunction(get_legacy), new LuaCSFunction(set_legacy));
		L.RegVar("humanMotion", new LuaCSFunction(get_humanMotion), null);
		L.RegVar("empty", new LuaCSFunction(get_empty), null);
		L.RegVar("hasGenericRootTransform", new LuaCSFunction(get_hasGenericRootTransform), null);
		L.RegVar("hasMotionFloatCurves", new LuaCSFunction(get_hasMotionFloatCurves), null);
		L.RegVar("hasMotionCurves", new LuaCSFunction(get_hasMotionCurves), null);
		L.RegVar("hasRootCurves", new LuaCSFunction(get_hasRootCurves), null);
		L.RegVar("events", new LuaCSFunction(get_events), new LuaCSFunction(set_events));
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateUnityEngine_AnimationClip(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.AnimationClip obj = new UnityEngine.AnimationClip();
				ToLua.PushSealed(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: UnityEngine.AnimationClip.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SampleAnimation(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject<UnityEngine.GameObject>(L, 2);
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			obj.SampleAnimation(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetCurve(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 5);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			System.Type arg1 = ToLua.CheckMonoType(L, 3);
			string arg2 = ToLua.CheckString(L, 4);
			UnityEngine.AnimationCurve arg3 = (UnityEngine.AnimationCurve)ToLua.CheckObject<UnityEngine.AnimationCurve>(L, 5);
			obj.SetCurve(arg0, arg1, arg2, arg3);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnsureQuaternionContinuity(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			obj.EnsureQuaternionContinuity();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearCurves(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			obj.ClearCurves();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsCloudResource(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			bool o = obj.IsCloudResource();
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)ToLua.CheckObject<UnityEngine.AnimationClip>(L, 1);
			UnityEngine.AnimationEvent arg0 = (UnityEngine.AnimationEvent)ToLua.CheckObject<UnityEngine.AnimationEvent>(L, 2);
			obj.AddEvent(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_length(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			float ret = obj.length;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index length on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_frameRate(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			float ret = obj.frameRate;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index frameRate on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_wrapMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.WrapMode ret = obj.wrapMode;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index wrapMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_localBounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.Bounds ret = obj.localBounds;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index localBounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_legacy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.legacy;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index legacy on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_humanMotion(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.humanMotion;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index humanMotion on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_empty(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.empty;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index empty on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasGenericRootTransform(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.hasGenericRootTransform;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hasGenericRootTransform on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasMotionFloatCurves(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.hasMotionFloatCurves;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hasMotionFloatCurves on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasMotionCurves(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.hasMotionCurves;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hasMotionCurves on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_hasRootCurves(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool ret = obj.hasRootCurves;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index hasRootCurves on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_events(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.AnimationEvent[] ret = obj.events;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index events on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_frameRate(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.frameRate = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index frameRate on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_wrapMode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.WrapMode arg0 = (UnityEngine.WrapMode)ToLua.CheckObject(L, 2, TypeTraits<UnityEngine.WrapMode>.type);
			obj.wrapMode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index wrapMode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_localBounds(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.Bounds arg0 = ToLua.ToBounds(L, 2);
			obj.localBounds = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index localBounds on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_legacy(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.legacy = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index legacy on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_events(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.AnimationClip obj = (UnityEngine.AnimationClip)o;
			UnityEngine.AnimationEvent[] arg0 = ToLua.CheckObjectArray<UnityEngine.AnimationEvent>(L, 2);
			obj.events = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index events on a nil value");
		}
	}
}

