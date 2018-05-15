using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clamp : MonoBehaviour {
	public GameObject clap1;
	public GameObject clap2;

	float time;
	int count;

	// Use this for initialization
	void Start (){
		Debug.Log("clap");
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time >= 0.3f && time <= 0.4f) {
			clap2.SetActive(false);
			clap1.SetActive(true);
		}
        
		if(time >= 0.5f && time <= 0.6f ) {
			clap2.SetActive(true);
			clap1.SetActive(false);
			time = 0;
		}
			
	}
}
