using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class MainMenu : MonoBehaviour {
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(audio);
    }

	void Update() {
        if (EditorSceneManager.GetActiveScene().name == "MainMenu" ) {
            if (Input.GetButtonDown("P1_AButton")) {
                SceneManager.LoadScene("CharacterSelect");  
            }
        }
	}

    void OnLevelWasLoaded(int level) {
        if (level == 3 || level == 4 || level == 0)
        {
            Destroy(audio.gameObject);
        }
    }

    public void PlayBtnPress() {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void CreditBtnPress() {

    }

    public void ExitBtnPress() {

    }

    public void ScoreBoardBtnPress() {

    }

    public void SettingsBtnPress() {

    }
}
