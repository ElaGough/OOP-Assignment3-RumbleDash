using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour {
	public static int time = 60;
	public Text countdownText;

	public Button upbutton;
	public Button downbutton;

	
	// Update is called once per frame
	void Update () {
		countdownText.text = (""+time);
	}

	public void UpButton()
	{
		time = time + 5;
	}

	public void DownButton()
	{
		if (time > 0) {
			time = time - 5;
		}
	}
}
