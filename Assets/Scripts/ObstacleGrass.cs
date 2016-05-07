using UnityEngine;
using System.Collections;

public class ObstacleGrass : MonoBehaviour {

    public GameObject effectIcon;


    GameObject effect;
    GameObject player;
	
    bool isEffect = false;
    float time = 0;

    void LateUpdate() {
        time += Time.deltaTime;
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
			StartCoroutine (startEffectGrass (other));
		}
	}

	IEnumerator startEffectGrass(Collider other){
		isEffect = true;
        time = 0;
		other.gameObject.GetComponent<Player>().isEffectGrass = true;
		yield return new WaitForSeconds (10);
		other.gameObject.GetComponent<Player>().isEffectGrass = false;
		isEffect = false;
        time = 0;
        Destroy(effect.gameObject);
	}
}
