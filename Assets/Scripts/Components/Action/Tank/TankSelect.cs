using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TankSelect : MonoBehaviour, IPointerClickHandler
{
    private TankAttribute tankAttribute;

    private void Awake()
    {
        tankAttribute = GetComponent<TankAttribute>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.gameManager.SelectTank(transform.position,tankAttribute.tankData);
    }
}