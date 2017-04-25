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

    public Transform player1, player2;
    public float minSizeY;
    public float maxSizeY;

	public GameObject buddy1;
	public GameObject stela1;
	public GameObject other1;
	public GameObject otherr1;
	public GameObject buddy2;
	public GameObject stela2;
	public GameObject other2;
	public GameObject otherr2;

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

		//player1
		if (buddy1.activeSelf)
		{
			buddy1  = GameObject.Find("Buddy1");
			player1 = buddy1.transform;
		}
		if (stela1.activeSelf)
		{
			stela1  = GameObject.Find("Stela1");
			player1 = stela1.transform;
		}
		/*if (other1.activeSelf)
		{
			Player1  = GameObject.Find("Other1");
		}
		if (otherr1.activeSelf)
		{
			Player1  = GameObject.Find("Otherr1");
		}*/

		//player2
		if (buddy2.activeSelf)
		{
			buddy2 = GameObject.Find("Buddy2");
			player2 = buddy2.transform;
		}
		if (stela2.activeSelf)
		{
			stela2 = GameObject.Find("Stela2");
			player2 = stela2.transform;
		}
		/*if (other2.activeSelf)
		{
			Player2  = GameObject.Find("Other2");
		}
		if (otherr2.activeSelf)
		{
			Player2  = GameObject.Find("Otherr2");
		}*/
	}

    void Update()
    {
        SetCameraPos();
        SetCameraSize();
    }
}
