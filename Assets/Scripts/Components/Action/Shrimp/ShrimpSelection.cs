using UnityEngine;

public class ShrimpSelection : MonoBehaviour
{
    public Material HighlightMaterial;
    
    
    private void Update()
    {

        if (Input.GetMouseButtonDown(0)) // Left-click
        {
            SelectShrimp();
        }
    }

    void SelectShrimp()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider != null)
        {
            ShrimpAttribute shrimpAttr = hit.collider.GetComponent<ShrimpAttribute>();

            if (shrimpAttr != null)
            {
                Shrimp selected = shrimpAttr.shrimpData; // Get Shrimp data
                ShrimpManager.shrimpManager.SelectShrimp(selected);
                HighlightShrimp(shrimpAttr.gameObject);
            }
        }
    }
    
    void HighlightShrimp(GameObject shrimp)
    {
        // Store the original material for later if you want to revert back
        var originalMaterial = shrimp.GetComponent<Renderer>().material;

        // Set the shrimp's material to the highlight material
        shrimp.GetComponent<Renderer>().material = HighlightMaterial;
    }
}
