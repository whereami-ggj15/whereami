using UnityEngine;
using System.Collections;

public class BackHome : MonoBehaviour {

	void Update () {
		if (Input.anyKeyDown){
			Application.LoadLevel("Home");
		}
	}

}
