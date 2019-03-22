using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats {

	// Use this for initialization
	public static int points;
	public static string gameName;
	private static ArrayList list;

	//Name, Upgrade Level, Type, Projectile
	public static void Init()
	{
		SetList(DBManager.GetData());
		list[0] = gameName;
		DBManager.UpdateDB(list);		
	}

	public static ArrayList GetData() {
		return list;
	}

	public static void SetList(ArrayList dataList) {
		list = dataList;
	}
}
