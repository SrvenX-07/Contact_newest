using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SetPropInfo : MonoBehaviour, IPointerClickHandler
{

	public static SetPropInfo minstance;
	public GameObject mGameObject;
	public Image image;
	public Image backGround;
    public TextMeshProUGUI TitleText;
	public TextMeshProUGUI ContenText;
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
			Debug.Log(doubleTouchTime);
			if (doubleTouchTime <= 0.5f)
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
					TitleText.SetText("唱片");
					ContenText.SetText("崭新的唱片，不知道里面\n有什么内容。");
					use.SetActive(false);
					_initDoubleCT();

					break;
				case "envelop_me":
					image.sprite = Resources.Load("envelope_me", typeof(Sprite)) as Sprite;
					TitleText.SetText("给我的信封");
					ContenText.SetText("收件人是我，但里面是空的。");
					use.SetActive(true);
					use.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						Router.envelopUsed = true;
						Router.mInstance.DataSave();
						Mask1GameObject.SetActive(true);
						mGameObject.SetActive(false);
					});
					_initDoubleCT();
					break;
				case "envelope":
					image.sprite = Resources.Load("envelope", typeof(Sprite)) as Sprite;
					TitleText.SetText("一堆信封");
					ContenText.SetText("看上去都是广告邮件，没\n有打开过。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "postcard":
					image.sprite = Resources.Load("postcard", typeof(Sprite)) as Sprite;
					TitleText.SetText("明信片");
					ContenText.SetText("有些旧了的明信片，是她\n给我的。");
					use.SetActive(true);
					use.GetComponent<Button>().onClick.AddListener(delegate ()
					{
						Router.postCardUsed = true;
                        MaskGameObject.SetActive(true);
						Router.mInstance.DataSave();
						mGameObject.SetActive(false);
					});
					_initDoubleCT();
					break;
				case "key":
					image.sprite = Resources.Load("key", typeof(Sprite)) as Sprite;
					TitleText.SetText("钥匙");
					ContenText.SetText("小钥匙，非常新，新的\n不像我的东西。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "knife":
					image.sprite = Resources.Load("knife", typeof(Sprite)) as Sprite;
					TitleText.SetText("裁纸刀");
					ContenText.SetText("我的裁纸刀。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "knife2":
					image.sprite = Resources.Load("knife", typeof(Sprite)) as Sprite;
					TitleText.SetText("裁纸刀");
					ContenText.SetText("嘿，我的裁纸⼑，它\n还跟着我。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "ring":
					image.sprite = Resources.Load("RING", typeof(Sprite)) as Sprite;
					TitleText.SetText("文字牌");
					ContenText.SetText("我听到了板子的声⾳，\n是不是我的幻觉？");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "card":
					image.sprite = Resources.Load("card", typeof(Sprite)) as Sprite;
					TitleText.SetText("电话卡");
					ContenText.SetText("我小时候最想要的电话卡\n，超级电气猫。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "jpg":
					image.sprite = Resources.Load("jpg", typeof(Sprite)) as Sprite;
					TitleText.SetText("jpg图标");
					ContenText.SetText("jpg格式的图片，让我看看是什么……");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "gif":
					image.sprite = Resources.Load("gif", typeof(Sprite)) as Sprite;
					TitleText.SetText("gif图标");
					ContenText.SetText("gif格式的图片，朋友你好吗？");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "comp":
					image.sprite = Resources.Load("comp", typeof(Sprite)) as Sprite;
					TitleText.SetText("我的电脑");
					ContenText.SetText("等等，别看里面！");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "fav":
					image.sprite = Resources.Load("fav", typeof(Sprite)) as Sprite;
					TitleText.SetText("收藏夹");
					ContenText.SetText("里面装的全是我喜欢的东西，好像可以和人分享。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "dolphin":
					image.sprite = Resources.Load("dolphin", typeof(Sprite)) as Sprite;
					TitleText.SetText("海豚");
					ContenText.SetText("他好像能成为我的挚友。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "photo":
					image.sprite = Resources.Load("photo1", typeof(Sprite)) as Sprite;
					TitleText.SetText("照片");
					ContenText.SetText("第一次见面时她照的相片。\n我不太喜欢自己的样子，但是我很珍惜跟她的照片。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "camera":
					image.sprite = Resources.Load("camera", typeof(Sprite)) as Sprite;
					TitleText.SetText("拍立得");
					ContenText.SetText("一台相机，我不大喜欢照相。");
					use.SetActive(false);
					_initDoubleCT();
					break;
				case "postcard_h":
					backGround.sprite = Resources.Load("mask", typeof(Sprite)) as Sprite;
                    backGround.color = new Vector4(0, 0, 0, 0.5f);
                    image.sprite = Resources.Load("postcard_h", typeof(Sprite)) as Sprite;
					TitleText.SetText("明信片和信封");
					ContenText.SetText("<color=#009B9B>这是我用漂流瓶发现艾米之后进行的第一次通信，\n\n我给了艾米一封信，她给了我明信片。\n\n我还记得自己开心的样子，她是我的第一位朋友，我不应该对她这么做。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "card_h":
					backGround.sprite = Resources.Load("mask", typeof(Sprite)) as Sprite;
                    backGround.color = new Vector4(0, 0, 0, 0.448f);
                    image.sprite = Resources.Load("card_h", typeof(Sprite)) as Sprite;
                    TitleText.SetText("超级电气猫");
					ContenText.SetText("<color=#FF8C8C>艾米很喜欢这只猫，用完之后就把它给了我。\n\n我和她虽然在不同的地方，但是我们约好在红色电话亭见面。\n\n我不喜欢雪天，但是艾米喜欢。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "photo_h":
					backGround.sprite = Resources.Load("mask", typeof(Sprite)) as Sprite;
                    backGround.color = new Vector4(0, 0, 0, 0.448f);
                    image.sprite = Resources.Load("photo1", typeof(Sprite)) as Sprite;
                    TitleText.SetText("我们的照片");
					ContenText.SetText("<color=#E85700>我只是不知道怎么做。\n\n艾米说的对，我不能总生活在游戏里。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "fav_h":
					backGround.sprite = Resources.Load("mask", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(0, 0, 0, 0.448f);
                    image.sprite = Resources.Load("fav_h", typeof(Sprite)) as Sprite;
                    TitleText.SetText("给艾米的精选集");
					ContenText.SetText("<color=#946D00>我有很多有意思的东西。\n\n可在网络上我会认真玩游戏，线下又会很紧张。\n\n或许我不该这么想，我和艾米是很好的朋友，不是吗？</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "ed1":
					backGround.sprite = Resources.Load("ed1", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(1, 1, 1, 1);
					image.sprite = Resources.Load("mask-nothing", typeof(Sprite)) as Sprite;
					TitleText.SetText("");
					ContenText.SetText("<color=#000>不！我第一次写给她的信，竟然不见了，这可不好。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "ed2":
					backGround.sprite = Resources.Load("ed2", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(1, 1, 1, 1);
					image.sprite = Resources.Load("mask-nothing", typeof(Sprite)) as Sprite;
					TitleText.SetText("");
					ContenText.SetText("<color=#000>她的号码是多少？\n我明明有记下来过，那个声音也在让我打电话给她。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "ed3":
					backGround.sprite = Resources.Load("ed3", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(1, 1, 1, 1);
					image.sprite = Resources.Load("mask-nothing", typeof(Sprite)) as Sprite;
					TitleText.SetText("");
					ContenText.SetText("<color=#000>线下可没有慷慨的海豚，我们应该记下来。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "ed4":
					backGround.sprite = Resources.Load("ed4", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(1, 1, 1, 1);
					image.sprite = Resources.Load("mask-nothing", typeof(Sprite)) as Sprite;
					TitleText.SetText("");
					ContenText.SetText("<color=#000>我最后还是选了线上，这样做对吗？</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
				case "ed5":
					backGround.sprite = Resources.Load("ed5", typeof(Sprite)) as Sprite;
					backGround.color = new Vector4(1, 1, 1, 1);
					image.sprite = Resources.Load("mask-nothing", typeof(Sprite)) as Sprite;
					TitleText.SetText("");
					ContenText.SetText("<color=#000>艾米，我错了，我不应该放你鸽子，这是我最错误的决定，我会尽我的所能改正这件事。\n\n对了，还有你，就是你，我知道是你帮助我找回艾米。\n\n你做到了，你是最好的人，谢谢。</color>");
                    use.SetActive(false);
                    _initDoubleCT();
                    break;
			}
		}
	}
}
