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
			if ((simplegl.IsSwipeLeft (0) || Input.GetKeyDown("left") ) && playerOne > 0) {
				playerOne--;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
			}
			if ((simplegl.IsSwipeRight (0) || Input.GetKeyDown("right") ) && playerOne < pointerMax - 1) {
				playerOne++;
                playerOne = playerOne % characters.Length;
				pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
			}
            if (simplegl.IsSwipeDown(0) || (Input.GetKeyDown("down")) && playerOne < pointerMax - 3) {
                playerOne= playerOne + 3;
                playerOne = playerOne % characters.Length;
                pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
            }
            if (simplegl.IsSwipeUp(0) || (Input.GetKeyDown("up")) && playerOne >= 3) {
                playerOne= playerOne - 3;
                playerOne = playerOne % characters.Length;
                pointerP1.transform.localPosition = characters [playerOne].transform.localPosition;
            }
			if (simplegl.IsJump (0) || Input.GetKeyDown("space") ) {
				P1Selected = true;
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
			if (Input.GetKeyDown("space")) {
				P1Selected = true;
			}
		}
			
    }

    void PlayerTwoSelect() {
		if (simplegl) {
			if ((simplegl.IsSwipeLeft (1) || Input.GetKeyDown ("left")) && playerTwo > 0) {
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
			if ((simplegl.IsSwipeRight (1) || Input.GetKeyDown ("right")) && playerTwo < pointerMax - 1) {
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
			if (simplegl.IsJump (1) || simplegl.IsSwipeUp (1) || Input.GetKeyDown ("space")) {
				P2Selected = true;
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
			if (Input.GetKeyDown ("space")) {
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
