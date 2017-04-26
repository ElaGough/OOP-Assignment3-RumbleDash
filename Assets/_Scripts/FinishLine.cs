using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour {

    public GameObject player1;
    public GameObject player2;
	public GameObject timer;
	GameObject P1;
	GameObject P2;

    public bool P1Flag;
    public bool P2Flag;

    public GameObject p1Wins;
    public GameObject p2Wins;
    public GameObject draw;

	public Transform b1flagCheckPoint;
	public Transform b2flagCheckPoint;
	public Transform s1flagCheckPoint;
	public Transform s2flagCheckPoint;
	public Transform or1flagCheckPoint;
	public Transform or2flagCheckPoint;
	public Transform orr1flagCheckPoint;
	public Transform orr2flagCheckPoint;

    public Transform P1flagCheckPoint;
    public Transform P2flagCheckPoint;
    public float flagCheckRadius;
    public LayerMask whatIsFlagLine;

    // Use this for initialization
    void Start () {
		player1 = GameObject.Find("Canvas").GetComponent<GameManager>().player1;
		player2 = GameObject.Find("Canvas").GetComponent<GameManager>().player2;

		if (CharacterLevelSelect.buddy1bool == true) {
			P1flagCheckPoint = b1flagCheckPoint;
		}
		else if (CharacterLevelSelect.stela1bool == true) {
			P1flagCheckPoint = s1flagCheckPoint.transform;
		}
		else if (CharacterLevelSelect.other1bool == true) {
			P1flagCheckPoint = or1flagCheckPoint.transform;
		}
		else if (CharacterLevelSelect.otherr1bool == true) {
			P1flagCheckPoint = orr1flagCheckPoint.transform;
		}
		if (CharacterLevelSelect.buddy2bool == true) {
			P2flagCheckPoint = b2flagCheckPoint.transform;
		}
		else if (CharacterLevelSelect.stela2bool == true) {
			P2flagCheckPoint = s2flagCheckPoint.transform;
		}
		else if (CharacterLevelSelect.other2bool == true) {
			P2flagCheckPoint = or2flagCheckPoint.transform;
		}
		else if (CharacterLevelSelect.otherr2bool == true) {
			P2flagCheckPoint = orr2flagCheckPoint.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		

        P1Flag = Physics2D.OverlapCircle(P1flagCheckPoint.position, flagCheckRadius, whatIsFlagLine);
        P2Flag = Physics2D.OverlapCircle(P2flagCheckPoint.position, flagCheckRadius, whatIsFlagLine);
        
        if ((P1Flag == true)  && (P2Flag == true))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			GameObject.Find("Canvas").GetComponent<GameManager>().player1.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().player2.SetActive(false);
			player1.SetActive(false);
			player2.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().draw.SetActive(true);
        }
        else if ((P1Flag == true) && (P2Flag == false))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p2active = false;
			GameObject.Find("Canvas").GetComponent<GameManager>().player2.SetActive(false);
			player2.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p1Wins.SetActive(true);
        }
        else if ((P1Flag == false) && (P2Flag == true))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p1active = false;
			//GameObject.FindGameObjectWithTag("Player1").SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().player1.SetActive(false);
			player1.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p2Wins.SetActive(true);
        }
        
    }
}
