using UnityEngine;
using System.Linq;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody rb;
    Animator animator;
    new MeshCollider collider;
    MeshRenderer meshRenderer;

    private bool isColliding = false;
	private bool finish = false;
    private int coins = 0;

    private AudioSource audio;

    [SerializeField] public AudioClip audioclip;

    public float forceUp = 250;
    public float forceForward = 100;
    float forceRight = 150;

    public bool isBatasAtas = false;
	public bool isEffectGrass = false;
	public bool isEffectMud = false;

    void Awake() {
        // Load and setup mesh and materials for player
        //string character = Settings.Instance.character;
        //Mesh mesh = (Mesh)Resources.Load("Characters/" + character + "/" + character, typeof(Mesh));
        //Material[] materials = (Resources.LoadAll("Characters/" + character + "/Materials", typeof(Material))).Cast<Material>().ToArray();
        //GetComponent//<MeshFilter>().mesh = mesh;
        //GetComponent<MeshCollider>().sharedMesh = mesh;
        //GetComponent<MeshRenderer>().materials = materials;
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<MeshCollider>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
        audio = GetComponent<AudioSource>();

    }

    void OnCollisionEnter(Collision collision) {
        isColliding = true;
    }

    void OnCollisionExit(Collision collision) {
        isColliding = false;
    }

	void OnTriggerEnter(Collider other) {
		string name = other.name;
		if (name == "FinishLine") {
			finish = true;
		}
	}

    public void JumpForward(){
        if (isColliding) {
            animator.SetTrigger("Jump");
            rb.AddRelativeForce(new Vector3(0, 200, 75));
            audio.PlayOneShot(audioclip, 1.0f);
        }
    }

    public void JumpSkillForward() {
        if (!isBatasAtas) {
	        animator.SetTrigger("Jump");
	        rb.AddRelativeForce(new Vector3(0, 300, 300));
	        audio.Play();
        }
	}

	public void JumpLeft() {
		if (!isBatasAtas) {
			if (transform.position.x > -3) {
				float force;
				float positionX = transform.position.x;
				if (positionX <= 0.2f)
					force = jumpSide(positionX + 3);
				else
					force = jumpSide(positionX);
				animator.SetTrigger("Jump");
				if (isColliding)
					rb.AddRelativeForce(new Vector3(-force, forceUp, 0));
				else
					rb.AddRelativeForce(new Vector3(-force, 0, 0));
				audio.Play(); 
			}
		}
	}

	public void JumpRight() {
		if (!isBatasAtas) {
			if (transform.position.x < 3){
				float force;
				float positionX = transform.position.x;
				if (positionX >= -0.2f)
					force = jumpSide(positionX - 3);
				else
					force = jumpSide(positionX);
				animator.SetTrigger("Jump");
				rb.AddRelativeForce(new Vector3(force, forceUp, 0));
				audio.Play(); 
			}
		}
	}

	public bool isFinish() {
		return finish;
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

    float jumpSide(float dist){
        return (Mathf.Abs(dist)/3)*150;
    }

    public void AddCoin() {
        coins++;
    }

    public int GetCoins() {
        return coins;
    }
}