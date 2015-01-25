using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class MonsterPingDetection : MonoBehaviour {
	
	private GameObject monster;
	private NavMeshAgent navigation;

	private int layerPing;

	// Use this for initialization
	void Start () {
		layerPing = LayerMask.NameToLayer ("Ping");
		monster = transform.parent.gameObject;
		if(monster != null){
			navigation = monster.GetComponent<NavMeshAgent>();
		}
	}


	void OnTriggerStay(Collider other){
		Debug.Log (other.tag);
		if(other.gameObject.tag == "Ping"){
			navigation.SetDestination(other.transform.position);
		}
	}
}
