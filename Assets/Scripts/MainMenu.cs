using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Button PlayBtn;
    public Button SettingsBtn;
    public Button CreditBtn;
    public Button ScoreBoardBtn;
    public Button ExitBtn;

	void Start () {
        PlayBtn = PlayBtn.GetComponent<Button>();
        SettingsBtn = SettingsBtn.GetComponent<Button>();
        CreditBtn = CreditBtn.GetComponent<Button>();
        ScoreBoardBtn = ScoreBoardBtn.GetComponent<Button>();
        ExitBtn = ExitBtn.GetComponent<Button>();
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
