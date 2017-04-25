using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLevelSelect : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public bool p1active = true;
	public bool p2active = true;

	public Button buddy1button;
	public Button stela1button;
	public Button other1button;
	public Button otherr1button;
	public Button buddy2button;
	public Button stela2button;
	public Button other2button;
	public Button otherr2button;


	void Start()
	{
		player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		player2 = GameObject.Find ("Canvas").GetComponent<GameManager> ().stela2;

		Button btnbuddy1button = buddy1button.GetComponent<Button>();
		btnbuddy1button.onClick.AddListener(buddy1buttonOnClick);
	}

	void buddy1buttonOnClick()
	{
		player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		Debug.Log("You have clicked the button!");
	}
	
	// Update is called once per frame
	void Update () {



		GameObject.Find("Canvas").GetComponent<GameManager>().player1 = player1;
		GameObject.Find("Canvas").GetComponent<GameManager>().player2 = player2;

	}
}
