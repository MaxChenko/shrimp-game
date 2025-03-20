using System.Collections.Generic;
using UnityEngine;

public class LoadAllTankEntries : MonoBehaviour
{
    public GameObject TankEntryPrefab;
    public RectTransform Content;
    private Tank selectedTank;

    private List<TankEntry> tankEntries = new List<TankEntry>();
    
    public void OnTankSpawn(Tank tank)
    {
        var tankEntryPosition = -50f;
        
        var tankEntry = Instantiate(TankEntryPrefab).GetComponent<TankEntry>();
        tankEntry.transform.SetParent(Content.transform, false); 

        var rectTransform = tankEntry.GetComponent<RectTransform>();
        
        int entryCount = Content.childCount;
        
        rectTransform.anchoredPosition = new Vector2(0, -entryCount * 100f);
        
        tankEntry.Tank = tank;
        tankEntry.TankSelectEvent.AddListener((Tank tank) =>
        {
            selectedTank = tank;
        });
        
        Content.sizeDelta = new Vector2(Content.sizeDelta.x, entryCount * 100f);

    }


    public void SubmitTank()
    {
        GameManager.MoveShrimpToTank(selectedTank);
        ViewManager.viewManager.CancelTankDialogview();
    }
}
