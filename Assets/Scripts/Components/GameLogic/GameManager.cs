using System;

using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    private SQLiteManager sqliteManager;
    private ShrimpManager shrimpManager;
    private TankManager tankManager;

    private void Awake()
    {
        gameManager = this;
        
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
        shrimp.Name = Random.Range(1,100).ToString();
        shrimpManager.SpawnShrimp(shrimp);
        sqliteManager.InsertShrimp(shrimp);
    }
}
