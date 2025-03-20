using System;

using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    private static GameManager gameManager;
    
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
    
    public static void CreateTank(Transform slot)
    {
        var tank = new Tank();
        tank.Slot = slot.name;
        gameManager.tankManager.SpawnTank(tank,slot);
        gameManager.sqliteManager.InsertTank(tank);
    }

    public static void SpawnTank(Transform slot, Tank tank)
    {
        gameManager.tankManager.SpawnTank(tank,slot);
        gameManager.sqliteManager.InsertTank(tank);
    }

    public static void SelectShrimp(Shrimp shrimp)
    {
        gameManager.shrimpManager.SelectShrimp(shrimp);
    }

    public static void SelectTank(Vector3 position, Tank tank)
    {
        gameManager.tankManager.SelectedTank = tank;
        gameManager.viewManager.SetSingleTankView(position);
    }

    public void DeselectTank()
    {
        viewManager.SetAllTanksView();
    }

    public static void MoveShrimpToTank(Tank tank)
    {
        ShrimpManager.GetSelectedShrimp().ForEach(shrimp =>
        {
            shrimp.TankID = tank.ID;
            shrimp.GameObject.GetComponent<ShrimpSelect>().Unselect();
            shrimp.GameObject.transform.position = tank.GameObject.transform.position;
            gameManager.sqliteManager.UpdateShrimp(shrimp);
        });
        ShrimpManager.ClearSelected();
    }
}
