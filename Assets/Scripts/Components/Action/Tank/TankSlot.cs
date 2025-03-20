using UnityEngine;

using UnityEngine;
using UnityEngine.EventSystems;

public class TankSlot : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.CreateTank(transform.parent);
        gameObject.SetActive(false);
    }
    
    public void SpawnTank(Tank tank)
    {
        GameManager.SpawnTank(transform.parent,tank);
        gameObject.SetActive(false);
    }
}

