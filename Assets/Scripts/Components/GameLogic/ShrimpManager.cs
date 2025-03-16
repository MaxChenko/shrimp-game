using System.Collections.Generic;
using Data;
using UnityEngine;

public class ShrimpManager : MonoBehaviour
{
    private List<Shrimp> shrimps;
    private GameObject shrimpPrefab;


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
        var sg =  Instantiate(shrimpPrefab);
        this.shrimps.Add(shrimp);
    }

    public void SetShrimpPrefab(GameObject shrimp)
    {
        this.shrimpPrefab = shrimp;
    }
}
