using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PopupWindow : MonoBehaviour
{
    public GameObject popupPanel;
    // Start is called before the first frame update
    void Start()
    {
        popupPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenPopUp()
    {
        popupPanel.SetActive(true);
    }
}
