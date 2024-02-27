﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class LuaProfilerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("LuaProfiler");
		L.RegFunction("Clear", new LuaCSFunction(Clear));
		L.RegFunction("GetID", new LuaCSFunction(GetID));
		L.RegFunction("BeginSample", new LuaCSFunction(BeginSample));
		L.RegFunction("EndSample", new LuaCSFunction(EndSample));
		L.RegVar("list", new LuaCSFunction(get_list), new LuaCSFunction(set_list));
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaProfiler.Clear();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetID(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			int o = LuaProfiler.GetID(arg0);
			LuaDLL.lua_pushinteger(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int BeginSample(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			int arg0 = (int)LuaDLL.luaL_checkinteger(L, 1);
			LuaProfiler.BeginSample(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EndSample(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			LuaProfiler.EndSample();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_list(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, LuaProfiler.list);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_list(IntPtr L)
	{
		try
		{
			System.Collections.Generic.List<string> arg0 = (System.Collections.Generic.List<string>)ToLua.CheckObject(L, 2, TypeTraits<System.Collections.Generic.List<string>>.type);
			LuaProfiler.list = arg0;
			LuaProfiler.list = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

