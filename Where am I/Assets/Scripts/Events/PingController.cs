using UnityEngine;
using System.Collections;

public class Ping : MonoBehaviour {

	private float life = 5.0f; //seconds
	
	// Update is called once per frame
	void Update () {
	
	}


	public void setLife(float value){
		life = value;
	}
}
