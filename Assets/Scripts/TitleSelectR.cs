using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelectR : MonoBehaviour
{

	Animation animationS;
	// Use this for initialization
	void Start()
	{
		animationS = gameObject.GetComponent<Animation>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnPointerEnter()
	{
		animationS["TitleSelectR"].speed = 1;
		animationS["TitleSelectR"].time = 0;
		animationS.Play();
	}

	public void OnPointerExit()
	{
		animationS["TitleSelectR"].speed = -1;
		animationS["TitleSelectR"].time = animationS["TitleSelectR"].length;
		animationS.Play();
	}
}
