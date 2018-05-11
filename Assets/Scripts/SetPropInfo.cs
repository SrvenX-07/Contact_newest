using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetPropInfo : MonoBehaviour, IPointerClickHandler
{

	public Text TipsText;
	public static SetPropInfo minstance;
	public GameObject mGameObject;
	public Image image;
	public Text TitleText;
	public Text ContenText;
	public bool isMask = true;
	public GameObject use;
    
	public GameObject MaskGameObject;
	public GameObject Mask1GameObject;

	public GameObject DooGameObject;
	public GameObject CellPhoneGameObject;

	public GameObject jpg;
	public GameObject png;
	public GameObject smallicon_doph;
	public GameObject smallicon_fav;

	public GameObject phonebook_active;
	public GameObject num1;
	public GameObject num2;

	public GameObject compu;
	public GameObject doph;
	public GameObject jpggirl;
	public GameObject gifgirl;
	public GameObject desk1;
	public GameObject error;
    
	Scene1Item scene1Item = new Scene1Item();

	public GameObject music;

	public GameObject mail1;
	public GameObject mail2;

	AudioSource audiodoo;
	AudioClip clipdoo;

	private int touch1 = 0;
	private float doubleTouchTime = 0;
	private bool _doubleTouch;
	private bool _doubleClick;
	//public GameObject phonograph_active;
	//public GameObject dresser_active;
	//public GameObject keyhole;

	public void OnTouch()
	{
		touch1++;
		Debug.Log("Touch!");
	}

	private void doubleTouch()
	{
		if (touch1 >= 1)
		{
			doubleTouchTime += Time.deltaTime;
			Debug.Log("doubleTouchtime =" + doubleTouchTime);
			if (doubleTouchTime <= 1f)
			{
				if (touch1 == 2)
				{
					_doubleTouch = true;
					doubleTouchTime = 0;
					touch1 = 0;
				}
			} else {
				touch1 = 0;
				doubleTouchTime = 0;
			}
		}
	}

	private void _initDoubleCT()
	{
		_doubleTouch = false;
		_doubleClick = false;
	}
    
	// Use this for initialization
	void Start()
	{
		//if (BG != null)
		//{
		//    audioBG = BG.GetComponent<AudioSource>();
		//    clipBG = BG.GetComponent<AudioSource>().clip;
		//}
		//if (recordGameObject != null)
		//{
		//    audiorecord = recordGameObject.GetComponent<AudioSource>();
		//    cliprecord = recordGameObject.GetComponent<AudioSource>().clip;
		//}

		//if (MusicGameObject != null)
		//{
		//    Debug.Log("enter music");
		//    audiomusic = MusicGameObject.GetComponent<AudioSource>();
		//    clipmusic = MusicGameObject.GetComponent<AudioSource>().clip;
		//}
		minstance = this;
		//if (music != null)
		//{
		//    audio = music.GetComponent<AudioSource>();
		//    clip = music.GetComponent<AudioSource>().clip;
		//}

		//if (CellPhoneGameObject != null)
		//{
		//    audiodoo = CellPhoneGameObject.GetComponent<AudioSource>();
		//    clipdoo = CellPhoneGameObject.GetComponent<AudioSource>().clip;
		//}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.clickCount == 2)
			_doubleClick = true;
	}

	public void postcard()
	{
		Router.postCardUsed = true;
		MaskGameObject.SetActive(true);
	}
	public void envelop_me()
	{
		Router.envelopUsed = true;
		Mask1GameObject.SetActive(true);
	}

	void Update()
	{
		doubleTouch();
		// 如果当前的时间 - 第一次点击的时间 > 0.5秒 直接将点击都回归到false状态  
		// 因为已经没有继续判断的必要了  

		if (_doubleClick || _doubleTouch)
		{
			print("双击");
			mGameObject.SetActive(true);
			switch (transform.name)
			{
				case "cd":
					image.sprite = Resources.Load("cd", typeof(Sprite)) as Sprite;
					TitleText.text = "胶片";
					ContenText.text = "崭新的碟片，不知道里面\n有什么内容。";
					use.SetActive(false);
					_initDoubleCT();

					break;
				case "envelop_me":
					image.sprite = Resources.Load("envelope_me", typeof(Sprite)) as Sprite;
					TitleText.text = "给我的信封";
					ContenText.text = "收件人是我，但里面是空的。";
					use.SetActive(true);
					use.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						envelop_me();
					});
					_initDoubleCT();
					break;
				case "envelope":
					image.sprite = Resources.Load("envelope", typeof(Sprite)) as Sprite;
					TitleText.text = "一堆信封";
					ContenText.text = "看上去都是广告邮件，没\n有打开过。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "postcard":
					image.sprite = Resources.Load("postcard", typeof(Sprite)) as Sprite;
					TitleText.text = "明信片";
					ContenText.text = "有些旧了的明信片，是她\n给我的。";
					use.SetActive(true);
					use.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						postcard();
					});
					_initDoubleCT();
					break;
				case "key":
					image.sprite = Resources.Load("key", typeof(Sprite)) as Sprite;
					TitleText.text = "钥匙";
					ContenText.text = "小钥匙，非常新，新的\n不像我的东西。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "knife":
					image.sprite = Resources.Load("knife", typeof(Sprite)) as Sprite;
					TitleText.text = "裁纸刀";
					ContenText.text = "我的裁纸刀。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "knife2":
					image.sprite = Resources.Load("knife", typeof(Sprite)) as Sprite;
					TitleText.text = "裁纸刀";
					ContenText.text = "嘿，我的裁纸⼑，它\n还跟着我。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "ring":
					image.sprite = Resources.Load("RING", typeof(Sprite)) as Sprite;
					TitleText.text = "文字牌";
					ContenText.text = "我听到了板子的声⾳，\n是不是我的幻觉？";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "card":
					image.sprite = Resources.Load("card", typeof(Sprite)) as Sprite;
					TitleText.text = "电话卡";
					ContenText.text = "我小时候最想要的电话卡\n，超级电气猫。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "jpg":
					image.sprite = Resources.Load("jpg", typeof(Sprite)) as Sprite;
					TitleText.text = "jpg图标";
					ContenText.text = "jpg格式的图片，让我看看是什么……";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "gif":
					image.sprite = Resources.Load("gif", typeof(Sprite)) as Sprite;
					TitleText.text = "gif图标";
					ContenText.text = "gif格式的图片，朋友你好吗？";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "comp":
					image.sprite = Resources.Load("comp", typeof(Sprite)) as Sprite;
					TitleText.text = "我的电脑";
					ContenText.text = "等等，别看里面！";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "fav":
					image.sprite = Resources.Load("fav", typeof(Sprite)) as Sprite;
					TitleText.text = "收藏夹";
					ContenText.text = "里面装的全是我喜欢的东西，好像可以和人分享。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "dolphin":
					image.sprite = Resources.Load("dolphin", typeof(Sprite)) as Sprite;
					TitleText.text = "海豚";
					ContenText.text = "他好像能成为我的挚友。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "photo":
					image.sprite = Resources.Load("photo1", typeof(Sprite)) as Sprite;
					TitleText.text = "照片";
					ContenText.text = "第一次见面时她照的相片，我不太喜欢自己的样子但是我很珍惜跟她的照片。";
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "camera":
					image.sprite = Resources.Load("camera", typeof(Sprite)) as Sprite;
					TitleText.text = "拍立得";
					ContenText.text = "一台相机，我不大喜欢照相。";
					use.SetActive(false);
					_initDoubleCT();
					break;
			}
		}
	}
}
