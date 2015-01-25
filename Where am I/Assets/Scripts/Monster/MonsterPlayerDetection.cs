using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(AudioSource))]
public class MonsterPlayerDetection : MonoBehaviour {

	private GameObject monster;
	private NavMeshAgent navigation;
	private AudioSource idleSoundSource;
	//private AudioSource attackSoundSource;
	// Use this for initialization
	void Start () {
		monster = transform.parent.gameObject;
		if(monster != null){
			navigation = monster.GetComponent<NavMeshAgent>();
			idleSoundSource = monster.transform.Find("Growls").GetComponent<AudioSource>();
			//attackSoundSource = gameObject.transform.FindChild("AttackPlayer").GetComponent<AudioSource>();
		}
	}

	void OnTriggerStay(Collider other){
		if(other.tag == "Player"){
			// get vector between player and monster
			Vector3 direction = other.transform.position - transform.position;

			// check for a wall between player and monster
			bool hitWall = CheckForWall(direction);
			if(!hitWall){
				// go get him !
				if(idleSoundSource.isPlaying){
					//idleSoundSource.Stop();
				}

				if(!audio.isPlaying /*&& !attackSoundSource.isPlaying*/){
					audio.Play();
				}
				navigation.SetDestination(other.transform.position);
			}
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			//idleSoundSource.Play();
			audio.Stop();
		}
	}

	bool CheckForWall(Vector3 direction){
		bool hitWall = false;
		RaycastHit hitInfo;
		if(Physics.Raycast(transform.position, direction, out hitInfo, ((SphereCollider) collider).radius)){
			if(hitInfo.collider.gameObject.tag == "Wall"){
				hitWall = true;
			}
		}

		return hitWall;
	}
}
