using UnityEngine;

public class EnableOnShrimpSelected : MonoBehaviour
{
    public void DetermineSelected()
    {
        gameObject.SetActive(ShrimpManager.GetSelectedShrimp().Count > 0);
    }
}
