using System.Collections.Generic;
using Data;
using UnityEngine;


public class TankManager : MonoBehaviour
{
    private List<Tank> tanks = new List<Tank>();
    public GameObject tankPrefab;

    private void Awake()
    {
        tanks = new List<Tank>();
    }


    public void SpawnTanks(List<Tank> tanks)
    {
        foreach (var tank in tanks)
        {
            var sg =  Instantiate(tankPrefab);
            this.tanks.Add(tank);
        }
    }

    public void SpawnTank(Tank tank)
    {
        var sg =  Instantiate(tankPrefab).GetComponent<TankAttribute>().tankData = tank;
        tanks.Add(tank);
    }
}