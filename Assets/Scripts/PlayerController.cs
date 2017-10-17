using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    
	// Character Object
    public GameObject[] charactersPrefab;

	// Player Character
	GameObject playerOneObj;
	GameObject playerTwoObj;
	GameObject playerThreeObj;

	// Camera
	public GameObject playerCamera;
    public Text timerText;
    public Canvas pauseMenu;

    public Text cdtimer;

    public Text coinsP1;
    public Text coinsP2;
	public Text coinsP3;

	private GestureListener simplegl;
	private int tempjump;
    private float countDown = 6f;
    private float timer = 0;
    private float minutes = 0;
    private float seconds = 0;
    private bool gameStarted = false;
    private bool gamePaused = false;
    bool isLoncatKecil = true;
    bool isHighJump = false;

    bool finish = false;
	bool ready1 = false;
	bool ready2 = false;
	bool ready3 = false;

	// Player Component
    Player playerOne;
    Player playerTwo;
	Player playerThree;

	void Start () {

		//Instantiate player object
		// simplegl = GameObject.Find("Kinect").GetComponent<GestureListener>();

        // Instantiate player object with default character
        playerOneObj = Instantiate(charactersPrefab[0]);	// Orang Utan
        playerTwoObj = Instantiate(charactersPrefab[3]);	// Tapir
		playerThreeObj = Instantiate(charactersPrefab[4]);	// Harimau

		// Instantiate Position
        playerOneObj.transform.Translate(-3, 0, 0);
        playerTwoObj.transform.Translate(0, 0, 0);
		playerThreeObj.transform.Translate (3, 0, 0);

		// Get component
        playerOne = playerOneObj.GetComponent<Player>();
        playerTwo = playerTwoObj.GetComponent<Player>();
		playerThree = playerThreeObj.GetComponent<Player>();

        // Set camera
		playerCamera.GetComponent<CameraController> ().SetPlayer(playerTwoObj, 2);

		// Initialize Pause
        pauseMenu.gameObject.SetActive(false);
        pauseMenu.enabled = false;
    }

	void cameraControl(){
		if (playerOneObj.transform.position.z < playerTwoObj.transform.position.z) {
			if (playerOneObj.transform.position.z < playerThreeObj.transform.position.z) {
				playerCamera.GetComponent<CameraController> ().SetPlayer(playerOneObj, 1);
			} else {
				playerCamera.GetComponent<CameraController> ().SetPlayer(playerThreeObj, 3);
			}
		} else {
			if (playerTwoObj.transform.position.z <= playerThreeObj.transform.position.z) {
				playerCamera.GetComponent<CameraController> ().SetPlayer(playerTwoObj, 2);
			} else {
				playerCamera.GetComponent<CameraController> ().SetPlayer(playerThreeObj, 3);
			}
		}
	}

	void loginUser () {
		// Control Player 1
		if(Input.GetKeyDown("z")){
			controlPlayer (playerOne);
			ready1 = true;
		}
		// Control Player 2
		if(Input.GetKeyDown("x")){
			controlPlayer (playerTwo);
			ready2 = true;
		}
		// Control Player 3
		if(Input.GetKeyDown("c")){
			controlPlayer (playerThree);
			ready3 = true;
		}
	}

	void Update () {

		// Camera Control
		cameraControl();

		// Pause Listener
        if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetButtonDown("P1_StartButton"))
        {
            gamePaused = !gamePaused;
            pauseMenu.enabled = gamePaused;
        }

		// Initialized Game
        if (!gameStarted)
        {
			loginUser ();
            // Print count down text
			if (countDown >= 3.0){
				cdtimer.text = "Get Ready";
				countDown -= Time.deltaTime;
			}
			else if (countDown >= 0.5)
			{
				cdtimer.text = countDown.ToString("0");
                countDown -= Time.deltaTime;

            }
            else
            {
				cdtimer.text = "";
                gameStarted = true;
            }    
        }

		// Game Paused
        if (gamePaused)
        {
			if (Input.GetButtonDown ("P1_AButton")) {
				SceneManager.LoadScene ("MainMenu");
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

			buttonListener2();

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
		if (playerOne.isFinish() && playerTwo.isFinish() && playerThree.isFinish())
        {
            finish = true;
            if (playerOne.isFinish())
            {
                cdtimer.text = "You Win!";

                // playerOneCam.GetComponent<CameraController>().setIsFinished(true);
                // playerOneCam.transform.RotateAround(playerOneObj.transform.position, Vector3.up, 10 * Time.deltaTime);

            }
            else
            {
                cdtimer.text = "You Lose!";

                // playerTwoCam.GetComponent<CameraController>().setIsFinished(true);
                // playerTwoCam.transform.RotateAround(playerTwoObj.transform.position, Vector3.up, 10 * Time.deltaTime);
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

	public void controlPlayer(Player player){
		
		// Check Status Mud Player
		float i = 1.0f;
		if (player.isEffectMud){
			i = 0.5f;
		}else{
			i = 1.0f;
		}

		// Jump
		if(!player.isFinish() && gameStarted){
			player.JumpForward (i);
		}

		if (!gameStarted){
			player.JumpDefault ();
		}
	}

	public void buttonListener2(){
		
		// Control Player 1
		if(Input.GetKeyDown("z")){
			controlPlayer (playerOne);
		}
		// Control Player 2
		if(Input.GetKeyDown("x")){
			controlPlayer (playerTwo);
		}
		// Control Player 3
		if(Input.GetKeyDown("c")){
			controlPlayer (playerThree);
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
		if(Input.GetButtonDown(player+"_AButton")){
            isHighJump = true;
		}
        if(Input.GetButtonUp(player+"_AButton")){
            isHighJump = false;
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
        if(simplegl.IsJump(kinectTarget)){
            float i = 1.0f;
            if (target.isEffectMud){
                i = 0.5f;
            }else{
                i = 1.0f;
            }
            if (isHighJump)
            {
                target.JumpSkillForward(i); 
            }
            else
            {
                target.JumpForward(i);
            }
		}
		if(Input.GetButtonDown(player+"_StartButton")){

		}
        if (simplegl.IsSwipeRight(kinectTarget)||Input.GetAxis (player+"_Horizontal") > 0||Input.GetKeyDown("d")) {
            if (!target.isEffectGrass)
            {
                target.JumpRight();
            }
            else
            {
                target.JumpLeft();
            }
			
        } else if (simplegl.IsSwipeLeft(kinectTarget)||Input.GetAxis(player+"_Horizontal") < 0||Input.GetKeyDown("a")) {
            if (!target.isEffectGrass)
            {
                target.JumpLeft();
            }
            else
            {
                target.JumpRight();
            }
		}
		if(Input.GetAxis(player+"_Vertical") > 0||Input.GetKeyDown("w")){
			
		}else if(Input.GetAxis(player+"_Vertical") < 0||Input.GetKeyDown("s")){
			
		}
	}

    IEnumerator defaultJump(){
        isLoncatKecil = false;
        playerOne.JumpDefault();
        playerTwo.JumpDefault();
		playerThree.JumpDefault();
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
