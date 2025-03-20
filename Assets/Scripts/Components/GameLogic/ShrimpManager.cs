
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class ShrimpManager : MonoBehaviour
{
    private static ShrimpManager shrimpManager;
    
    private List<Shrimp> shrimps = new List<Shrimp>();
    public GameObject shrimpPrefab;

    private List<Shrimp> selectedShrimp = new List<Shrimp>();

    public UnityEvent shrimpSelectedEvent;
    
    private void Awake()
    {
        shrimpManager = this;
        
        shrimps = new List<Shrimp>();
    }


    public void SpawnShrimps(List<Shrimp> shrimps)
    {
        foreach (var shrimp in shrimps)
        {
            SpawnShrimp(shrimp);
        }
    }

    public void SpawnShrimp(Shrimp shrimp)
    {
        var sg = Instantiate(shrimpPrefab).GetComponent<ShrimpAttribute>();
        sg.shrimpData = shrimp;
        sg.transform.position = TankManager.GetTank(shrimp.TankID).GameObject.transform.position;
        shrimp.GameObject = sg.gameObject;
        shrimps.Add(shrimp);
    }
    
    public void SelectShrimp(Shrimp shrimp)
    {
        Debug.Log("SElected SHRIMP " + shrimp.ID);
        if (selectedShrimp.Find((s) => shrimp.ID == s.ID) == null)
        {
            selectedShrimp.Add(shrimp);
        }
        else
        {
            selectedShrimp.RemoveAt(selectedShrimp.FindIndex((s) => shrimp.ID == s.ID));
        }
        shrimpSelectedEvent.Invoke();
    }
    
    public static List<Shrimp> GetSelectedShrimp()
    {
        return shrimpManager.selectedShrimp;
    }

    public static void ClearSelected()
    {
        shrimpManager.selectedShrimp.Clear();
    }
}
