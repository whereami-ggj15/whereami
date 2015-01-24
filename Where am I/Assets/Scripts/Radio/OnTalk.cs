using UnityEngine;
using System.Collections;

public class OnTalk : MonoBehaviour {
	MicControlC input;

	public AudioSource noise;
	public float minLoudnessToTrigger = 0.0f;

	// Use this for initialization
	void Awake () {
		input = GetComponent<MicControlC> ();
		//input.StopMicrophone();
	}

	void Update(){
		float loudness = input.loudness - 0.2f;
		//Debug.Log (loudness);

		if (loudness > minLoudnessToTrigger && !noise.isPlaying){
			noise.Play (); // play le bruit de communication
		}
		else if(loudness < minLoudnessToTrigger){
			noise.Stop(); //stop le noise communication
		}
	}
}
