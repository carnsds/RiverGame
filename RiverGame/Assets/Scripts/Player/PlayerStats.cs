using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using iBoxDB.LocalServer;

public static class PlayerStats {

	// Use this for initialization
	public static int points;
	public static string gameName;
	public static Dictionary<int, string> fleet;
	public static List<ArrayList> list;

	//Name, Upgrade Level, Type, Projectile
	public static void Init()
	{
		//Check if save data is available
		if (list != null)
		{
			//"game_name-name-boat1#1#2#4boat2#";
		}
	}
}
