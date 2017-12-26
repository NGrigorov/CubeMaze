using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GUI : MonoBehaviour {


    public GUISkin guiskin;
	void OnGUI()
    {
        UnityEngine.GUI.skin = guiskin;
        UnityEngine.GUI.Label(new Rect(20, 10, 400, 45), "Go Home");
        if(PlayerPrefs.GetInt("Level Completed") > 0)
        {
            if (UnityEngine.GUI.Button(new Rect(20, 100, 100, 45), "Continue"))
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("Level Completed") + 1);
            }
        }
        if (UnityEngine.GUI.Button(new Rect(20,155,100,45),"PLAY"))
        {
            PlayerPrefs.SetInt("Level Completed", 0);
            SceneManager.LoadScene(1);
            
        }
        if (UnityEngine.GUI.Button(new Rect(20, 210, 100, 45), "QUIT"))
        {
            Application.Quit();
        }
    }
}
