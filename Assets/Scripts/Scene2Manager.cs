﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Manager : MonoBehaviour
{
	public static Scene2Manager mInstance;

	//道具obj钩子    
	public GameObject ringObj;
	public GameObject smallRingObj;

	public GameObject cardObj;
	public GameObject smallCardObj;

	public GameObject knifeObj;
	public GameObject smallKnifeObj;

	public GameObject cameraObj;
	public GameObject smallCameraObj;

	public GameObject smallPhotoObj;

	public GameObject nullObj;
        
	//场景obj钩子
	public GameObject ringBoard;
	public GameObject teleHouse;
	public GameObject teleHouseInside;
	public GameObject grass;
	public GameObject brick;
	public GameObject snow;
	public GameObject holy;
	public GameObject snowman;

	public GameObject booth;

	public GameObject doo;

	public GameObject phoneBook;
	public GameObject phoneBookActive;
	public GameObject num1;
	public GameObject num2;
	public GameObject plug;
	public GameObject numberPad;
	public GameObject cellPhone;
	public GameObject phone;
	public GameObject glass;

	public GameObject arrowL;
	public GameObject arrowR;

	//道具获得状态
	public bool ring;
	public bool card;
	public bool _camera;
	public bool photo;
	public bool knife = true;

	//音频钩子
	//部分使用GoodClickInfo不做改动
	//部分内容单独开始钩子
    AudioSource audioRing;
	AudioClip clipRing;

	AudioSource audioDoo;
	AudioClip clipDoo;

	public GameObject BGM;
	AudioSource BGMAudio;
	AudioClip BGMClip;


	//计数器
	private int i = 0;
	private int d = 0;
	private int c = 0;

	//选择计数器
	public int _knifeSelCount;
	public int _cardSelCount;
	public int _ringSelCount;
	private int _cameraSelCount;
	private int _photoSelCount;

	//中继
	public GameObject selectingItem;
	public GameObject lastSelectItem;
	public bool useSuccess = false;
	public bool useFailed = false;

	public float limitTime = 10f;
	public float textTime = 20f;
	public float startTime;
	public float endTime;
	public float tempTime;

	//计时器
	private float ringTime;

	//选择道具时的操作 模板
	private void _lastScale(GameObject _object)
	{
		_object.GetComponent<RectTransform>().transform.localScale = new Vector2(1f, 1f);
	}

	private void _selectScale(GameObject _object)
	{
		_object.GetComponent<RectTransform>().transform.localScale = new Vector2(1.2f, 1.2f);
	}

	private void select_(GameObject _object)
	{
		selectingItem = _object;
		if (lastSelectItem != null)
			_lastScale(lastSelectItem);
		lastSelectItem = selectingItem;
		tempTime = 0;
	}

	private void _initCount()
	{
		_knifeSelCount = 0;
		_cardSelCount = 0;
		_ringSelCount = 0;
		_cameraSelCount = 0;
		_photoSelCount = 0;
	}

	//获得道具的操作 部分在GoodsClickInfo里
	public void gotRing()
	{
		ring = true;
		Router.ring = ring;
	}

	public void gotCard()
	{
		card = true;
		Router.card = card;
	}

	public void gotKnife()
	{
		knife = true;
		Router.knife2 = knife;
	}

	public void gotCamera()
	{
		_camera = true;
		Router._camera = _camera;
	}

	public void gotPhoto()
	{
		photo = true;
		Router.photo = photo;
	}

	//道具选择的操作
	public void selectKnife()
	{
		_knifeSelCount++;
		select_(smallKnifeObj);
		GoodsClickInfo.mInstance.SetText("我知道你很喜欢划烂东西发出的声音。");
	}

	public void selectCard()
	{
		_cardSelCount++;
		select_(smallCardObj);
		GoodsClickInfo.mInstance.SetText("除了打电话，电话卡用来收藏也挺好的。");
	}

	public void selectRing()
	{
		_ringSelCount++;
		select_(smallRingObj);
		GoodsClickInfo.mInstance.SetText("他太吵了，我宁愿把他挂在哪里。");
	}

	public void selectCamera()
    {
        _cameraSelCount++;
		select_(smallCameraObj);
		GoodsClickInfo.mInstance.SetText("拍张我们的合照吧，就算我不会出现，拜托。");
    }

	public void selectPhoto(){
		_photoSelCount++;
		select_(smallPhotoObj);
		GoodsClickInfo.mInstance.SetText("当时你可真紧张。");
	}


	//处理被选择物件
	//使用失败|成功|超时之后重置
	private void selectingItem_()
	{
		if (tempTime >= limitTime)
		{
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initCount();
		}
		if (useSuccess == true)
		{
			useSuccess = false;
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initCount();
		}
		if (useFailed == true)
		{
			useFailed = false;
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initCount();
		}

		//智障重置法1号
		if (_knifeSelCount >= 2)
		{
			useFailed = true;
		}
		if (_cardSelCount >= 2)
		{
			useFailed = true;
		}
		if (_ringSelCount >= 2)
		{
			useFailed = true;
		}
		if (_cameraSelCount >= 2)
        {
            useFailed = true;
        }
		if (_photoSelCount >= 2)
        {
            useFailed = true;
        }

		_selectScale(selectingItem);
	}

	//对电话本使用
	public void UseOnPhonebook()
	{
		if (selectingItem == smallKnifeObj)
		{
			phoneBook.SetActive(false);
			phoneBookActive.SetActive(true);
			Router.knife2Used = true;
			//播放声音
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

	// 对电话亭使用
	public void UseOnTeleHouse()
	{
		if (selectingItem == smallRingObj)
		{
			teleHouseInside.SetActive(true);
			GoodsClickInfo.mInstance.SetText("里面真的暖和多了！");
			arrowL.SetActive(true);
			arrowR.SetActive(true);
			Router.ringUsed = true;
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

    // 对圣光使用
	public void UseOnHoly()
	{
		if (selectingItem == smallCameraObj)
		{
			//播放声效与动画
			smallPhotoObj.SetActive(true);
			SetpropPos.mInstance.SetPos(smallPhotoObj);
			Destroy(smallCameraObj);
			useSuccess = true;
		} else {
			useFailed = true;
		}
	}

	//对电话使用
	public void UseOnCellphone()
	{
		if (selectingItem == smallRingObj)
		{
			doo.SetActive(true);
			audioDoo.PlayOneShot(clipDoo);
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

	//对插卡口使用
	public void UseOnPlug()
	{
		if (selectingItem == smallCardObj)
		{
			num1.SetActive(true);
			if(Router.knife2Used)
			    num2.SetActive(true);
			Router.teleCardUsed = true;
			Destroy(smallCardObj);
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

	public void diaNum1()
	{
		if (Router.teleCardUsed)
		{
			Router.diaNum1st = true;
			Router.mInstance.result();
		}

		else
			GoodsClickInfo.mInstance.SetText("我想人们在拨号之前需要先插卡。");
	}

	public void diaNum2()
	{
		if (Router.teleCardUsed)
		{
			Router.diaNum2nd = true;
			Router.mInstance.result();
		}
		else
			GoodsClickInfo.mInstance.SetText("我想人们在拨号之前需要先插卡。");

	}

	//复盘动作
	private void ResetPosInfo()
	{
		if(Router.isLoaded == true)
		{
			if (Router.ring == true){
				SetpropPos.mInstance.SetPos(smallRingObj);
				ringObj.SetActive(false);
				ringBoard.SetActive(false);
				gotRing();
			}
			if (Router.card == true){
				SetpropPos.mInstance.SetPos(smallCardObj);
				brick.SetActive(false);
				gotCard();}
			Router.isLoaded = false;
		}
	}

    //点击圣光
	public void OnHoly(){
		int count = Random.Range(1, 4);
		switch (count) {
			case 1:
				GoodsClickInfo.mInstance.SetText("你看！圣光！");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("如果有相机我想我们还能在这里拍个照。");
				break;
			default:
				break;
		}
	}

    //点击拨号盘
	public void OnNumPad(){
		int count = Random.Range(1, 2);
		switch(count) {
			case 1:
				GoodsClickInfo.mInstance.SetText("你想好要打谁的电话了吗。");
				break;
			default:
				break;
		}
		num1.SetActive(true);
        if (Router.knife2Used)
            num2.SetActive(true);
	}

    //点击拨号盘
	public void OnCellPhone(){
		int count = Random.Range(1, 3);
        switch (count)
        {
            case 1:
				GoodsClickInfo.mInstance.SetText("我打赌这台手机上没有游戏。");
                break;
			case 2:
				GoodsClickInfo.mInstance.SetText("真可惜我们不能玩他。");
				break;
            default:
                break;
        }
	}

    //点击雪人
	public void OnSnowMan(){
		int count = Random.Range(1, 4);
		switch (count)
		{
			case 1:
				GoodsClickInfo.mInstance.SetText("一个雪人！");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("还是这个雪人！");
				break;
			case 3:
				snowman.SetActive(false);
				cameraObj.SetActive(true);
				GoodsClickInfo.mInstance.SetText("这是我给你的相机吧？");
				break;
			default:
				break;
		}
	}

	// Use this for initialization
	void Start()
	{
		mInstance = this;

		audioRing = ringBoard.GetComponent<AudioSource>();
		clipRing = ringBoard.GetComponent<AudioSource>().clip;

		audioDoo = cellPhone.transform.GetComponent<AudioSource>();
		clipDoo = cellPhone.transform.GetComponent<AudioSource>().clip;

		BGMAudio = BGM.GetComponent<AudioSource>();
		BGMClip = BGM.GetComponent<AudioSource>().clip;
		Debug.Log(BGMAudio);

		BGMAudio.Play();
	}

	// Update is called once per frame
	void Update()
	{
		ResetPosInfo();

		if (i == 3)
		{
			ringBoard.SetActive(false);
			ringObj.SetActive(true);
			GoodsClickInfo.mInstance.SetText(null);
			i = 0;
		}

		tempTime += Time.deltaTime;
		selectingItem_();

		//BGM停止后重新播放
		if (BGMAudio.isPlaying == false)
			BGMAudio.Play();

		if (tempTime >= textTime)
		{
			GoodsClickInfo.mInstance.SetText(null);
		}

		Transmision();
	}

	//点击牌子
	public void OnRing()
	{
		audioRing.PlayOneShot(clipRing);
		int a = Random.Range(1, 3);
		switch (a){
			case 1:
				GoodsClickInfo.mInstance.SetText("谁去接了这电话！");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("它为什么还在响？");
				break;
			default:
				break;
		}
		i++;
	}

    //点击电话亭内部
	public void OnBooth()
    {
        int a = Random.Range(1, 4);
        switch (a)
        {
            case 1:
				GoodsClickInfo.mInstance.SetText("里面真的暖和多了。");
                break;
            case 2:
				GoodsClickInfo.mInstance.SetText("我也是第一次感受跟别人挤在一个电话亭里。");
                break;
			case 3:
				GoodsClickInfo.mInstance.SetText("虽然严格来说我现在不算人？");
				break;
            default:
                break;
        }
    }

    //点击电话本
	public void OnPhoneBook(){
		d ++;
		switch (d)
		{
			case 1:
				GoodsClickInfo.mInstance.SetText("你有想要联系的人吗？");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("或许你可以给我打个电话。");
				break;
			case 3:
				GoodsClickInfo.mInstance.SetText("你知道，说说那天的情况什么的……");
				break;
			default:
				GoodsClickInfo.mInstance.SetText("这件事很重要，你必须记住。");
				break;
		}
	}

	public void OnDoo()
	{
		audioDoo.PlayOneShot(clipDoo);

	}

	public void Transmision(){
		if (c >= 1)
		{
			ringTime += Time.deltaTime;
			if (ringTime >= 2f)
				audioRing.PlayOneShot(clipRing);
		}
	}

	public void OnTrans()
	{
		c++;
	}
}