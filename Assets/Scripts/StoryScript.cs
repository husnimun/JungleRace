using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

    public MovieTexture movie;

	void Start () {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
	}
	
	
	void FixedUpdate () {
        if(!movie.isPlaying){
            Debug.Log("Movie is done");
            SceneManager.LoadScene("CharacterSelect");
        }

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("CharacterSelect");
        }
	}
}
