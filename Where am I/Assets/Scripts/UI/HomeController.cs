using UnityEngine;
using System.Collections;

public class HomeController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown){
			Application.LoadLevel("MainLevel");
		}
	}
}
