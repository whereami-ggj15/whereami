using UnityEngine;
using System.Collections;

public class CameraEffects : MonoBehaviour {

	NoiseEffect noise;
	BlurEffect blur;

	void Start(){
		noise = GetComponent<NoiseEffect> ();
		blur = GetComponent<BlurEffect> ();
	}
	// NOISE
	public void ActivateNoise(){
		noise.enabled = true;
		if(blur != null)
			blur.enabled = true;
	}

	public void DeactivateNoise(){
		noise.enabled = false;
		if(blur != null)
			blur.enabled = false;
	}
}
