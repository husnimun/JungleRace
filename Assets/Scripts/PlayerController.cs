using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    
    public GameObject[] charactersPrefab;
    public GameObject playerOneCam;
    public GameObject playerTwoCam;
    public Text timerText;
    public Canvas pauseMenu;

    public Text gameInfoP1;
    public Text gameInfoP2;

    public Text coinsP1;
    public Text coinsP2;

    GameObject playerOneObj;
    GameObject playerTwoObj;

	private GestureListener simplegl;
	private int tempjump;
    private float countDown = 3f;
    private float timer = 0;
    private float minutes = 0;
    private float seconds = 0;
    private bool gameStarted = false;
    private bool gamePaused = false;
    bool isLoncatKecil = true;

    bool finish = false;

    Player playerOne;
    Player playerTwo;

	void Start () {

		//Instantiate player object
//		simplegl = GameObject.Find("Kinect").GetComponent<GestureListener>();

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

        pauseMenu.gameObject.SetActive(true);
        pauseMenu.enabled = false;


    }
	

	void Update () {
		
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            gamePaused = !gamePaused;
            pauseMenu.enabled = gamePaused;
        }
		// Initialized Game
        if (!gameStarted)
        {
            // Print count down text
            if (countDown >= 0.5)
            {
                gameInfoP1.text = countDown.ToString("0");
                gameInfoP2.text = countDown.ToString("0");
                countDown -= Time.deltaTime;

            }
            else
            {
                gameInfoP1.text = "";
                gameInfoP2.text = "";
                gameStarted = true;
            }    
        }

		// Button Listener
        if (gameStarted && !finish)
        {
            timer += Time.deltaTime;
            minutes = Mathf.Floor(timer / 60);
            seconds = timer % 60;
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            coinsP1.text = playerOne.GetCoins().ToString();
            coinsP2.text = playerTwo.GetCoins().ToString();

			buttonListener ("P1");
			buttonListener ("P2");

//			if (simplegl.IsJump(0) || Input.GetKeyDown("space")) {
//				if (!playerOne.isEffectMud)
//					playerOne.JumpSkillForward ();
//            }
//            if (simplegl.IsJump(1)) {
//				if (!playerTwo.isEffectMud)
//					playerTwo.JumpSkillForward ();
//            }
//            if (simplegl.IsSwipeRight(0) || Input.GetKeyDown("d")) {
//				if (!playerOne.isEffectGrass)
//					playerOne.JumpRight ();
//				else
//					playerOne.JumpLeft ();
//            }
//            if (simplegl.IsSwipeRight(1)) {
//				if (!playerTwo.isEffectGrass)
//					playerTwo.JumpRight ();
//				else
//					playerTwo.JumpLeft ();
//            }
//            if (simplegl.IsSwipeLeft(0) || Input.GetKeyDown("a")) {
//				if (!playerOne.isEffectGrass)
//					playerOne.JumpLeft ();
//				else
//					playerOne.JumpRight ();
//            }
//            if (simplegl.IsSwipeLeft(1)) {
//				if (!playerTwo.isEffectGrass)
//					playerTwo.JumpLeft ();
//				else
//					playerTwo.JumpRight ();
//            }
//            if (Input.GetKeyDown (KeyCode.Alpha1) || simplegl.IsSwipeDown(0)) {
//				playerOne.useSkill();
//			}
//            if (Input.GetKeyDown (KeyCode.Alpha2) || simplegl.IsSwipeDown(1)) {
//				playerTwo.useSkill();
//			}
        }

		// End Game
        if (playerOne.isFinish() || playerTwo.isFinish())
        {
            finish = true;
            if (playerOne.isFinish())
            {
                gameInfoP1.text = "You Win!";
                gameInfoP2.text = "You Lose!";

                playerOneCam.GetComponent<CameraController>().setIsFinished(true);
                playerOneCam.transform.RotateAround(playerOneObj.transform.position, Vector3.up, 10 * Time.deltaTime);

            }
            else
            {
                gameInfoP1.text = "You Lose!";
                gameInfoP2.text = "You Win!";

                playerTwoCam.GetComponent<CameraController>().setIsFinished(true);
                playerTwoCam.transform.RotateAround(playerTwoObj.transform.position, Vector3.up, 10 * Time.deltaTime);
            }
        }

	}

    void FixedUpdate(){
        if (isLoncatKecil && !finish && gameStarted && !gamePaused)
        {
            StartCoroutine(defaultJump());
        }
        else
        {
            StopCoroutine(defaultJump());
        }
    }

	public void buttonListener(System.String player){
		Player target = playerOneObj.GetComponent<Player>();
		int kinectTarget = 0;
		if(player.Equals("P1")){
			target = playerOneObj.GetComponent<Player>();
			kinectTarget = 0;
		}else if(player.Equals("P2")){
			target = playerTwoObj.GetComponent<Player>();
			kinectTarget = 1;
		}
		if(/*simplegl.IsJump(kinectTarget)||*/Input.GetButtonDown(player+"_AButton")||Input.GetKeyDown("space")){
			target.JumpSkillForward ();
		}
		if(Input.GetButtonDown(player+"_BButton")||Input.GetKeyDown("c")){
			target.useSkill ();
		}
		if(Input.GetButtonDown(player+"_XButton")){

		}
		if(Input.GetButtonDown(player+"_YButton")){

		}
		if(Input.GetButtonDown(player+"_LeftBumper")){

		}
		if(Input.GetButtonDown(player+"_RightBumper")){

		}
		if(Input.GetButtonDown(player+"_StartButton")){

		}
		if (Input.GetAxis (player+"_Horizontal") > 0||Input.GetKeyDown("d")) {
			target.JumpRight ();
		} else if (Input.GetAxis(player+"_Horizontal") < 0||Input.GetKeyDown("a")) {
			target.JumpLeft ();
		}
		if(Input.GetAxis(player+"_Vertical") > 0||Input.GetKeyDown("w")){
			
		}else if(Input.GetAxis(player+"_Vertical") < 0||Input.GetKeyDown("s")){
			
		}
	}

    IEnumerator defaultJump(){
        isLoncatKecil = false;
        playerOne.JumpForward();
        playerTwo.JumpForward();
        yield return new WaitForSeconds(1f);
        isLoncatKecil = true;
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume() {
        gamePaused = false;
        pauseMenu.enabled = false;
    }

    public void Quit() {
        Application.Quit();
    }
}
