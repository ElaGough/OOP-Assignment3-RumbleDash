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

    public Transform P1flagCheckPoint;
    public Transform P2flagCheckPoint;
    public float flagCheckRadius;
    public LayerMask whatIsFlagLine;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		player1 = GameObject.Find("Canvas").GetComponent<GameManager>().player1;
		player2 = GameObject.Find("Canvas").GetComponent<GameManager>().player2;
		P1 = GameObject.FindGameObjectWithTag("Player1");
		P2 = GameObject.FindGameObjectWithTag("Player2");

        P1Flag = Physics2D.OverlapCircle(P1flagCheckPoint.position, flagCheckRadius, whatIsFlagLine);
        P2Flag = Physics2D.OverlapCircle(P2flagCheckPoint.position, flagCheckRadius, whatIsFlagLine);
        
        if ((P1Flag == true)  && (P2Flag == true))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			P1.SetActive(false);
			P2.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().draw.SetActive(true);
        }
        else if ((P1Flag == true) && (P2Flag == false))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p2active = false;
			P2.SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p1Wins.SetActive(true);
        }
        else if ((P1Flag == false) && (P2Flag == true))
        {
			GameObject.Find("Canvas").GetComponent<GameManager>().StopCoroutine ("LoseTime");
			//timer.SetActive (false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p1active = false;
			GameObject.FindGameObjectWithTag("Player1").SetActive(false);
			GameObject.Find("Canvas").GetComponent<GameManager>().p2Wins.SetActive(true);
        }
        
    }
}
