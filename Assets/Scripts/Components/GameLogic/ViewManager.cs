using System;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    [Serializable]
    public struct View
    {
        public int size;
        public Vector3 location;
        public GameObject UI;
    }

    public static ViewManager viewManager;

    public View allTanks;
    public View singleTank;

    private Camera _camera;
    
    private void Awake()
    {
        viewManager = this;
        
        _camera = Camera.main;
    }

    private void Start()
    {
        SetAllTanksView();
    }

    public void SetAllTanksView()
    {
        _camera.orthographicSize = allTanks.size;
        _camera.transform.position = new Vector3(allTanks.location.x,allTanks.location.y,-10);
        allTanks.UI.SetActive(true);
        singleTank.UI.SetActive(false);
    }

    public void SetSingleTankView(Vector3 position)
    {
        _camera.orthographicSize = singleTank.size;
        _camera.transform.position = new Vector3(position.x,position.y,-10);
        singleTank.UI.SetActive(true);
        allTanks.UI.SetActive(false);
    }
}
