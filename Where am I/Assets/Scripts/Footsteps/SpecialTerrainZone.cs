using UnityEngine;
using System.Collections;

public class SpecialTerrainZone : MonoBehaviour {
	
	public AudioClip footstepsSound;

	private GameObject player;
	private PlayerFootsteps footsteps;

	// Use this for initialization
	void Start () {
		string playerObjectName = "Player";
		player = GameObject.Find(playerObjectName);
	
		if(player == null){
			Debug.LogWarning(gameObject.name + " can't find player's footsteps audio source", this);
		} else {
			footsteps = player.GetComponentInChildren<PlayerFootsteps>();
		}

		if(footstepsSound == null){
			Debug.LogWarning(gameObject.name + " does'nt have any audio clip set");
		}
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			footsteps.SetFootstepsSound(footstepsSound);
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			footsteps.ResetToDefault();
		}
	}
}
