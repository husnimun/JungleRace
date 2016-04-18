using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject[] charactersPrefab;
    public GameObject playerOneCam;
    public GameObject playerTwoCam;

    GameObject playerOneObj;
    GameObject playerTwoObj;

	private GestureListener simplegl;
	private int tempjump;


    Player playerOne;
    Player playerTwo;

	void Start () {

		//Instantiate player object
		simplegl = GameObject.Find("Kinect").GetComponent<GestureListener>();

        // Instantiate player object
        playerOneObj = Instantiate(charactersPrefab[Settings.Instance.CharacterCode(Settings.Instance.playerOne)]);
        playerTwoObj = Instantiate(charactersPrefab[Settings.Instance.CharacterCode(Settings.Instance.playerTwo)]);

        playerOneObj.transform.Translate(-3, 0, 0);
        playerTwoObj.transform.Translate(3, 0, 0);

        playerOne = playerOneObj.GetComponent<Player>();
        playerTwo = playerTwoObj.GetComponent<Player>();

        // Set camera
        playerOneCam.GetComponent<CameraController>().SetPlayer(playerOneObj);
        playerTwoCam.GetComponent<CameraController>().SetPlayer(playerTwoObj);
    }
	

	void Update () {
		if(simplegl.IsJump(0)){
			playerOne.JumpForward ();
		}
		if(simplegl.IsJump(1)){
			playerTwo.JumpForward ();
		}
		if(simplegl.IsSwipeRight(0)){
			playerOne.JumpRight ();
		}
		if(simplegl.IsSwipeRight(1)){
			playerTwo.JumpRight ();
		}
		if(simplegl.IsSwipeLeft(0)){
			playerOne.JumpLeft ();
		}
		if(simplegl.IsSwipeLeft(1)){
			playerTwo.JumpLeft ();
		}
	}
}
