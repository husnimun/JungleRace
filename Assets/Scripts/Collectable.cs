using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		fixedRotate ();
	}

	void fixedRotate ()
	{
		transform.Rotate (Vector3.up * Time.deltaTime * 100);
	}
}
