using UnityEngine;
using System.Collections;

public class rock : MonoBehaviour {

	public AudioClip collisionSoundRockGround;
	public AudioClip collisionSoundRockWalls;
	public AudioClip collisionSoundRockWater;

	private static bool isThrowing = false;
	private static GameObject rockGameObject;
	private static float highSpawnRock = 2.5F;
	private static string objectRockName = "Rock";
	private static string obejctPlayerName = "Player";

	private AudioSource audioPlayer;
	private float highLimitUnspawn = -10.0F;

	public static void instanciateAndThrowRock(float force){
		if (!isThrowing){
			rock rockScript;
			Transform playerTransform = GameObject.Find(obejctPlayerName).transform;
			
			isThrowing = true;
			rockGameObject = (GameObject)Instantiate((GameObject)Resources.Load(objectRockName));
			rockScript = rockGameObject.GetComponent<rock>();
			Vector3 tmpPos = playerTransform.localPosition;
			tmpPos.y = highSpawnRock;
			rockGameObject.transform.position = tmpPos;
			rockGameObject.transform.rotation = playerTransform.localRotation;
			rockScript.rigidbody.AddForce(playerTransform.TransformDirection(Vector3.forward) * force);
		}
	}

	private void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "GroundMap"){
			audioPlayer.PlayOneShot(collisionSoundRockGround);
		}
		if (other.gameObject.tag == "WallsMap"){
			audioPlayer.PlayOneShot(collisionSoundRockWalls);
		}
		if (other.gameObject.tag == "WaterMap"){
			audioPlayer.PlayOneShot(collisionSoundRockWater);
			rigidbody.detectCollisions = false;
		}
	}


	private void Start(){
		audioPlayer = GetComponent<AudioSource>();
	}

	private void Update(){
		if (rockGameObject.rigidbody.velocity.magnitude <= 0.0F || rockGameObject.transform.position.y <= highLimitUnspawn){
			isThrowing = false;
			Destroy(rockGameObject);
			rockGameObject = null;
		}
	}
}
