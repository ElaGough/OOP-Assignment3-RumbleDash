using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	void Awake () {
		DontDestroyOnLoad (this.gameObject);
	}


    public GameObject player1;
    public GameObject player2;
	bool p1active = true;
	bool p2active = true;

	public GameObject buddy1;
	public GameObject stela1;
	//public GameObject other1;
	//public GameObject otherr1;
	public GameObject buddy2;
	public GameObject stela2;
	//public GameObject other2;
	//public GameObject otherr2;
	public bool bbuddy1;
	public bool bstela1;
	//public bool bother1;
	//public bool botherr1;
	public bool bbuddy2;
	public bool bstela2;
	//public bool bother2;
	//public bool botherr2;

	public GameObject timer;
	public GameObject player1text;
	public GameObject player2text;
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

	//for pause screen
	public bool isPaused;
	public GameObject pauseScreen;

    // Use this for initialization
    void OnLevelWasLoaded () {

		//setting up saveVar
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		//initiliasing character to false
		if (sceneName == "MenuScreen" || sceneName == "BackStory" || sceneName == "ControlsScreen" || sceneName == "CharacterSelect" || sceneName == "LevelSelect") {
			buddy1.SetActive (false);
			buddy2.SetActive (false);
			stela1.SetActive (false);
			stela2.SetActive (false);
			//other1.SetActive (false);
			//other2.SetActive (false);
			//otherr1.SetActive (false);
			//otherr2.SetActive (false);
		}

		//activating canvas for game
		if (sceneName == "Default" || sceneName == "SnowLevel" || sceneName == "SpaceLevel") {
			StartCoroutine ("LoseTime");
			player1text.SetActive (true);
			player2text.SetActive (true);
			timer.SetActive (true);
		}


		//player1
		if (sceneName == "Default" || sceneName == "SnowLevel" || sceneName == "SpaceLevel") {
			if (bbuddy1 == true) {
				player1 = GameObject.Find ("Buddy1");
				buddy1.SetActive (true);
			} else {
				//buddy1.SetActive (false);
			}
			if (bstela1 == true) {
				player1 = GameObject.Find ("Stela1");
				stela1.SetActive (true);
			} else {
				//stela1.SetActive (false);
			}
			/*if (bother1 == true)
			{
				player1  = GameObject.Find("Other1");
				other1.SetActive (true);
			}
			if (botherr1 == true)
			{
				player1  = GameObject.Find("Otherr1");
				otherr1.SetActive (true);
			}*/

			//player2
			if (bbuddy2 == true) {
				player2 = GameObject.Find ("Buddy2");
				buddy2.SetActive (true);
			} else {
				//buddy2.SetActive (false);
			}
			if (bstela2 == true) {
				player2 = GameObject.Find ("Stela2");
				stela2.SetActive (true);
			} else {
				//stela2.SetActive (false);
			}
			/*if (bother2 == true)
			{
				player2  = GameObject.Find("Other2");
				other2.SetActive (true);
			}
			if (botherr2 == true)
			{
				player2  = GameObject.Find("Otherr2");
				otherr2.SetActive (true);
			}*/
		}




	}
	
	//Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "Default" || sceneName == "SnowLevel" || sceneName == "SpaceLevel") {
			//win screens
	        if ((P1Life <= 0) && (P2Life <= 0))
	        {
				StopCoroutine ("LoseTime");
				//timer.SetActive (false);
	            player1.SetActive(false);
	            player2.SetActive(false);
	            draw.SetActive(true);
	        }
	        else if ((P1Life <= 0) && (P2Life > 0))
	        {
				StopCoroutine ("LoseTime");
				//timer.SetActive (false);
	            player1.SetActive(false);
				p1active = false;
	            p2Wins.SetActive(true);
				if (P2Life <= 1 ) {
					P2Life++;
				}
	        }
	        else if ((P2Life <= 0) && (P1Life > 0))
	        {
				StopCoroutine ("LoseTime");
				//timer.SetActive (false);
	            player2.SetActive(false);
				p2active = false;
	            p1Wins.SetActive(true);
				if (P1Life <= 1 ) {
					P1Life++;
				}
	        }

			//timer condidtions
			countdownText.text = (""+timeRemaining);

			if ((timeRemaining <= 0) && (timer == true)) {
				StopCoroutine ("LoseTime");
				countdownText.text = "Time's Up";

				if (P1Life == P2Life)
				{
					player1.SetActive(false);
					player2.SetActive(false);
					draw.SetActive(true);
					//StopCoroutine ("LoseTime");
					//timer.SetActive (false);
				}
				else if (P1Life < P2Life)
				{
					player1.SetActive(false);
					p1active = false;
					p2Wins.SetActive(true);
					//StopCoroutine ("LoseTime");
					//timer.SetActive (false);
				}
				else if (P1Life > P2Life)
				{
					player2.SetActive(false);
					p2active = false;
					p1Wins.SetActive(true);
					//StopCoroutine ("LoseTime");
					//timer.SetActive (false);
				}
			}


			//Checking isPaused
			if (isPaused) {
				pauseScreen.SetActive (true);
				player1.SetActive (false);
				player2.SetActive (false);
			}
			if (!isPaused) {
				pauseScreen.SetActive (false);
				player1.SetActive (true);
				player2.SetActive (true);
			}

       		//Winning and Pause Screen for getting to the flag - replay, new game, menu
			if (Input.GetKeyDown (KeyCode.P)) {
				StopCoroutine ("LoseTime");
				SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
			}
			if (Input.GetKeyDown (KeyCode.N)) {
				SceneManager.LoadScene (characterSelect);
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				SceneManager.LoadScene (mainMenu);
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (isPaused) {
					isPaused = false;
				} else if (!isPaused) {
					isPaused = true;
				}
			}
		}
    }


	//player loosing hearts
    public void HurtP1()
    {
		if (p1active == true &&
		     p2active == true) {
			P1Life -= 1;

			for (int i = 0; i < p1Hearts.Length; i++) {
				if (P1Life > i) {
					p1Hearts [i].SetActive (true);
				} else {
					p1Hearts [i].SetActive (false);
				}
			}

			hitSound.Play ();
		}
    }

    public void HurtP2()
    {
			if (p1active == true &&
			   p2active == true) {
				P2Life -= 1;

				for (int i = 0; i < p2Hearts.Length; i++) {
					if (P2Life > i) {
						p2Hearts [i].SetActive (true);
					} else {
						p2Hearts [i].SetActive (false);
					}
				}

				hitSound.Play ();
			}
    }

	//timer
	IEnumerator LoseTime()
	{
		while (true) {
			if (isPaused) {
				yield return null;
			} else {
				yield return new WaitForSeconds (1);
				timeRemaining--;
			}
		}
	}
}
