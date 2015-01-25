using UnityEngine;
using System.Collections;

public class AttackPlayer : MonoBehaviour {

	private AudioSource chaseSoundSource;

	void Start(){
		chaseSoundSource = transform.parent.gameObject.GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Vector3 direction = other.transform.position - transform.position;
			bool hitWall = CheckForWall(direction);
			if(!hitWall){
				if(chaseSoundSource != null && chaseSoundSource.isPlaying){
					chaseSoundSource.Stop();
				}
				other.SendMessage("MonsterDeath");
			}
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
