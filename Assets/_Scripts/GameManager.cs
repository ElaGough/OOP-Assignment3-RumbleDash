using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;

	public GameObject timer;
	//bool time;

    public int P1Life;
    public int P2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject draw;

    public GameObject[] p1Hearts;
    public GameObject[] p2Hearts;

    public AudioSource hitSound;

    public string mainMenu;
	public string characterSelect;

	//stuff for timer
	public int timeRemaining = 10;
	public Text countdownText;

    // Use this for initialization
    void Start () {
		StartCoroutine("LoseTime");
	}
	
	// Update is called once per frame
	void Update () {
		//time = true;

        if ((P1Life <= 0) && (P2Life <= 0))
        {
			StopCoroutine ("LoseTime");
			timer.SetActive (false);
            player1.SetActive(false);
            player2.SetActive(false);
            draw.SetActive(true);
        }
        else if ((P1Life <= 0) && (P2Life > 0))
        {
			StopCoroutine ("LoseTime");
			timer.SetActive (false);
            player1.SetActive(false);
            p2Wins.SetActive(true);
			if (P2Life <= 1 ) {
				P2Life++;
			}
        }
        else if ((P2Life <= 0) && (P1Life > 0))
        {
			StopCoroutine ("LoseTime");
			timer.SetActive (false);
            player2.SetActive(false);
            p1Wins.SetActive(true);
			if (P1Life <= 1 ) {
				P1Life++;
			}
        }

		//timer condidtions

		else if ((timeRemaining <= 0) && (timer == true)) {
			StopCoroutine ("LoseTime");
			countdownText.text = "Time's Up";

			if (P1Life == P2Life)
			{
				player1.SetActive(false);
				player2.SetActive(false);
				draw.SetActive(true);
				StopCoroutine ("LoseTime");
				timer.SetActive (false);
			}
			else if (P1Life < P2Life)
			{
				player1.SetActive(false);
				p2Wins.SetActive(true);
				StopCoroutine ("LoseTime");
				timer.SetActive (false);
			}
			else if (P1Life > P2Life)
			{
				player2.SetActive(false);
				p1Wins.SetActive(true);
				StopCoroutine ("LoseTime");
				timer.SetActive (false);
			}
		}

		countdownText.text = (""+timeRemaining);

        //Winning Screen for getting to the flag - replay, new game, menu
        

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
		if (Input.GetKeyDown(KeyCode.N))
		{
			SceneManager.LoadScene(characterSelect);
		}
        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }


	//player loosing hearts
    public void HurtP1()
    {
        P1Life -= 1;

        for (int i = 0; i < p1Hearts.Length; i++)
        {
            if (P1Life > i)
            {
                p1Hearts[i].SetActive(true);
            } else
            {
                p1Hearts[i].SetActive(false);
            }
        }

        hitSound.Play();
    }

    public void HurtP2()
    {
        P2Life -= 1;

        for (int i = 0; i < p2Hearts.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hearts[i].SetActive(true);
            }
            else
            {
                p2Hearts[i].SetActive(false);
            }
        }

        hitSound.Play();
    }

	//timer
	IEnumerator LoseTime()
	{
		while (true) {
			yield return new WaitForSeconds (1);
			timeRemaining--;
		}
	}
}
