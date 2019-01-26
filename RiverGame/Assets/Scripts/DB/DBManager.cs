using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;


 //using System.Xml.Serialization;

public class DBManager : MonoBehaviour
{
    
    private static IDbConnection dbcon;
    private static string connection;
    public const string ID = "id";
    public const string NAME = "name";
    public const string POINTS = "points";
    public const string BOAT1 = "boat1";
    public const string BOAT1LVL = "b1lvl";
    public const string BOAT2 = "boat2";
    public const string BOAT2LVL = "b2lvl";
    public const string BOAT3 = "boat3";
    public const string BOAT3LVL = "b3lvl";
    public const string BOAT4 = "boat4";
    public const string BOAT4LVL = "b4lvl";
    public const string BOAT5 = "boat5";
    public const string BOAT5LVL = "b5lvl";

    public static int GAME_STATE = 1;
    public void Start() 
    {
        connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
        IDbCommand dbcmd;
        IDataReader reader;
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string q_createTable = 
        "CREATE TABLE IF NOT EXISTS game_states "+
        "(" + ID +" INTEGER PRIMARY KEY, " + NAME +" VARCHAR, " + POINTS + " INTEGER, " + BOAT1 + " INTEGER, " + BOAT1LVL + " INTEGER"
        + ", " + BOAT2 + " INTEGER, " + BOAT2LVL + " INTEGER, " + BOAT3 + " INTEGER, " + BOAT3LVL + " INTEGER, " + BOAT4
        + " INTEGER, " + BOAT4LVL + " INTEGER, " + BOAT5 + " INTEGER, " + BOAT5LVL + " INTEGER );";
        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
    }

    public static void InsertORUpdate(ArrayList data) 
    {
        /* connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
        dbcon = new SqliteConnection(connection);
        dbcon.Open();*/
        if (GAME_STATE >= 1 && GAME_STATE <= 3)
        {
            IDbCommand cmnd = dbcon.CreateCommand();
            cmnd.CommandText = "SELECT * FROM game_states WHERE ID=" + "\"" + GAME_STATE + "\";";
            IDataReader reader = cmnd.ExecuteReader();
            if (((System.Data.Common.DbDataReader)reader).HasRows) 
            {
                PlayerStats.SetList(getData(reader));
                //reader;
                reader.Close();
                cmnd.Prepare();
                //dbcon.Dispose();
                //dbcon.Open();
                cmnd = dbcon.CreateCommand();
                //dbcon = new SqliteConnection(connection);
                //dbcon.Open();
                cmnd.CommandText = "UPDATE game_states SET " + ID + "= " + data[0]
                + ", " + NAME + "= \"" + data[1] 
                + "\", "+ POINTS + "= " + data[2]
                + ", "+ BOAT1 + "= " + data[3]
                + ", " + BOAT1LVL + "= " + data[4]
                + ", "+ BOAT2 + "= " + data[5]
                + ", " + BOAT2LVL + "= " + data[6]
                + ", "+ BOAT3 + "= " + data[7]
                + ", " + BOAT3LVL + "= " + data[8]
                + ", "+ BOAT4 + "= " + data[9]
                + ", " + BOAT4LVL + "= " + data[10]
                + ", "+ BOAT5 + "= " + data[11]
                + ", " + BOAT5LVL+ "= " + data[12]
                +" WHERE ID=\"" + GAME_STATE + "\";";
                cmnd.ExecuteNonQuery();
                reader = cmnd.ExecuteReader();
                
                //dbcon.Close();
            }
            else 
            {
                ArrayList list = PlayerStats.GetData();
                reader.Dispose();
                //dbcon = new SqliteConnection(connection);
                //dbcon.Open();
                cmnd.CommandText = "INSERT INTO game_states (" + ID + ", " 
                + NAME + ", "+ POINTS 
                + ", "+ BOAT1 + ", " + BOAT1LVL
                + ", "+ BOAT2 + ", " + BOAT2LVL
                + ", "+ BOAT3 + ", " + BOAT3LVL
                + ", "+ BOAT4 + ", " + BOAT4LVL
                + ", "+ BOAT5 + ", " + BOAT5LVL
                + ") VALUES (" + list[0] + ", \"" + list[1] + "\", " + list[2] 
                + ", " + list[3] + ", " + list[4] + ", -1, -1, -1, -1, -1, -1, -1, -1);";
                cmnd.ExecuteNonQuery();
            }
        }
        //dbcon.Close();
    }

    public static void Close() {
        dbcon.Close();
    }

    private static ArrayList getData(IDataReader reader) {
        ArrayList list = new ArrayList(13);
        list.Add(reader[0]);
        list.Add((string) reader[1]);
        list.Add(reader[2]);
        list.Add(reader[3]);
        list.Add(reader[4]);
        list.Add(reader[5]);
        list.Add(reader[6]);
        list.Add(reader[7]);
        list.Add(reader[8]);
        list.Add(reader[9]);
        list.Add(reader[10]);
        list.Add(reader[11]);
        list.Add(reader[12]);
        return list;
    }
}
