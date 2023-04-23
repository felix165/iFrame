using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject MainModeUI;
    public GameObject SelectingModeUI;
    public GameObject EditingModeUI;
    // Start is called before the first frame update
    void Start()
    {
        MainModeUI.SetActive(false);
        SelectingModeUI.SetActive(false);
        EditingModeUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlaceManager.mode)
        {
            case PlaceManager.Mode.MainMode:
                MainModeUI.SetActive(true);
                SelectingModeUI.SetActive(false) ;
                EditingModeUI.SetActive(false);
                break;
            case PlaceManager.Mode.SelectingMode:
                MainModeUI.SetActive(false);
                SelectingModeUI.SetActive(true);
                EditingModeUI.SetActive(false);
                break;
            case PlaceManager.Mode.EditingMode:
                MainModeUI.SetActive(false);
                SelectingModeUI.SetActive(false);
                EditingModeUI.SetActive(true);
                break;
        }
    }
}
