using UnityEngine;
using System.IO;
using SQLite;

public class SQLiteManager : MonoBehaviour
{
    private string dbPath;
    private SQLiteConnection db;

    void Start()
    {
        // 🔥 Set database path (persistent storage for mobile)
        dbPath = Path.Combine(Application.persistentDataPath, "game_database.db");
        Debug.Log("📂 Database Path: " + dbPath);

        // 🚀 Open or create the database
        db = new SQLiteConnection(dbPath);
        db.CreateTable<PlayerData>(); // Creates the table if it doesn’t exist

        // 🌟 Insert sample data and retrieve it
        InsertPlayer("ShrimpKing", 9001);
        GetPlayers();
    }

    void InsertPlayer(string name, int score)
    {
        var player = new PlayerData
        {
            Name = name,
            Score = score,
            LastLogin = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        db.Insert(player);
        Debug.Log($"✅ Inserted: {name} - {score}");
    }

    void GetPlayers()
    {
        var players = db.Table<PlayerData>().ToList();
        foreach (var player in players)
        {
            Debug.Log($"👤 Player: {player.Name}, Score: {player.Score}, Last Login: {player.LastLogin}");
        }
    }
}

// 📌 Define a class that represents the table
public class PlayerData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public int Score { get; set; }
    
    public string LastLogin { get; set; }
}
