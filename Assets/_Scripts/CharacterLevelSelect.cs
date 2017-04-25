/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelSelect : MonoBehaviour {
	//GetComponent<GameManager> ();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//player1
		if (buddy1button.activeSelf)
		{
			GetComponent<GameManager>().player1  = GameObject.Find("Buddy1").GetComponent<GameManager>().Buddy1;
			GetComponent<GameManager>().buddy1.SetActive (true);
			GetComponent<GameManager>().stela1.SetActive (false);
			GetComponent<GameManager>().other1.SetActive (false);
			GetComponent<GameManager>().otherr1.SetActive (false);
		}
		if (stela1button.activeSelf)
		{
			GetComponent<GameManager>().player1  = GameObject.Find("Stela1").GetComponent<GameManager>().Stela1;
			GetComponent<GameManager>().buddy1.SetActive (false);
			GetComponent<GameManager>().stela1.SetActive (true);
			GetComponent<GameManager>().other1.SetActive (false);
			GetComponent<GameManager>().otherr1.SetActive (false);
		}
		/*if (other1button.activeSelf)
		{
			player1  = GameObject.Find("Other1");
			buddy1.SetActive (false);
			stela1.SetActive (false);
			other1.SetActive (true);
			otherr1.SetActive (false);
		}
		if (otherr1button.activeSelf)
		{
			player1  = GameObject.Find("Otherr1");
			buddy1.SetActive (false);
			stela1.SetActive (false);
			other1.SetActive (false);
			otherr1.SetActive (true);
		}*/
		/*
		//player2
		if (buddy2button.activeSelf)
		{
			player2 = GameObject.Find("Buddy2");
			buddy2.SetActive (true);
			stela2.SetActive (false);
			other2.SetActive (false);
			otherr2.SetActive (false);
		}
		if (stela2button.activeSelf)
		{
			player2 = GameObject.Find("Stela2");
			buddy2.SetActive (false);
			stela2.SetActive (true);
			other2.SetActive (false);
			otherr2.SetActive (false);
		}*/
		/*if (other2button.activeSelf)
		{
			player2  = GameObject.Find("Other2");
			buddy2.SetActive (false);
			stela2.SetActive (false);
			other2.SetActive (true);
			otherr2.SetActive (false);
		}
		if (otherr2button.activeSelf)
		{
			player2  = GameObject.Find("Otherr2");
			buddy2.SetActive (false);
			stela2.SetActive (false);
			other2.SetActive (false);
			otherr2.SetActive (true);
		}*/
	//}
//}
//*/