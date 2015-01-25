﻿using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour {

	GameObject player;
	GameObject win;
	public Vector3[] locationsSpawn;
	public Vector3[] locationsWin;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if(locationsSpawn.Length == 0)
			locationsSpawn[0] = new Vector3(7.2f, 1.2f, 3.1f);

		if(locationsWin.Length == 0)
			locationsWin[0] = new Vector3(76.93f, 3.9f, 89.49f);

		int rand = Random.Range (0, locationsSpawn.Length);
		int randWin = Random.Range (0, locationsWin.Length);

		player.transform.position = locationsSpawn [rand];
		win.transform.position = locationsWin [randWin];

	}

	void Reset(){
		locationsSpawn[0] = new Vector3(7.2f, 1.2f, 3.1f);
		locationsWin[0] = new Vector3(76.93f, 3.9f, 89.49f);
	}
}
