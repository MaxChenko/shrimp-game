using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShrimpSelect : MonoBehaviour, IPointerClickHandler
{
    public Material HighlightMaterial;
    private Material originalMaterial;
    private bool selected = false;
    private SpriteRenderer spriteRenderer;
    private ShrimpAttribute shrimpAttribute;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        
        shrimpAttribute = GetComponent<ShrimpAttribute>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        GameManager.gameManager.SelectShrimp(shrimpAttribute.shrimpData);
        spriteRenderer.material = selected ? HighlightMaterial : originalMaterial;
    }
    
}
