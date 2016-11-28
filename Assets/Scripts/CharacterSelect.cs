using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class CharacterSelect : MonoBehaviour {


    public GameObject[] characters;
    public GameObject pointerP1;
    public GameObject pointerP2;

    private int playerOne = 0;
    private int playerTwo = 0;
    private bool P1Selected = false;
    private bool P2Selected = false;
    private bool P1AxisPressed = false;
    private bool P2AxisPressed = false;
    private int pointerMax;

	private GestureListener simplegl;

	void Start () {
        pointerP1.transform.localPosition = characters[playerOne].transform.localPosition;
        pointerP2.transform.localPosition = characters[playerTwo].transform.localPosition;
        HideUI(pointerP2);
        pointerMax = characters.Length;

		simplegl = GameObject.Find ("Kinect").GetComponent<GestureListener>();
	}

    void Update() {
        if (Input.GetButtonDown("P1_BButton")) {
            SceneManager.LoadScene("MainMenu");
        }
            
        if (!P1Selected) {
            PlayerOneSelect();
        } else if (!P2Selected) {
            ShowUI(pointerP2);
            PlayerTwoSelect();
        } else {
            Settings.Instance.playerOne = Settings.Instance.CharacterString(playerOne);
            Settings.Instance.playerTwo = Settings.Instance.CharacterString(playerTwo);
            SceneManager.LoadScene("StageSelect");
        }
    }

	void PlayerOneSelect() {
		if (simplegl) {
            if ((Input.GetKeyDown("left") || ((Input.GetAxis("P1_Horizontal") < 0) && (!P1AxisPressed)) ) && playerOne > 0) {
				playerOne--;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
                P1AxisPressed = true;
			}
            if ((Input.GetKeyDown("right") || ((Input.GetAxis("P1_Horizontal") > 0) && (!P1AxisPressed) )) && playerOne < pointerMax - 1) {
				playerOne++;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
                P1AxisPressed = true;
			}
            if ((Input.GetKeyDown("down") || ((Input.GetAxis("P1_Vertical") < 0) && (!P1AxisPressed) )) && playerOne < pointerMax - 3) {
                playerOne= playerOne + 3;
                playerOne = playerOne % characters.Length;
                pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
                P1AxisPressed = true;
            }
            if ((Input.GetKeyDown("up") || ((Input.GetAxis("P1_Vertical") > 0) && (!P1AxisPressed) )) && playerOne >= 3) {
                playerOne= playerOne - 3;
                playerOne = playerOne % characters.Length;
                pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
                P1AxisPressed = true;
            }
            if (Input.GetButtonDown("P1_AButton")) {
				P1Selected = true;
			}
            if (Input.GetAxis("P1_Horizontal") == 0) {
                P1AxisPressed = false;
            }

		} else {
			if (Input.GetKeyDown("left") && playerOne > 0) {
				playerOne--;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
			}
			if (Input.GetKeyDown("right") && playerOne < pointerMax - 1) {
				playerOne++;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
			}
            if (Input.GetKeyDown("space") || Input.GetButtonDown("P1_AButton")) {
				P1Selected = true;
			}
		}
			
    }

    void PlayerTwoSelect() {
		if (simplegl) {
            if ((Input.GetKeyDown("left") || ((Input.GetAxis("P2_Horizontal") < 0) && (!P2AxisPressed))) && playerTwo > 0) {
				playerTwo--;
				playerTwo = playerTwo % characters.Length;
				pointerP2.transform.localPosition = characters[playerTwo].transform.localPosition;
                P2AxisPressed = true;
			}
            if ((Input.GetKeyDown("right") || ((Input.GetAxis("P2_Horizontal") > 0) && (!P2AxisPressed))) && playerTwo < pointerMax - 1) {
				playerTwo++;
				playerTwo = playerTwo % characters.Length;
				pointerP2.transform.localPosition = characters[playerTwo].transform.localPosition;
                P2AxisPressed = true;
			}
            if ((Input.GetKeyDown("down") || ((Input.GetAxis("P2_Vertical") < 0) && (!P2AxisPressed) )) && playerTwo < pointerMax - 3) {
				playerTwo = playerTwo + 3;
				playerTwo = playerTwo % characters.Length;
				pointerP2.transform.localPosition = characters[playerTwo].transform.localPosition;
                P2AxisPressed = true;
			}
            if ((Input.GetKeyDown("up") || ((Input.GetAxis("P2_Vertical") > 0) && (!P2AxisPressed) )) && playerTwo >= 3) {
				playerTwo = playerTwo - 3;
				playerTwo = playerTwo % characters.Length;
				pointerP2.transform.localPosition = characters[playerTwo].transform.localPosition;
                P2AxisPressed = true;
			}
            if (Input.GetButtonDown("P2_AButton")) {
				P2Selected = true;
			}
            if (Input.GetAxis("P2_Horizontal") == 0) {
                P2AxisPressed = false;
            }
		} else {
			if ((Input.GetKeyDown ("left")) && playerTwo > 0) {
				playerTwo--;
				if (playerTwo == playerOne) {
					if (playerTwo - 1 >= 0) {
						playerTwo--;
					} else {
						playerTwo++;
					}
				}
				pointerP2.transform.localPosition = characters [playerTwo].transform.localPosition;
			}
			if ((Input.GetKeyDown ("right")) && playerTwo < pointerMax - 1) {
				playerTwo++;
				if (playerTwo == playerOne) {
					if (playerTwo + 1 < pointerMax) {
						playerTwo++;
					} else {
						playerTwo--;
					}
				}
				pointerP2.transform.localPosition = characters [playerTwo].transform.localPosition;
			}
            if (Input.GetKeyDown ("space") || Input.GetButtonDown("P2_AButton")) {
				P2Selected = true;
			}
		}
    }

    void HideUI(GameObject UI) {
        CanvasRenderer[] rends = UI.GetComponents<CanvasRenderer>();
        foreach(CanvasRenderer rend in rends) {
            rend.SetAlpha(0);
        }
        Text text = UI.GetComponentInChildren<Text>();
        text.enabled = false;
    }

    void ShowUI(GameObject UI) {
        CanvasRenderer[] rends = UI.GetComponents<CanvasRenderer>();
        foreach (CanvasRenderer rend in rends) {
            rend.SetAlpha(1);
        }
        Text text = UI.GetComponentInChildren<Text>();
        text.enabled = true;
    }
}
