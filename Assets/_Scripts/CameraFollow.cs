using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    /*public GameObject buddy;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - buddy.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = buddy.transform.position + offset;
	}*/

    public Transform Player1, Player2;
    public float minSizeY;
    public float maxSizeY;

    void SetCameraPos()
    {
        Vector3 middle = (player1.position + player2.position) * 0.5f;

        GetComponent<Camera>().transform.position = new Vector3(
            middle.x,
            middle.y,
            GetComponent<Camera>().transform.position.z
        );
    }

    void SetCameraSize()
    {
        //x size is based on actual screen ratio
        float minSizeX = minSizeY * Screen.width / Screen.height;
        float maxSizeX = maxSizeY * Screen.width / Screen.height;

        float width = Mathf.Abs(player1.position.x - player2.position.x) * 0.55f;
        float height = Mathf.Abs(player1.position.y - player2.position.y) * 0.55f;

        //computing the size
        float camSizeX = Mathf.Max(width, minSizeX);
        GetComponent<Camera>().orthographicSize = Mathf.Max(height,
            camSizeX * Screen.height / Screen.width, minSizeY);

        camSizeX = Mathf.Max(width, minSizeX);
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(Mathf.Max(height, 
            camSizeX * Screen.height / Screen.width, minSizeY), minSizeY, maxSizeY);
    }
	void Start() {
		FindObjectOfType<GameManager> ().Start();

		//player1
		if (buddy1.activeSelf)
		{
			FindObjectOfType<GameManager> ().Start ();
			Player1  = Transform.Find("Buddy1");
			buddy1.SetActive (true);
		}
		if (stela1.activeSelf)
		{
			FindObjectOfType<GameManager> ().Start ();
			Player1  = Transform.Find("Stela1");
			stela1.SetActive (true);
		}
		/*if (other1.activeSelf)
		{
			Player1  = GameObject.Find("Other1");
			other1.SetActive (true);
		}
		if (otherr1.activeSelf)
		{
			Player1  = GameObject.Find("Otherr1");
			otherr1.SetActive (true);
		}*/

		//player2
		if (buddy2.activeSelf)
		{
			Player2 = Transform.Find("Buddy2");
			buddy2.SetActive (true);
		}
		if (stela2.activeSelf)
		{
			FindObjectOfType<GameManager> ().Start ();
			Player2 = Transform.Find("Stela2");
			stela2.SetActive (true);
		}
		/*if (other2.activeSelf)
		{
			Player2  = GameObject.Find("Other2");
			other2.SetActive (true);
		}
		if (otherr2.activeSelf)
		{
			Player2  = GameObject.Find("Otherr2");
			otherr2.SetActive (true);
		}*/
	}

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }
}
