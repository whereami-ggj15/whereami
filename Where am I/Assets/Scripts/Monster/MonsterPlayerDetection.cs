using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class MonsterPlayerDetection : MonoBehaviour {

	private GameObject monster;
	private NavMeshAgent navigation;
	// Use this for initialization
	void Start () {
		monster = transform.parent.gameObject;
		if(monster != null){
			navigation = monster.GetComponent<NavMeshAgent>();
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
				navigation.SetDestination(other.transform.position);
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
