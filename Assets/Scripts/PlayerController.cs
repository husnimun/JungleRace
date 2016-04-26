using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
    
    public GameObject[] charactersPrefab;
    public GameObject playerOneCam;
    public GameObject playerTwoCam;
    public Text timerText;

    public Text countDownP1;
    public Text countDownP2;


    GameObject playerOneObj;
    GameObject playerTwoObj;

	private GestureListener simplegl;
	private int tempjump;
    private float countDown = 3f;
    private float timer = 0;
    private float minutes = 0;
    private float seconds = 0;
    private bool gameStarted = false;
    bool isLoncatKecil = true;


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


        // Print count down text
        if (countDown >= 0.5)
        {
            countDownP1.text = countDown.ToString("0");
            countDownP2.text = countDown.ToString("0");
            countDown -= Time.deltaTime;

        }
        else
        {
            countDownP1.text = "";
            countDownP2.text = "";
            gameStarted = true;
        }

        if (gameStarted)
        {
            timer += Time.deltaTime;
            minutes = Mathf.Floor(timer / 60);
            seconds = timer % 60;
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            if (isLoncatKecil == true){
                StartCoroutine(defaultJump());
            }

            if (simplegl.IsJump(0)) {
                playerOne.JumpSkillForward();
            }
            if (simplegl.IsJump(1)) {
                playerTwo.JumpSkillForward();
            }
            if (simplegl.IsSwipeRight(0)) {
                playerOne.JumpRight();
            }
            if (simplegl.IsSwipeRight(1)) {
                playerTwo.JumpRight();
            }
            if (simplegl.IsSwipeLeft(0)) {
                playerOne.JumpLeft();
            }
            if (simplegl.IsSwipeLeft(1)) {
                playerTwo.JumpLeft();
            }


            // TODO: Do something when player is finished
            // Use this function: PlayerOne.isFinished() or PlayerTwo.isFinished()
        }

	}

    IEnumerator defaultJump(){
        isLoncatKecil = false;
        playerOne.JumpForward();
        playerTwo.JumpForward();
        yield return new WaitForSeconds(1f);
        isLoncatKecil = true;
    }
}
