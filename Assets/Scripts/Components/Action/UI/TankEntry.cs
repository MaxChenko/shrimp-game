using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TankEntry : MonoBehaviour, IPointerClickHandler
{
    public TextMeshProUGUI id;
    public TextMeshProUGUI name;
    public GameObject highLight;
    public Tank Tank { get; set; }
    public UnityEvent<Tank> TankSelectEvent;
    
    private void Start()
    {
        id.text = Tank.ID.ToString();
        name.text = Tank.Name;
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        TankSelectEvent.Invoke(Tank);
    }
}
