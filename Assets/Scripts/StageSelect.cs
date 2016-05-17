using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {
	
    public Image pointer;
    public Image thumbnail;
    public Text stageName;
    public Text stageInfo;
    public Sprite[] stages;

    private int stage = 0;
    private int stageMax = 5;
    private string[] stagesName;
    private string[] stagesInfo;

	private GestureListener simplegl;

    void Start() {
        stageMax = stages.Length;
        Debug.Log(stageMax);

        stagesName = new string[stages.Length];
        stagesName[0] = "Hutan";
        stagesName[1] = "Salju";
        stagesName[2] = "Padang Tandus";
        stagesName[3] = "Rawa";
        stagesName[4] = "Kanopi";

        stagesInfo = new string[stages.Length];
        stagesInfo[0] = "Stage ini memiliki tingkat kesulitan yang rendah, dengan jebakan dominan batu besar. Stage ini memiliki panjang lintasan yang dapat diselesaikan dalam 1 menit.";
        stagesInfo[1] = "";
        stagesInfo[2] = "";
        stagesInfo[3] = "";
        stagesInfo[4] = "";

		simplegl = GameObject.Find ("Kinect").GetComponent<GestureListener>();
    }
	void Update () {
		if (Input.GetKeyDown("space") || simplegl.IsJump(0))
        {
            if (stage == 0)
            {
                SceneManager.LoadScene("Game");
            }
            else if (stage == 1)
            {
                SceneManager.LoadScene("Salju");
            }
        }

		if (Input.GetKeyDown("right") || simplegl.IsSwipeRight (0))
        {
            if (stage < (stageMax - 1))
            {
                stage++;
                pointer.transform.localPosition += new Vector3(130, 0, 0);
                stageName.text = stagesName[stage];
                stageInfo.text = stagesInfo[stage];
                thumbnail.gameObject.GetComponent<Image>().sprite = stages[stage];
            }
        }

		if (Input.GetKeyDown("left") || simplegl.IsSwipeLeft (0))
        {
            if (stage > 0)
            {
                stage--;
                pointer.transform.localPosition += new Vector3(-130, 0, 0);
                stageName.text = stagesName[stage];
                stageInfo.text = stagesInfo[stage];
                thumbnail.gameObject.GetComponent<Image>().sprite = stages[stage];
            }
        }
    }
}
