using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Router.GameSetting = gameObject;
		Router.SettingFadeIn =gameObject.GetComponent<Animation>();

	}
	
	// Update is called once per frame
	void Update () {
		Router.GameSetting = gameObject;
		Router.SettingFadeIn = gameObject.GetComponent<Animation>();

	}
}
