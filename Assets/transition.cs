using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour {

	Animation Animation;
	float time;
	// Use this for initialization
	void Start () {
		Animation = gameObject.GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= 1f && Animation.isPlaying == false)
			Destroy(gameObject);
	}
}
