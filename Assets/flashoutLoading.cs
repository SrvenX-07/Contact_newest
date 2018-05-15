using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashoutLoading : MonoBehaviour {

	Animation Animation;
    float time;
	public string name;

	// Use this for initialization
	void Start () {
		Animation = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

        if (time >= 1f && Animation.isPlaying == false)
			SceneLoading.mInstance.LoadNewSceneWithName(name);
	}
}
