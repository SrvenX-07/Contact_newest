using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class loadingButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Router.LoadingButton = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		Router.LoadingButton = gameObject;
	}
}
