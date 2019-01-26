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
		//Check if save data is available
		if (list == null)
		{
			SetList(new ArrayList{
			1, "CaptainBob", 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1
			});
		}
		DBManager.InsertORUpdate(list);
	}
	public static ArrayList GetData() {
		return list;
	}

	public static void SetList(ArrayList dataList) {
		list = dataList;

	}
}
