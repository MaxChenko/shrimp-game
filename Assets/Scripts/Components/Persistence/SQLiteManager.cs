using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using Data;
using Unity.VisualScripting.Dependencies.Sqlite;

public class SQLiteManager : MonoBehaviour
{
    private string dbPath;
    private SQLiteConnection db;

    void Awake()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "game_database.db");
        
        db = new SQLiteConnection(dbPath);
        db.CreateTable<Shrimp>();
        db.CreateTable<Tank>();
    }

    public void InsertTank(Tank data)
    {
        db.Insert(data);
    }
    
    public void InsertShrimp(Shrimp data)
    {
        db.Insert(data);
    }

    public List<Shrimp> GetShrimp()
    {
        return db.Table<Shrimp>().ToList();
    }
    
    public List<Tank> GetTanks()
    {
        return db.Table<Tank>().ToList();
    }
}
