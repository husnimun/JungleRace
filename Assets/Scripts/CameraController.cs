using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    GameObject player;
    private Vector3 offset;
	
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

	void FixedUpdate() {
        //transform.position = player.transform.rotation * (player.transform.position + offset
        // Vector3 rotation = new Vector3(rotateX, rotateY, rotateZ
        // transform.rotation = Quaternion.Euler(rotation);
        Vector3 playerPos = player.transform.position;
        transform.position = new Vector3(playerPos.x, 0, playerPos.z) + offset;
    }
}
