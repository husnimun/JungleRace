using UnityEngine;
using System.Collections;

public class ObstacleGrass : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			StartCoroutine (startEffectGrass (other));
		}
	}

	IEnumerator startEffectGrass(Collider other){
		other.gameObject.GetComponent<Player> ().isEffectGrass = true;
		yield return new WaitForSeconds (10);
		other.gameObject.GetComponent<Player> ().isEffectGrass = false;
	}
}
