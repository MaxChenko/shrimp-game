using System;
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
    private GameObject glowNOutline;
    private SpriteRenderer outlineRenderer;
    public Color outlineColor = Color.white;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
        
        shrimpAttribute = GetComponent<ShrimpAttribute>();
        light2D = GetComponent<Light2D>();
        glowNOutline = transform.Find("GlowNOutline").gameObject;
        outlineRenderer = glowNOutline.GetComponent<SpriteRenderer>();
        
        glowNOutline.SetActive(false);
        
        light2D.intensity = 1.5f;
        light2D.falloffIntensity = 1.2f;
        light2D.pointLightOuterRadius = 1.4f; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        selected = !selected;
        GameManager.gameManager.SelectShrimp(shrimpAttribute.shrimpData);
        //spriteRenderer.material = selected ? HighlightMaterial : originalMaterial; //Note: This is bullshit
        glowNOutline.SetActive(selected);
        light2D.enabled = selected;
    }

    void Update()
    {
        if (selected)
        {
            outlineRenderer.color = outlineColor;
        }
        else
        {
            outlineRenderer.color = originalMaterial.color;
        }
    }
    
}
