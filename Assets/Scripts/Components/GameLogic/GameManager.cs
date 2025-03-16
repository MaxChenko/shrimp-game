using System;

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private SQLiteManager sqliteManager;
    private ShrimpManager shrimpManager;
    private TankManager tankManager;

    private void Awake()
    {
        shrimpManager = (gameObject.transform.Find("ShrimpManager")).GetComponent<ShrimpManager>();
        tankManager = (gameObject.transform.Find("TankManager")).GetComponent<TankManager>();
        sqliteManager = (gameObject.transform.Find("SQLiteManager")).GetComponent<SQLiteManager>();
    }

    private void Start()
    {        
        shrimpManager.SpawnShrimps(sqliteManager.GetShrimp());
        tankManager.SpawnTanks(sqliteManager.GetTanks());
    }

    public void CreateShrimp()
    {
        var shrimp = new Shrimp();
        shrimpManager.SpawnShrimp(shrimp);
        sqliteManager.InsertShrimp(shrimp);
    }
}
