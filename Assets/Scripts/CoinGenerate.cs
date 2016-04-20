using UnityEngine;
using System.Collections;

public class CoinGenerate : MonoBehaviour {

	public GameObject coin;

	public static float positionCoinLast;
	public static float positionCoinAwake;
	float timeElapsed = 0;
	float spawnCycle = 2f;


	// Use this for initialization
	void Start () {
		positionCoinLast = 0f;
		positionCoinAwake = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {
			GameObject temp = Instantiate(coin) as GameObject;
			Vector3 pos = temp.transform.position;
			temp.transform.position = new Vector3 (generateRandomPosition(),pos.y,positionCoinAwake + 20);
			timeElapsed -= spawnCycle;
		}
	}

	float generateRandomPosition(){
		float val = Random.Range(-3,3);
		if(val < -1) return -3;
		else if(val <= 1) return 0;
		else return 3;
	}
}
