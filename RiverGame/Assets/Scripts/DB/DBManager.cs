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
        
        //Debug.Log(System.IO.File.Exists(connection + "/game_states"));
        if (!System.IO.File.Exists(connection + "/game_states"))
        {
            //DropTable();
            using (dbcon = new SqliteConnection(connection))
            {
                dbcon.Open();
                using(IDbCommand dbcmd = dbcon.CreateCommand())
                {
                    string q_createTable = 
                        "CREATE TABLE IF NOT EXISTS game_states "
                        + "("+ NAME +" VARCHAR, " + POINTS + " INTEGER, " + BOAT1 + " INTEGER, " + BOAT1LVL + " INTEGER"
                        + ", " + BOAT2 + " INTEGER, " + BOAT2LVL + " INTEGER, " + BOAT3 + " INTEGER, " + BOAT3LVL + " INTEGER, " + BOAT4
                        + " INTEGER, " + BOAT4LVL + " INTEGER, " + BOAT5 + " INTEGER, " + BOAT5LVL + " INTEGER ,id INTEGER PRIMARY KEY AUTOINCREMENT);";
                        dbcmd.CommandText = q_createTable;
                    IDataReader reader = dbcmd.ExecuteReader();
                    reader.Close();
                }
                dbcon.Close();
            }
            //Populate();
            }
    }

    public static void Populate() {
        InsertDB(new ArrayList{
			"New Game1", 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1
			});
        InsertDB(new ArrayList{
			"New Game2", 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1
			});
        InsertDB(new ArrayList{
			"New Game3", 0, 1, 1, -1, -1, -1, -1, -1, -1, -1, -1
			});
    }

    public static void UpdateDB(ArrayList data) 
    {
        
        if (GAME_STATE >= 1 && GAME_STATE <= 3)
        {
            connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
            using (dbcon = new SqliteConnection(connection))
            {
                dbcon.Open();
                using(IDbCommand cmnd = dbcon.CreateCommand())
                {    
                    cmnd.CommandText = "UPDATE game_states SET "
                    + "\"" + NAME + "\"= \"" + data[0] 
                    + "\", \""+ POINTS + "\"= \"" + data[1]
                    + "\", \""+ BOAT1 + "\"= \"" + data[2]
                    + "\", \"" + BOAT1LVL + "\"= \"" + data[3]
                    + "\", \""+ BOAT2 + "\"= \"" + data[4]
                    + "\", \"" + BOAT2LVL + "\"= \"" + data[5]
                    + "\", \""+ BOAT3 + "\"= \"" + data[6]
                    + "\", \"" + BOAT3LVL + "\"= \"" + data[7]
                    + "\", \""+ BOAT4 + "\"= \"" + data[8]
                    + "\", \"" + BOAT4LVL + "\"= \"" + data[9]
                    + "\", \""+ BOAT5 + "\"= \"" + data[10]
                    + "\", \"" + BOAT5LVL+ "\"= \"" + data[11]
                    +"\" WHERE rowid = \"" + GAME_STATE + "\";";
                    cmnd.ExecuteScalar();
                    
                    dbcon.Close();
                }
            }
        }       
    }

    public static void InsertDB(ArrayList data) 
    {
            connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
            using (dbcon = new SqliteConnection(connection))
            {
                dbcon.Open();
                using(IDbCommand cmnd = dbcon.CreateCommand()) {
                    
                    cmnd.CommandText = "INSERT INTO game_states (\""
                    + NAME + "\", \""+ POINTS 
                    + "\", \""+ BOAT1 + "\", \"" + BOAT1LVL
                    + "\", \""+ BOAT2 + "\", \"" + BOAT2LVL
                    + "\", \""+ BOAT3 + "\", \"" + BOAT3LVL
                    + "\", \""+ BOAT4 + "\", \"" + BOAT4LVL
                    + "\", \""+ BOAT5 + "\", \"" + BOAT5LVL
                    + "\") VALUES (\"" + data[0] + "\", \"" + data[1] + "\", \"" + data[2] 
                    + "\", \"" + data[3] + "\", \"-1\", \"-1\", \"-1\", \"-1\", \"-1\", \"-1\", \"-1\", \"-1\");";
                    cmnd.ExecuteScalar();
                }
                dbcon.Close();
            }
    }

    public static void Close() {
        dbcon.Close();
    }

    public static ArrayList GetData() {
        connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
        using (dbcon = new SqliteConnection(connection)) 
        {
            dbcon.Open();
            using(IDbCommand cmd = dbcon.CreateCommand())
            {
                string sQlQuery = "SELECT * from game_states WHERE rowid = \"" + GAME_STATE +"\";";
                cmd.CommandText = sQlQuery;

                using(IDataReader reader = cmd.ExecuteReader())
                {
                    ArrayList list = new ArrayList();
                    if (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                        list.Add(reader.GetInt32(1));
                        list.Add(reader.GetInt32(2));
                        list.Add(reader.GetInt32(3));
                        list.Add(reader.GetInt32(4));
                        list.Add(reader.GetInt32(5));
                        list.Add(reader.GetInt32(6));
                        list.Add(reader.GetInt32(7));
                        list.Add(reader.GetInt32(8));
                        list.Add(reader.GetInt32(9));
                        list.Add(reader.GetInt32(10));
                        list.Add(reader.GetInt32(11));
                    }
                    dbcon.Close();
                    reader.Close();
                    return list;
                }
            }
        }  
    }

    private static void DropTable()
    {
        using (dbcon = new SqliteConnection(connection)) 
        {
            dbcon.Open();
            using(IDbCommand cmd = dbcon.CreateCommand())
            {
                string sqlQuery = "DROP TABLE IF EXISTS game_states"; 
                cmd.CommandText = sqlQuery;
                cmd.ExecuteScalar();
            }
            dbcon.Close();
        }
    }

    public static void DropRow()
    {
        connection = "URI=file:" 
                    + Application.persistentDataPath 
                    + "/GameData";
        //Whatever current game_state is, drop that row
        using (dbcon = new SqliteConnection(connection)) 
        {
            dbcon.Open();
            using(IDbCommand cmd = dbcon.CreateCommand())
            {
                
                string sqlQuery = "DELETE from game_states WHERE rowid = \"" + GAME_STATE + "\""
                 + "AND EXISTS(SELECT 1 FROM game_states WHERE rowid = \"" + GAME_STATE + "\" LIMIT 1);"; 
                cmd.CommandText = sqlQuery;
                cmd.ExecuteScalar();
            }
            dbcon.Close();
        }
    }
}
