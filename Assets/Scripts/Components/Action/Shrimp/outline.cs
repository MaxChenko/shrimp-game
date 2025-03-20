using UnityEngine;
using UnityEngine.Rendering.Universal;

public class outline : MonoBehaviour
{
    public SpriteRenderer parentRenderer;
    private SpriteRenderer childRenderer;
        
    private void Awake()
    {
        parentRenderer = transform.parent.GetComponent<SpriteRenderer>();
        childRenderer = GetComponent<SpriteRenderer>();
    }
        
    private void Update()
    {
        childRenderer.sprite = parentRenderer.sprite;
    }
}
