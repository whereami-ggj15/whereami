using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AttackPlayer : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			Vector3 direction = other.transform.position - transform.position;
			bool hitWall = CheckForWall(direction);
			if(!hitWall){
				audio.Play();
				other.SendMessage("Die");
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
