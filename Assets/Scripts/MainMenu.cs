using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas levelChoseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        OpenLevelChooseMenu(false);
    }

    public void OpenLevelChooseMenu(bool isOpenedNow)
    {
        levelChoseCanvas.enabled = isOpenedNow;
    }
}
