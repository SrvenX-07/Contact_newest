using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class history : MonoBehaviour {

	public static history mInstance;

	public GameObject ED1;
	public GameObject ED2;
	public GameObject ED3;
	public GameObject ED4;
	public GameObject ED5;

	public Text ED1Name;
	public Text ED2Name;
	public Text ED3Name;
	public Text ED4Name;
	public Text ED5Name;

	public GameObject postcard;
	public GameObject telecard;
	public GameObject photo;
	public GameObject fav;

	public Text postcardName;
	public Text telecardName;
	public Text photoName;
	public Text favName;

	public void forHistory(){

        if (Router.sED1)
        {
            ED1.SetActive(true);
            ED1Name.text = "ED1";
        }
        else
        {
            ED1.SetActive(false);
            ED1Name.text = "？？？";
        }

        if (Router.sED2)
        {
            ED2.SetActive(true);
            ED2Name.text = "ED2";
        }
        else
        {
            ED2.SetActive(false);
            ED2Name.text = "？？？";
        }

        if (Router.sED3)
        {
            ED3.SetActive(true);
            ED3Name.text = "ED3";
        }
        else
        {
            ED4.SetActive(false);
            ED4Name.text = "？？？";
        }

        if (Router.sED5)
        {
            ED5.SetActive(true);
            ED5Name.text = "ED1";
        }
        else
        {
            ED5.SetActive(false);
            ED5Name.text = "？？？";
        }

        if (Router.postCardUsed)
        {
            postcard.SetActive(true);
            postcardName.text = "ED1";
        }
        else
        {
            postcard.SetActive(false);
            postcardName.text = "？？？";
        }

        if (Router.cameraUsed)
        {
            photo.SetActive(true);
            photoName.text = "ED1";
        }
        else
        {
            photo.SetActive(false);
            photoName.text = "？？？";
        }

        if (Router.favUsed)
        {
            fav.SetActive(true);
            favName.text = "ED1";
        }
        else
        {
            fav.SetActive(false);
            favName.text = "？？？";
        }

        if (Router.teleCardUsed)
        {
            telecard.SetActive(true);
            telecardName.text = "ED1";
        }
        else
        {
            telecard.SetActive(false);
            telecardName.text = "？？？";
        }
	}

	// Use this for initialization
	void Start()
	{
		mInstance = this;  
	}
	// Update is called once per frame
	void Update () {
		
	}
}
