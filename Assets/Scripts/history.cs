using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class history : MonoBehaviour {

	public static history mInstance;

	public GameObject ED1;
	public GameObject ED2;
	public GameObject ED3;
	public GameObject ED4;
	public GameObject ED5;

	public TextMeshProUGUI ED1Name;
	public TextMeshProUGUI ED2Name;
	public TextMeshProUGUI ED3Name;
	public TextMeshProUGUI ED4Name;
	public TextMeshProUGUI ED5Name;

	public GameObject postcard;
	public GameObject telecard;
	public GameObject photo;
	public GameObject fav;

	public TextMeshProUGUI postcardName;
	public TextMeshProUGUI telecardName;
	public TextMeshProUGUI photoName;
	public TextMeshProUGUI favName;

	public void forHistory(){

        if (Router.sED1)
        {
            ED1.SetActive(true);
			ED1Name.SetText("无法传达");
        }
        else
        {
            ED1.SetActive(false);
			ED1Name.SetText("？？？");
        }

        if (Router.sED2)
        {
            ED2.SetActive(true);
			ED2Name.SetText("不在服务区");
        }
        else
        {
            ED2.SetActive(false);
			ED2Name.SetText("？？？");
        }

        if (Router.sED3)
        {
            ED3.SetActive(true);
			ED3Name.SetText("不是病毒");
        }
        else
        {
            ED3.SetActive(false);
			ED3Name.SetText("？？？");
        }

		if (Router.sED4)
        {
            ED4.SetActive(true);
			ED3Name.SetText("回不到的过去");
        }
        else
        {
            ED4.SetActive(false);
			ED4Name.SetText("？？？");
        }

        if (Router.sED5)
        {
            ED5.SetActive(true);
			ED5Name.SetText("线上线下");
        }
        else
        {
            ED5.SetActive(false);
			ED5Name.SetText("？？？");
        }

        if (Router.postCardUsed)
        {
            postcard.SetActive(true);
			postcardName.SetText("明信片和信封");
        }
        else
        {
            postcard.SetActive(false);
			postcardName.SetText("？？？");
        }

        if (Router.cameraUsed)
        {
            photo.SetActive(true);
			photoName.SetText("我们的照片");
        }
        else
        {
            photo.SetActive(false);
			photoName.SetText("？？？");
        }

        if (Router.favUsed)
        {
            fav.SetActive(true);
			favName.SetText("可爱的星星");
        }
        else
        {
            fav.SetActive(false);
			favName.SetText("？？？");
        }

        if (Router.teleCardUsed)
        {
            telecard.SetActive(true);
			telecardName.SetText("超级电气猫");
        }
        else
        {
            telecard.SetActive(false);
			telecardName.SetText("？？？");
        }

		Router.forHistory = false;
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
