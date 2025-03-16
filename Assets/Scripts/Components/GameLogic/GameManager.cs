using System;
using Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SQLiteManager sqliteManager;
    
    private ShrimpManager shrimpManager;
    private TankManager tankManager;

    private void Awake()
    {
        shrimpManager = (new GameObject("ShrimpManager")).AddComponent<ShrimpManager>();
        shrimpManager.transform.SetParent(transform);
        shrimpManager.SetShrimpPrefab(GameObject.Find("ShrimpPrefab"));
        
        tankManager = (new GameObject("TankManager")).AddComponent<TankManager>();
        tankManager.transform.SetParent(transform);
        
        sqliteManager = (new GameObject("SQLiteManager")).AddComponent<SQLiteManager>();
        sqliteManager.transform.SetParent(transform);
    }

    private void Start()
    {        
        shrimpManager.SpawnShrimps(sqliteManager.GetShrimp());
    }

    private void CreateShrimp()
    {
        var shrimp = new Shrimp();
        shrimpManager.SpawnShrimp(shrimp);
        sqliteManager.InsertShrimp(shrimp);
    }
}
