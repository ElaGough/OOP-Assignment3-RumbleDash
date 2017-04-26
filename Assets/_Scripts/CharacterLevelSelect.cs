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

	public static bool buddy1bool;
	public static bool stela1bool;
	public static bool other1bool;
	public static bool otherr1bool;
	public static bool buddy2bool;
	public static bool stela2bool;
	public static bool other2bool;
	public static bool otherr2bool;

	void Update()
	{
		if (buddy1bool == true) {
			b1Text.SetActive(true);
			s1Text.SetActive(false);
			or1Text.SetActive(false);
			orr1Text.SetActive(false);
		}

		if (stela1bool == true) {
			b1Text.SetActive(false);
			s1Text.SetActive(true);
			or1Text.SetActive(false);
			orr1Text.SetActive(false);
		}

		if (other1bool == true) {
			b1Text.SetActive(false);
			s1Text.SetActive(false);
			or1Text.SetActive(true);
			orr1Text.SetActive(false);
		}

		if (otherr1bool == true) {
			b1Text.SetActive(false);
			s1Text.SetActive(false);
			or1Text.SetActive(false);
			orr1Text.SetActive(true);
		}

		if (buddy2bool == true) {
			b2Text.SetActive(true);
			s2Text.SetActive(false);
			or2Text.SetActive(false);
			orr2Text.SetActive(false);
		}

		if (stela2bool == true) {
			b2Text.SetActive(false);
			s2Text.SetActive(true);
			or2Text.SetActive(false);
			orr2Text.SetActive(false);
		}

		if (other2bool == true) {
			b2Text.SetActive(false);
			s2Text.SetActive(false);
			or2Text.SetActive(true);
			orr2Text.SetActive(false);
		}

		if (otherr2bool == true) {
			b2Text.SetActive(false);
			s2Text.SetActive(false);
			or2Text.SetActive(false);
			orr2Text.SetActive(true);
		}
	}

	public void buddy1()
	{
		buddy1bool = true;
		stela1bool = false;
		other1bool = false;
		otherr1bool = false;
		p1active = true;
	}

	public void stela1()
	{
		buddy1bool = false;
		stela1bool = true;
		other1bool = false;
		otherr1bool = false;
		p1active = true;
	}

	public void or1()
	{
		buddy1bool = false;
		stela1bool = false;
		other1bool = true;
		otherr1bool = false;
		p1active = true;
	}

	public void orr1()
	{
		buddy1bool = false;
		stela1bool = false;
		other1bool = false;
		otherr1bool = true;
		p1active = true;
	}

	public void buddy2()
	{
		buddy2bool = true;
		stela2bool = false;
		other2bool = false;
		otherr2bool = false;
		p2active = true;
	}

	public void stela2()
	{
		buddy2bool = false;
		stela2bool = true;
		other2bool = false;
		otherr2bool = false;
		p2active = true;
	}

	public void or2()
	{
		buddy2bool = false;
		stela2bool = false;
		other2bool = true;
		otherr2bool = false;
		p2active = true;
	}

	public void orr2()
	{
		buddy2bool = false;
		stela2bool = false;
		other2bool = false;
		otherr2bool = true;
		p2active = true;
	}

}
