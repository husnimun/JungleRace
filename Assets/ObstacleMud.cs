using UnityEngine;
using System.Collections;

public class ObstacleMud : MonoBehaviour {

	private bool isEffect = false;

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !isEffect) {
			StartCoroutine (startEffectMud (other));
		}
	}

	IEnumerator startEffectMud(Collider other){
		isEffect = true;
		other.gameObject.GetComponent<Player> ().isEffectMud = true;
		yield return new WaitForSeconds (10);
		other.gameObject.GetComponent<Player> ().isEffectMud = false;
		isEffect = false;
	}
}
