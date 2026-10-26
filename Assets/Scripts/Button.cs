using System.Collections;
using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor.Build.Content;
using UnityEditor;
#endif
using UnityEngine;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (gameObject.name)
        {
            /*
            case "StartButton": GM.is_StartButton = true; break;
            case "QuitButton": GM.is_QuitButton = true; break;
            case "ID_Button": GM.is_ID_Button = !GM.is_ID_Button; break;
            */
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClicked(string name) {
        switch (name)
        {
            case "StartButton": GM.is_StartButton = true; break;
            case "QuitButton": GM.APP_QUIT_NOW = true; break;
            case "ID_Button": {
                    GM.is_ID_Button = !GM.is_ID_Button;
                    if (!GM.is_ID_Button)
                        transform.Find("ID").gameObject.SetActive(false);
                    else
                        transform.Find("ID").gameObject.SetActive(true);
                } break;
        }
    }
}
