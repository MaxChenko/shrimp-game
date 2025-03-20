using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;


public class TankManager : MonoBehaviour
{
    private List<TankSlot> tankSlots = new List<TankSlot>();
    private static TankManager tankManager;
    
    private List<Tank> tanks = new List<Tank>();
    public GameObject tankPrefab;

    public UnityEvent <Tank> TankCreateEvent;
    
    public Tank SelectedTank { get; set; } 

    private void Awake()
    {
        tankManager = this;
        
        var tankSlotsParent = transform.Find("TankSlots");
        tankSlots = tankSlotsParent
            .GetComponentsInChildren<TankSlot>()
            .Where(ts => ts.transform.parent != tankSlotsParent && ts.transform.parent.parent == tankSlotsParent)
            .ToList();
    }

    private void Start()
    {

    }

    public void SpawnTanks(List<Tank> tanks)
    {
        foreach (var tank in tanks)
        {
            foreach (var tankSlot in tankSlots)
            {
                if(tankSlot.transform.parent.name.Equals(tank.Slot))
                {
                    SpawnTank(tank,tankSlot.transform.parent);
                    tankSlot.gameObject.SetActive(false);
                }
            }
        }
    }

    public void SpawnTank(Tank tank, Transform parent)
    {
        var tankG = Instantiate(tankPrefab).GetComponent<TankAttribute>();
        tankG.tankData = tank;
        var transform1 = tankG.transform;
        transform1.parent = parent;
        transform1.localPosition = Vector3.zero;
        tank.GameObject = tankG.gameObject;
        tanks.Add(tank);
        TankCreateEvent.Invoke(tank);
    }

    public static Tank GetTank(int ID)
    {
        return tankManager.tanks.Find(tank => tank.ID == ID);
    }

    public static List<Tank> GetAllTanks()
    {
        Debug.Log("WHAT IS GOING ON HERE? " + tankManager.tanks.Count);
        return tankManager.tanks;
    }
}