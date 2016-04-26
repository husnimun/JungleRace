using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    AudioSource audio;

    void Start() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(audio);
    }

    void OnLevelWasLoaded(int level) {
        if (level == 3)
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
