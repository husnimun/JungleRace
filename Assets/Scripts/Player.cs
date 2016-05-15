﻿using UnityEngine;
using System.Linq;
using System.Collections;

public class Player : MonoBehaviour {

    Rigidbody rb;
    Animator animator;
    new MeshCollider collider;
    MeshRenderer meshRenderer;

	private int skillItem = 0;

    private bool isColliding = false;
	private bool finish = false;
    private int coins = 0;

    private AudioSource audio;

    [SerializeField] public AudioClip audioclip;

    public float forceUp = 250;
    public float forceForward = 100;
    float forceRight = 150;

	public GameObject item;
    public bool isBatasAtas = false;
	public bool isEffectGrass = false;
	public bool isEffectMud = false;
	public bool isEffectItem = false;

	public int jumlahSkill = 2;

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

	public int getSkill(){
		return skillItem;
	}

	public void setSkill(){
		skillItem = Random.Range (1,jumlahSkill+1);
	}

	public void useSkill(){
		if(skillItem == 1){
			thrownItem ();
		}else if(skillItem == 2){
			putItem ();
		}
		skillItem = 0;
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
		if (isColliding && !isEffectItem) {
            animator.SetTrigger("Jump");
            rb.AddRelativeForce(new Vector3(0, 200, 75));
            audio.PlayOneShot(audioclip, 1.0f);
        }
    }

    public void JumpSkillForward() {
		if (!isBatasAtas && !isEffectItem) {
	        animator.SetTrigger("Jump");
	        rb.AddRelativeForce(new Vector3(0, 300, 300));
	        audio.Play();
        }
	}

	public void JumpLeft() {
		if (!isBatasAtas && !isEffectItem) {
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
		if (!isBatasAtas && !isEffectItem) {
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

	public void thrownItem(){
		if (!isEffectItem) {
			GameObject itemThrown = Instantiate (item) as GameObject;
			itemThrown.GetComponent<ItemBall> ().isPut = false;
			Vector3 pos = itemThrown.transform.position;
			itemThrown.transform.position = new Vector3 (rb.transform.position.x, pos.y, rb.transform.position.z + 2);
		}
	}

	public void putItem(){
		if (!isEffectItem) {
			GameObject itemThrown = Instantiate (item) as GameObject;
			itemThrown.GetComponent<ItemBall> ().isPut = true;
			Vector3 pos = itemThrown.transform.position;
			itemThrown.transform.position = new Vector3 (rb.transform.position.x, pos.y, rb.transform.position.z - 2);
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