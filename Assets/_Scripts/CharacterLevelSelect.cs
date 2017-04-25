using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterLevelSelect : MonoBehaviour {

	public bool p1active = false;
	public bool p2active = false;

	public GameObject b1Text;
	public GameObject b2Text;
	public GameObject s1Text;
	public GameObject s2Text;
	public GameObject or1Text;
	public GameObject or2Text;
	public GameObject orr1Text;
	public GameObject orr2Text;

	public Button buddy1button;
	public Button stela1button;
	public Button other1button;
	public Button otherr1button;
	public Button buddy2button;
	public Button stela2button;
	public Button other2button;
	public Button otherr2button;

	public bool buddy1bool = false;
	public bool stela1bool = false;
	public bool other1bool = false;
	public bool otherr1bool = false;
	public bool buddy2bool = false;
	public bool stela2bool = false;
	public bool other2bool = false;
	public bool otherr2bool = false;

	//private GameObject b1Text = GameObject.Find ("b1Text");

	void Update()
	{
		if (buddy1bool == true) {
			b1Text.SetActive(true);
			s1Text.SetActive(false);
			/*or1Text.SetActive(false);
			orr1Text.SetActive(false);*/
		}

		if (stela1bool == true) {
			b1Text.SetActive(false);
			s1Text.SetActive(true);
			/*or1Text.SetActive(false);
			orr1Text.SetActive(false);*/
		}

		if (buddy2bool == true) {
			b2Text.SetActive(true);
			s2Text.SetActive(false);
			/*or2Text.SetActive(false);
			orr2Text.SetActive(false);*/
		}

		if (stela2bool == true) {
			b2Text.SetActive(false);
			s2Text.SetActive(true);
			/*or2Text.SetActive(false);
			orr2Text.SetActive(false);*/
		}
	}

	public void buddy1()
	{
		buddy1bool = true;
		stela1bool = false;
		other1bool = false;
		otherr1bool = false;
		p1active = true;
		//player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		Debug.Log("You have clicked the buddy1!");
	}

	public void stela1()
	{
		buddy1bool = false;
		stela1bool = true;
		other1bool = false;
		otherr1bool = false;
		p1active = true;
		//player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		Debug.Log("You have clicked the stela1!");
	}

	public void buddy2()
	{
		buddy2bool = true;
		stela2bool = false;
		other2bool = false;
		otherr2bool = false;
		p2active = true;
		//player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		Debug.Log("You have clicked the buddy2!");
	}

	public void stela2()
	{
		buddy2bool = false;
		stela2bool = true;
		other2bool = false;
		otherr2bool = false;
		p2active = true;
		//player1 = GameObject.Find ("Canvas").GetComponent<GameManager> ().buddy1;
		Debug.Log("You have clicked the stela2!");
	}

}
