using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject player;
    private Vector3 offset;
    private bool isFinished = false;
	
	void Start() {
        offset = transform.position - player.transform.position;
    }

    public void SetPlayer(GameObject player) {
        this.player = player;
    }

     Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angle) {
        Vector3 dir = point - pivot;            // get point direction relative to pivot
        dir = Quaternion.Euler(angle) * dir;    // rotate it
        point = dir + pivot;                    // calculate rotated point
        return point;                           // return it
     }

	void LateUpdate() {
        if (!isFinished)
        {
            Vector3 playerPos = player.transform.position;
            transform.position = new Vector3(playerPos.x, 0, playerPos.z) + offset;   
        }
    }

    public void setIsFinished(bool val) {
        isFinished = val;
    }

    IEnumerator Shake() {

        float elapsed = 0.0f;
        float duration = 1.0f;
        float magnitude = 0.01f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration) {

            elapsed += Time.deltaTime;          

            float percentComplete = elapsed / duration;         
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }

}
