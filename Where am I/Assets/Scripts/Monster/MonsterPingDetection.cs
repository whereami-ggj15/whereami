using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class MonsterPingDetection : MonoBehaviour {
	
	private GameObject monster;
	private NavMeshAgent navigation;

	// Use this for initialization
	void Start () {
		monster = transform.parent.gameObject;
		if(monster != null){
			navigation = monster.GetComponent<NavMeshAgent>();
		}
	}
	
	void OnTriggerEnter(Collider other){
		if(other.tag == "Ping"){
			navigation.SetDestination(other.transform.position);
		}
	}
}
