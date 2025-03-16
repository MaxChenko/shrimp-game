
using System.Collections.Generic;

using UnityEngine;

public class ShrimpManager : MonoBehaviour
{
    public static ShrimpManager shrimpManager;
    
    private List<Shrimp> shrimps = new List<Shrimp>();
    public GameObject shrimpPrefab;

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
}
