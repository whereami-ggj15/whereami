using UnityEngine;
using System.Collections;

public class OnTalk : MonoBehaviour {
	MicControlC input;

	public AudioSource noise;
	public float minLoudnessToTrigger = 0.0f;

	// Use this for initialization
	void Awake () {
		input = GetComponent<MicControlC> ();
		noise.Play ();
	}

	void Update(){
		float loudness = input.loudness;
		//Debug.Log (loudness);

		if (loudness > minLoudnessToTrigger && !noise.isPlaying){
			noise.Play (); // play le bruit de communication
			//on débloque l'input
			//input.StartMicrophone();
		}
		else if(loudness < minLoudnessToTrigger){
			noise.Stop(); //stop le noise communication
			// on bloque le son input
			//input.StopMicrophone();
		}
	}
}
