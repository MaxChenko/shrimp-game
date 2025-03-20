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
    public View tankDialog;


    private View activeView;
    private View previousView;
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
        previousView = activeView;
        _camera.orthographicSize = allTanks.size;
        _camera.transform.position = new Vector3(allTanks.location.x,allTanks.location.y,-10);
        DisableAll();
        allTanks.UI.SetActive(true);
        activeView = allTanks;
    }

    public void SetSingleTankView(Vector3 position)
    {
        previousView = activeView;
        _camera.orthographicSize = singleTank.size;
        _camera.transform.position = new Vector3(position.x,position.y,-10);
        DisableAll();
        singleTank.UI.SetActive(true);
        activeView = singleTank;
    }

    public void SetTankDialogView()
    {
        previousView = activeView;
        DisableAll();
        tankDialog.UI.SetActive(true);
        activeView = tankDialog;
    }

    public void CancelTankDialogview()
    {
        DisableAll();
        previousView.UI.SetActive(true);
        activeView = previousView;
    }

    private void DisableAll()
    {
        singleTank.UI.SetActive(false);
        allTanks.UI.SetActive(false);
        tankDialog.UI.SetActive(false);
    }
}
