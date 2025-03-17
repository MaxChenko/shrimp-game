using System;

using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    
    private SQLiteManager sqliteManager;
    private ShrimpManager shrimpManager;
    private TankManager tankManager;
    private ViewManager viewManager;

    private void Awake()
    {
        gameManager = this;
        
        shrimpManager = (gameObject.transform.Find("ShrimpManager")).GetComponent<ShrimpManager>();
        tankManager = (gameObject.transform.Find("TankManager")).GetComponent<TankManager>();
        viewManager = (gameObject.transform.Find("ViewManager")).GetComponent<ViewManager>();
        sqliteManager = (gameObject.transform.Find("SQLiteManager")).GetComponent<SQLiteManager>();
    }

    private void Start()
    {       
        tankManager.SpawnTanks(sqliteManager.GetTanks());
        
        shrimpManager.SpawnShrimps(sqliteManager.GetShrimp());
    }

    public void CreateShrimp()
    {
        var shrimp = new Shrimp();
        shrimp.TankID = tankManager.SelectedTank.ID;
        shrimp.Name = Random.Range(1,100).ToString();
        shrimpManager.SpawnShrimp(shrimp);
        sqliteManager.InsertShrimp(shrimp);
    }
    
    public void CreateTank(Transform slot)
    {
        var tank = new Tank();
        tank.Slot = slot.name;
        tankManager.SpawnTank(tank,slot);
        sqliteManager.InsertTank(tank);
    }

    public void SpawnTank(Transform slot, Tank tank)
    {
        tankManager.SpawnTank(tank,slot);
        sqliteManager.InsertTank(tank);
    }

    public void SelectShrimp(Shrimp shrimp)
    {
        shrimpManager.SelectShrimp(shrimp);
    }

    public void SelectTank(Vector3 position, Tank tank)
    {
        tankManager.SelectedTank = tank;
        viewManager.SetSingleTankView(position);
    }

    public void DeselectTank()
    {
        viewManager.SetAllTanksView();
    }
}
