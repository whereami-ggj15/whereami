using UnityEngine;
using System.Collections;

public class bodyLR : MonoBehaviour {

	public AudioClip sound;
	public float movementLevelDetection = 0.2F;
	public enum e_dir {NONE, FRONT, BACK, RIGHT, LEFT }

	private PlayerController controller;
	private AudioSource audioPlayer;
	private bool isTouching = false;
	private bool soundLock = false;
	private bool canIPlay = true;

	private static e_dir dir;

	private void Start(){
		controller = GetComponentInParent<PlayerController>();
		audioPlayer = GetComponent<AudioSource>();
	}

	private void FixedUpdate(){
		if (isTouching && !soundLock && ((canIPlay && tag != "bodyFront" && tag != "bodyBack") || tag != "bodyFront" || tag != "bodyBack")){
			audio.loop = true;
			audio.clip = sound;
			audio.Play();
			soundLock = true;
		}
		if (!isTouching || (!canIPlay && tag != "bodyFront" && tag != "bodyBack")){
			audio.Stop ();
			soundLock = false;
			dir = e_dir.NONE;
		}
		if (controller.getMove() < movementLevelDetection)
			canIPlay = false;
		else
			canIPlay = true;
	}

	private void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Walls"){
			if (this.tag == "bodyLeft"){
				Debug.Log ("Le joueur se frotte contre un mur left");
				controller.gamePadShake(10.0F, 0.0F);
				isTouching = true;
				dir = e_dir.LEFT;
			}
			if (this.tag == "bodyRight"){
				Debug.Log ("Le joueur se frotte contre un mur right");
				controller.gamePadShake(0.0F, 10.0F);
				isTouching = true;
				dir = e_dir.RIGHT;
			}
			if (this.tag == "bodyFront"){
				Debug.Log ("Le joueur se frotte contre un mur devant");
				controller.gamePadShake(10.0F, 10.0F);
				isTouching = true;
				dir = e_dir.FRONT;
			}
			if (this.tag == "bodyBack"){
				Debug.Log ("Le joueur se frotte contre un mur derriere");
				controller.gamePadShake(10.0F, 10.0F);
				isTouching = true;
				dir = e_dir.BACK;
			}
		}
	}

	private void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Walls"){
			if (this.tag == "bodyLeft"){
				Debug.Log ("Le joueur se frottait contre un mur left");
				controller.gamePadShake(0.0F, 0.0F);
				isTouching = false;
			}
			if (this.tag == "bodyRight"){
				Debug.Log ("Le joueur se frottait contre un mur right");
				controller.gamePadShake(0.0F, 0.0F);
				isTouching = false;
			}
			if (this.tag == "bodyFront"){
				Debug.Log ("Le joueur se frottait contre un mur devant");
				controller.gamePadShake(0.0F, 0.0F);
				isTouching = false;
			}
			if (this.tag == "bodyBack"){
				Debug.Log ("Le joueur se frottait contre un mur derriere");
				controller.gamePadShake(0.0F, 0.0F);
				isTouching = false;
			}
		}
	}

	public static void placeBackWall(){
		if (dir == e_dir.FRONT){

		}
		if (dir == e_dir.BACK){

		}
		if (dir == e_dir.LEFT){

		}
		if (dir == e_dir.RIGHT){

		}
	}
}
