using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

using Unity.VisualScripting.Dependencies.Sqlite;

public class SQLiteManager : MonoBehaviour
{
    private string dbPath;
    private SQLiteConnection db;

    [Header("DEBUG")] 
    public bool resetDB;

    void Awake()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "game_database.db");
        
        if (File.Exists(dbPath) && resetDB)
        {
            File.Delete(dbPath);
        }
        
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
        var tanks = db.Table<Tank>().ToList();
        
        return tanks;
    }
    
    public void UpdateShrimp(Shrimp shrimp)
    {
        db.Update(shrimp);
    }
}
