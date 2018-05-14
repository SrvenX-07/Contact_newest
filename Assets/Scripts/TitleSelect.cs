using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSelect : MonoBehaviour
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
		animationS["TitleSelect"].speed = 1;
		animationS["TitleSelect"].time = 0;
		animationS.Play();
	}

	public void OnPointerExit()
	{
		animationS["TitleSelect"].speed = -1;
		animationS["TitleSelect"].time = animationS["TitleSelect"].length;
		animationS.Play();
	}
}
