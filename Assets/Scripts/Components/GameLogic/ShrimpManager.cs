
using System.Collections.Generic;

using UnityEngine;

public class ShrimpManager : MonoBehaviour
{
    public static ShrimpManager shrimpManager;
    
    private List<Shrimp> shrimps = new List<Shrimp>();
    public GameObject shrimpPrefab;

    private Shrimp selectedShrimp;
    
    private void Awake()
    {
        shrimpManager = this;
        
        shrimps = new List<Shrimp>();
    }


    public void SpawnShrimps(List<Shrimp> shrimps)
    {
        foreach (var shrimp in shrimps)
        {
            var sg =  Instantiate(shrimpPrefab);
            this.shrimps.Add(shrimp);
        }
    }

    public void SpawnShrimp(Shrimp shrimp)
    {
        var sg =  Instantiate(shrimpPrefab).GetComponent<ShrimpAttribute>().shrimpData = shrimp;
        shrimps.Add(shrimp);
    }
    
    public void SelectShrimp(Shrimp shrimp)
    {
        selectedShrimp = shrimp;
        Debug.Log("Selected shrimp: " + shrimp.Name);
    }
    
    public Shrimp GetSelectedShrimp()
    {
        return selectedShrimp;
    }
}
