using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraFollow : MonoBehaviour {

    public GameObject gm;
    private Vector3 offset;
    Text text;
        // Use this for initialization
	void Start () {
        offset = transform.position - gm.transform.position;
        text = GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () {
        transform.position = gm.transform.position + offset;
        /*text.text = "Current Score: " + GameManager.currScore +
                    "HighScore: " + GameManager.highScore +
                    "Deaths: " + GameManager.deathScore +
                     "Current Level" + GameManager.CurrLevel;*/

    }
}
