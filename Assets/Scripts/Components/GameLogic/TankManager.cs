using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class TankManager : MonoBehaviour
{
    private List<TankSlot> tankSlots = new List<TankSlot>();
    public static TankManager tankManager;
    
    private List<TankAttribute> tanks = new List<TankAttribute>();
    public GameObject tankPrefab;
    
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
        tanks.Add(tankG);
    }

    public Vector3 GetTankPosition()
    {
        foreach (var tankSlot in tankSlots.Where(tankSlot => tankSlot.transform.parent.name.Equals(SelectedTank.Slot)))
        {
            return tankSlot.transform.position;
        }
        return Vector3.zero;
    }
    
    public Vector3 GetTankPosition(int TankID)
    {
        foreach (var tank in tanks)
        {
            //Debug.Log(tank.tankData.ID + " == " + TankID);
            if (tank.tankData.ID == TankID)
            {
                return tank.transform.position;
            }
        }

        return Vector3.zero;
    }
}