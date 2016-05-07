using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ObstacleMud : MonoBehaviour {

	public GameObject effectIcon;

    GameObject effect;
    GameObject player;
	bool isEffect = false;

    float time = 0;

    void LateUpdate() {
        if (isEffect)
        {
            // Put effect icon on top of player object
            effect.transform.position = player.transform.position + new Vector3(0, 3, 0);

            // Slowly fade the opcacity for 10 seconds
            Color temp = effect.GetComponent<SpriteRenderer>().color;
            temp.a = 1 - time / 10;
            effect.GetComponent<SpriteRenderer>().color = temp;
        }
    }


	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && !isEffect) {
            player = other.gameObject;
            effect = Instantiate(effectIcon);
			StartCoroutine (startEffectMud (other));
		}
	}


	IEnumerator startEffectMud(Collider other){
		isEffect = true;
        time = 0;
		other.gameObject.GetComponent<Player>().isEffectMud = true;
		yield return new WaitForSeconds (10);
		other.gameObject.GetComponent<Player>().isEffectMud = false;
		isEffect = false;
        time = 0;
        Destroy(effect.gameObject);
	}
}
