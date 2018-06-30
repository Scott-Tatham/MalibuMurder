using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    public float blinkSpeed = 0.0f;
    public string text;

    private float timer = 0;
    private Text textOutput;

	// Use this for initialization
	void Start ()
    {
        textOutput = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (timer < blinkSpeed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            if (textOutput.text == text)
                textOutput.text = "";
            else
                textOutput.text = text;


        }
	}
}
