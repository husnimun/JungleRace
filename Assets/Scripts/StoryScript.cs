using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour {

    public GameObject image;

	void Start () {
	
	}
	
	
	void FixedUpdate () {
        image.transform.Translate(0, 2, 0);    
	}
}
