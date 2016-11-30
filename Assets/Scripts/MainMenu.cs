using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(audio);

        GameObject kinect = GameObject.Find("Kinect");
        if (kinect)
        {
            Destroy(kinect.gameObject);
        }
    }

	void Update() {
        if (SceneManager.GetActiveScene().name == "MainMenu" ) {
            if (Input.GetButtonDown("P1_AButton")) {
                SceneManager.LoadScene("DetectPlayer");  
            }
        }
	}

    void OnLevelWasLoaded(int level) {
        if (level == 3 || level == 4 || level == 0)
        {
            if (audio)
            {
                Destroy(audio.gameObject);
            }
        }
    }

    public void PlayBtnPress() {
        SceneManager.LoadScene("DetectPlayer");
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
