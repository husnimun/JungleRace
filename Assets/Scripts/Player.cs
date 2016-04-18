using UnityEngine;
using System.Linq;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody rb;
    Animator animator;
    new MeshCollider collider;
    MeshRenderer meshRenderer;

    public bool isColliding = false;
    public float forceUp = 250;
    public float forceForward = 100;
    public float forceRight = 100;

    void Awake() {
        // Load and setup mesh and materials for player
        //string character = Settings.Instance.character;
        //Mesh mesh = (Mesh)Resources.Load("Characters/" + character + "/" + character, typeof(Mesh));
        //Material[] materials = (Resources.LoadAll("Characters/" + character + "/Materials", typeof(Material))).Cast<Material>().ToArray();
        //GetComponent<MeshFilter>().mesh = mesh;
        //GetComponent<MeshCollider>().sharedMesh = mesh;
        //GetComponent<MeshRenderer>().materials = materials;
    }

    void Start() {
        //Debug.Log(Settings.Instance.playerOne);
        //Debug.Log(Settings.Instance.playerTwo);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<MeshCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
    }

    void OnCollisionEnter(Collision collision) {
        isColliding = true;
    }

    void OnCollisionExit(Collision collision) {
        isColliding = false;
    }

    public void JumpForward() {
        if ((true)) {
            animator.SetTrigger("Jump");
            rb.AddRelativeForce(new Vector3(0, forceUp, forceForward));
        }
	}

	public void JumpLeft() {
		if ((isColliding)) {
			animator.SetTrigger("Jump");
			rb.AddRelativeForce(new Vector3(-forceRight, forceUp, 0));
		}
	}

	public void JumpRight() {
		if ((isColliding)) {
			animator.SetTrigger("Jump");
			rb.AddRelativeForce(new Vector3(forceRight, forceUp, 0));
		}
	}
        //void FixedUpdate() {
        //    if ((isColliding) && Input.GetKeyDown("up")) {
        //        animator.SetTrigger("Jump");
        //        rb.AddRelativeForce(new Vector3(0, forceUp, forceForward));
        //    } else if ((isColliding) && Input.GetKeyDown("left")) {
        //        animator.SetTrigger("Jump");
        //        rb.AddRelativeForce(new Vector3(-forceRight, forceUp, 0));
        //    } else if ((isColliding) && Input.GetKeyDown("right")) {
        //        animator.SetTrigger("Jump");
        //        rb.AddRelativeForce(forceRight, forceUp, 0);
        //    } else if ((isColliding) && Input.GetKeyDown("down")) {
        //        animator.SetTrigger("Jump");
        //        rb.AddRelativeForce(0, forceUp, -forceForward);
        //    }
        //}
    }
      