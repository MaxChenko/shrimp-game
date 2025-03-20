using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class ShrimpSelect : MonoBehaviour, IPointerClickHandler
{
    public Material HighlightMaterial;
    private Material originalMaterial;
    private bool selected = false;
    
    private SpriteRenderer spriteRenderer;
    private ShrimpAttribute shrimpAttribute;
    private Light2D light2D;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        
        shrimpAttribute = GetComponent<ShrimpAttribute>();
        light2D = GetComponent<Light2D>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        GameManager.SelectShrimp(shrimpAttribute.shrimpData);
        //spriteRenderer.material = selected ? HighlightMaterial : originalMaterial;
        light2D.enabled = selected;
    }

    public void Unselect()
    {
        selected = false;
        light2D.enabled = false;
    }
}
