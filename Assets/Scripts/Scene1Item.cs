using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scene1Item : MonoBehaviour
{
	public static Scene1Item mInstance;

	//道具obj钩子
	public GameObject knifeObj;
	public GameObject smallKnifeObj;

	public GameObject keyObj;
	public GameObject smallKeyObj;

	public GameObject cdObj;
	public GameObject smallCdObj;

	public GameObject adsObj;
	public GameObject smallAdsObj;

	public GameObject envelopObj;
	public GameObject smallEnvelopObj;

	public GameObject postcardObj;
	public GameObject smallPostcardObj;

	public GameObject nullObj;

	//场景obj钩子
	public GameObject bed;
	public GameObject bedActive;
	public GameObject bedActive2;

	public GameObject desk;
	public GameObject books;
	public GameObject twitter;

	public GameObject chair;

	public GameObject poster;
	public GameObject posterActive;

	public GameObject paint;
	public GameObject lamp;

	public GameObject curtain;
	public GameObject curtainActive;

	public GameObject keyhole;
	public GameObject keyholeActive;

	public GameObject carpet;
	public GameObject carpetActive;

	public GameObject dresser;
	public GameObject dresserActive;
	public GameObject dresserActive2;

	public GameObject cloth;

	public GameObject pho;
	public GameObject phoActive;

	public GameObject lightOff;

	//道具的获得状态
	public bool knife;
	public bool key;
	public bool cd;
	public bool ads;
	public bool envelop;
	public bool postcard;

	//中继
	public GameObject selectingItem;
	public GameObject lastSelectItem;
	public bool useSuccess;
	public bool useFailed;

	public float limitTime = 10f;
	public float textTime = 20f;
	public float textTempTIme;
	public float tempTime;

	//部分交互计数器
	private int _OnBooks;
	private int _guideCount;
	private float _guideCountTime;
	private int _chair = 0;
	private int _lamp = 0;

	//选择计数器
	public int _knifeSelCount;
	public int _keySelCount;
	public int _cdSelCount;
	public int _adsSelCount;
	public int _envelopSelCount;
	public int _postcardSelCount;

	//音频资源钩子
	//部分使用GoodsClickInfo不做改动
	//部分内容单独开设钩子
	AudioSource recordAudio;
	AudioClip recordClip;

	public GameObject BGM;
	AudioSource BGMAudio;
	AudioClip BGMClip;
	AudioListener SystemVol;

	// 动画资源钩子
	Animation aGuide;
	Animation eGuide;
	Animation dGuide;
	Animation aChair;
	Animation aCarpet;

	// 初始化
	void Start()
	{
		mInstance = this;

		Router.guideClear = true;

		//初始化时装载音频
		recordAudio = pho.GetComponent<AudioSource>();
		recordClip = pho.GetComponent<AudioSource>().clip;

		BGMAudio = BGM.GetComponent<AudioSource>();
		BGMClip = BGM.GetComponent<AudioSource>().clip;
		SystemVol = BGM.GetComponent<AudioListener>();

		BGMAudio.Play();

		//装载动画
		aGuide = books.GetComponent<Animation>();
		eGuide = adsObj.GetComponent<Animation>();
		dGuide = desk.GetComponent<Animation>();
		aChair = chair.GetComponent<Animation>();
		aCarpet = carpetActive.transform.GetComponent<Animation>();
        
	}

	//获得道具的操作
	//使用Obj绑定的Onclick()
	public void gotKnife()
	{
		knife = true;
		Router.knife1 = knife;
		textTempTIme = 0;
	}

	public void gotKey()
	{
		key = true;
		Router.key = key;
		textTempTIme = 0;
	}

	public void gotCd()
	{
		cd = true;
		Router.cd = cd;
		textTempTIme = 0;
	}

	public void gotAds()
	{
		ads = true;
		Router.ads = ads;
		textTempTIme = 0;
		if (Router.guideClear == false && _guideCount >= 9 && _guideCount <= 10 ){
			_guideCount++;
			GoodsClickInfo.mInstance.SetText("看，它在你的背包里！");
            aGuide.Stop();
			books.GetComponent<RectTransform>().localScale = new Vector2(1.0f, 1.0f);
			_guideCountTime = 0;
		}
	}

	public void gotEnvelop()
	{
		envelop = true;
		Router.envelop = envelop;
		textTempTIme = 0;
	}

	public void gotPostcard()
	{
		postcard = true;
		Router.postcard = postcard;
		textTempTIme = 0;
	}

	//点击时显示信息
    //点击书本
	public void OnBooks()
	{
		textTempTIme = 0;
		_OnBooks++;

		if (Router.guideClear == false) {
			switch (_guideCount)
			{
				case 10:
					_OnBooks = 0;
					break;
				case 11:
					_OnBooks = 1;
					break;
				case 12:
					_OnBooks = 2;
					break;
				case 13:
					_OnBooks = 3;
					break;
				case 14:
					_OnBooks = 4;
					break;
				default:
					_OnBooks = 0;
					break;
			}
		}

		int count = UnityEngine.Random.Range(1, 6);
		switch (count)
		{
			case 1:
				GoodsClickInfo.mInstance.SetText("之前我们约好要见面的。");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("你忘记你自己说的话了吗？");
				break;
			case 3:
				GoodsClickInfo.mInstance.SetText("我其实挺生气的。");
				break;
			case 4:
				GoodsClickInfo.mInstance.SetText("我们不能继续在网上聊了。");
				break;
			case 5:
				GoodsClickInfo.mInstance.SetText("读读纸质书也不错。");
				break;
			default:
				break;
		}

		if (_OnBooks == 4)
		{
			GoodsClickInfo.mInstance.SetText("我们有救了");
			adsObj.SetActive(true);
		}

		if (_OnBooks == 7)
			GoodsClickInfo.mInstance.SetText("<color=#000>你想起自己因为游戏而忘记了那天的约定。</color>");
		if (_OnBooks == 10)
			GoodsClickInfo.mInstance.SetText("<color=#000>可是你想了想，随时都能联系到对方。</color>");
		if (_OnBooks == 11)
            GoodsClickInfo.mInstance.SetText("<color=#000>放鸽子没什么大不了的。</color>");
	}

    //点击窗帘
	public void OnCurtainActive()
	{
		textTempTIme = 0;
		GoodsClickInfo.mInstance.OpenCurtain();
		GoodsClickInfo.mInstance.SetText("你一定会明白的。");
		curtainActive.SetActive(false);
	}

    //点击海报
	public void OnPoster(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
		switch(count){
			case 1:
				GoodsClickInfo.mInstance.SetText("可口可乐，挡不住的感觉！");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("你之前说划开海报的声音很好听，但我觉得不应该这么做。");
				break;
			default:
				break;	
		}
	}

    //点击桌子
	public void OnDesk(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
        switch (count)
        {
            case 1:
                GoodsClickInfo.mInstance.SetText("经常逛逛推特，说不定能买到同样的款式。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("不错的桌子。");
                break;
            default:
                break;
        }
	}

	//点击窗子
	public void OnWindow()
	{
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
		switch(count){
			case 1:
			GoodsClickInfo.mInstance.SetText("或许有一天……");
				break;
			case 2:
            GoodsClickInfo.mInstance.SetText("等你不那么喜欢玩游戏了，我们再一起出去。");
				break;
			default:
				break;
		}

	}

    //点击椅子
	public void OnChair()
	{
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
		switch(count){
			case 1:
				if(_chair < 1)
				    aChair.Play();
				GoodsClickInfo.mInstance.SetText("我们应该坐下聊聊了。");
				_chair++;
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("我是说面对面聊聊。");
				break;
			default:
				break;
		}
	}

	//点击灯
	public void OnLamp()
	{
		textTempTIme = 0;
		_lamp++;

		if (_lamp % 2 == 0)
		{
			lightOff.SetActive(false);
			GoodsClickInfo.mInstance.SetText("这盏落地灯可以照亮房间的另一边。");
		}
		else
		{
			lightOff.SetActive(true);
			GoodsClickInfo.mInstance.SetText("我们还是打开灯吧。");
		}
	}

    //点击插画
	public void OnFlame()
	{
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
        switch (count)
        {
			case 1:
                GoodsClickInfo.mInstance.SetText("从前人们说无法一个人活着。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("现代人可能不再是群居动物了。");
                break;
            default:
                break;
        } 
	}

    //点击床
	public void OnBed()
	{
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 4);
		switch (count)
        {
            case 1:
                GoodsClickInfo.mInstance.SetText("我困了……");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("很舒服，躺着玩游戏一定很棒。");
                break;
			case 3:
				GoodsClickInfo.mInstance.SetText("等等，床里似乎有什么。");
				break;
            default:
                break;
        } 
	}

    //点击柜子 未激活
	public void OnDresser(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 4);
		switch (count)
		{
			case 1:
				//播放上锁的声音
                GoodsClickInfo.mInstance.SetText("锁上了。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("里面会是什么呢？");
                break;
            case 3:
                GoodsClickInfo.mInstance.SetText("一定有别的机关。");
                break;
            default:
                break;
		}
	}

    //点击留声机
	public void OnPhono(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 3);
        switch (count)
        {
            case 1:
                //播放上锁的声音
                GoodsClickInfo.mInstance.SetText("有唱片的话可以试试。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("或许我们可以放点什么。");
                break;
            default:
                break;
        }
	}

    //点击激活后的留声机
	public void OnPhonoActive(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 4);
        switch (count)
        {
            case 1:
                //播放上锁的声音
                GoodsClickInfo.mInstance.SetText("我给你的留言。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("那时候我们老想见到对方。");
                break;
            case 3:
                GoodsClickInfo.mInstance.SetText("你至少应该给我打个电话。");
                break;
            default:
                break;
        }
	}

    //点击衣服
	public void OnCloth(){
		textTempTIme = 0;
		int count = UnityEngine.Random.Range(1, 4);
        switch (count)
        {
            case 1:
                //播放上锁的声音
                GoodsClickInfo.mInstance.SetText("可真乱。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("你的衣服？");
                break;
            case 3:
                GoodsClickInfo.mInstance.SetText("下面那是什么？");
                break;
            default:
                break;
        }
	}

    //点击地毯
	public void OnCarpet(){
		textTempTIme = 0;
		GoodsClickInfo.mInstance.SetText("你的地毯真好看！");
		carpet.SetActive(false);
		carpetActive.SetActive(true);
		aCarpet.Play();
	}

	//道具选择的操作 模板
	private void _lastScale(GameObject _object)
	{
		Debug.Log("_last");
		_object.GetComponent<RectTransform>().transform.localScale = new Vector2(1f, 1f);
	}

	private void _selectScale(GameObject _object)
	{
		Debug.Log("_select");
		_object.GetComponent<RectTransform>().transform.localScale = new Vector2(1.2f, 1.2f);
	}

	private void select_(GameObject _object)
	{
		selectingItem = _object;
		if (lastSelectItem != null)
		    _lastScale(lastSelectItem);
		lastSelectItem = selectingItem;
		tempTime = 0;
		textTempTIme = 0;
	}

	//道具选择的操作
	public void selectKnife()
	{
		_knifeSelCount++;
		select_(smallKnifeObj);
		GoodsClickInfo.mInstance.SetText("一把锋利的刀？小心点不要划到自己了。");
	}

	public void selectKey()
	{
		_keySelCount++;
		select_(smallKeyObj);
		GoodsClickInfo.mInstance.SetText("我想我知道他可以打开哪里。");
	}

	public void selectCd()
	{
		_cdSelCount++;
		select_(smallCdObj);
		GoodsClickInfo.mInstance.SetText("快，我们来听听里面有什么。");
	}

	public void selectAds()
	{
		_adsSelCount++;
		select_(smallAdsObj);
		GoodsClickInfo.mInstance.SetText("嘿，这堆信可真多。");
		if (Router.guideClear == false)
            _guideCount++;
	}

	public void selectEnvelop()
	{
		_envelopSelCount++;
		select_(smallEnvelopObj);
		GoodsClickInfo.mInstance.SetText("嗯……这个信封看着很眼熟。");
	}

	public void selectPostCard()
	{
		_postcardSelCount++;
		select_(smallPostcardObj);
		GoodsClickInfo.mInstance.SetText("当时我写的时候可紧张了。");
	}

	public void _initSelf()
	{
		_knifeSelCount = 0;
		_keySelCount = 0;
		_cdSelCount = 0;
		_adsSelCount = 0;
		_envelopSelCount = 0;
		_postcardSelCount = 0;
	}

	//处理被选择物件
	//使用失败|成功|超时之后重置
	private void selectingItem_()
	{
		if (tempTime >= limitTime)
		{
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initSelf();
		}

		if (useSuccess == true)
		{
			useSuccess = false;
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initSelf();
		}

		if (useFailed == true)
		{
			useFailed = false;
			selectingItem = nullObj;
			_lastScale(lastSelectItem);
			_initSelf();
		}

		//智障重置法1号
		if (_knifeSelCount >= 2)
		{
			useFailed = true;
		}
		if (_keySelCount >= 2)
		{
			useFailed = true;
		}
		if (_cdSelCount >= 2)
		{
			useFailed = true;
		}
		if (_adsSelCount >= 2)
		{
			useFailed = true;
		}
		if (_envelopSelCount >= 2)
		{
			useFailed = true;
		}
		if (_postcardSelCount >= 2)
		{
			useFailed = true;
		}

		_selectScale(selectingItem);
	}

	// 道具操作
	// 对自己使用 特殊动作
	public void UseOnSelf()
	{
		if (!selectingItem)
		{
			useFailed = true;
		}
	}

	// 对床使用
	public void UseOnBed()
	{
		textTempTIme = 0;
		if (selectingItem == smallKnifeObj)
		{
			Debug.Log("11111111");
			bedActive.SetActive(true);
			GoodsClickInfo.mInstance.PlayBed();
			useSuccess = true;
		}
		else
		{
			//这里就是除了设置以外的道具使用时的触发
			Debug.Log("failed");
			useFailed = true;
		}
	}

	// 对海报使用
	public void UseOnPoster()
	{
		textTempTIme = 0;
		if (selectingItem == smallKnifeObj)
		{
			Debug.Log("11111111");
			poster.SetActive(false);
			posterActive.SetActive(true);
			GoodsClickInfo.mInstance.PlayPoster();
			Router.knifeUsed = true;
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

	// 对锁眼使用
	public void UseOnKeyhole()
	{
		textTempTIme = 0;
		if (selectingItem == smallKeyObj)
		{
			keyhole.SetActive(false);
			keyholeActive.SetActive(true);
			envelopObj.SetActive(true);
			Router.keyUsed = true;
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

	// 对留声机使用
	public void UseOnPho()
	{
		textTempTIme = 0;
		if (selectingItem == smallCdObj)
		{
			phoActive.SetActive(true);
			dresser.SetActive(false);
			dresserActive.SetActive(true);
			//这里要播放音乐
			BGMAudio.Pause();
			recordAudio.PlayOneShot(recordClip);
			useSuccess = true;
		}
		else
		{
			useFailed = true;
		}
	}

    // 对桌子使用
	public void UseOnDesk()
	{
		textTempTIme = 0;
		if (selectingItem = smallAdsObj)
		{
			if (Router.guideClear == false)
			{
				_guideCount++;
				dGuide.Stop();
				desk.GetComponent<RectTransform>().localScale = new Vector2(1.0f, 1.0f);
				_guideCountTime = 0;
			}			
			useSuccess = true;
		} else {
			useFailed = true;
		}
	}

	//复盘动作
	private void ResetPosInfo()
	{
		if (Router.isLoaded == true)
		{
			if (Router.knife1 == true)
			{
				SetpropPos.mInstance.SetPos(smallKnifeObj);
				curtain.SetActive(false);
				curtainActive.SetActive(false);
				gotKnife();
			}
			if (Router.ads == true)
			{
				SetpropPos.mInstance.SetPos(smallAdsObj);
				smallAdsObj.SetActive(false);
				gotAds();
			}
			if (Router.cd == true)
			{
				SetpropPos.mInstance.SetPos(smallCdObj);
				cdObj.SetActive(false);
				gotCd();
			}
			if (Router.key == true)
			{
				SetpropPos.mInstance.SetPos(smallKeyObj);
				dresserActive2.SetActive(true);
				dresserActive.SetActive(false);
				dresser.SetActive(false);
				gotKey();
			}
			if (Router.postcard == true)
			{
				SetpropPos.mInstance.SetPos(smallPostcardObj);
				bed.SetActive(false);
				bedActive2.SetActive(true);
				bedActive.SetActive(false);
			}
			if (Router.envelop == true)
			{
				SetpropPos.mInstance.SetPos(smallEnvelopObj);
				keyhole.SetActive(false);
				keyholeActive.SetActive(true);
			}
			if (Router.keyUsed == true)
			{
				keyhole.SetActive(false);
				keyholeActive.SetActive(true);
			}
			Router.isLoaded = false;
		}
	}

	//新手教程
	private void guide() {
		_guideCountTime += Time.deltaTime;
		switch (_guideCount) {
			case 0:
				GoodsClickInfo.mInstance.SetText("<color=#146500>这是普通的一天，你从家中醒来，没有任何不对劲。</color>");
				guidePush(3f);
				break;
			case 1:
				GoodsClickInfo.mInstance.SetText("嘿，你好！");
				guidePush(3f);
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("抱歉，我可不是故意想要吓唬你。");
				guidePush(3f);
				break;
			case 3:
				GoodsClickInfo.mInstance.SetText("<color =#146500>你被突然出现的声音吓了一跳，环顾四周却找不到声源。</color>");
				guidePush(3f);
				break;
			case 4:
				GoodsClickInfo.mInstance.SetText("我不知道为什么会变成这样。");
				guidePush(3f);
				break;
			case 5:
				GoodsClickInfo.mInstance.SetText("之前我们约好了见面，但是你没有出现。");
				guidePush(3f);
				break;
			case 6:
				GoodsClickInfo.mInstance.SetText("<color=#146500>你想起那天自己因为游戏而忘记了出门。</color>");
				guidePush(3f);
				break;
			case 7:
				GoodsClickInfo.mInstance.SetText("你说反正这么久没见了，在网上聊天也是一样的。");
				guidePush(3f);
				break;
			case 8:
				GoodsClickInfo.mInstance.SetText("我很生气，再也没跟你说过话。");
				guidePush(3f);
				break;
			case 9:
				GoodsClickInfo.mInstance.SetText("不过，你现在需要了解一些事。");
				guidePush(3f);
				break;
			case 10:
				GoodsClickInfo.mInstance.SetText("点击周围可以进行调查，比如说这些书。");
				_OnBooks = 0;
				aGuide.Play();
				guidePush(3f);
				break;
			case 11:
				_OnBooks = 1;
				GoodsClickInfo.mInstance.SetText("请点它。");
				break;
			case 12:
				GoodsClickInfo.mInstance.SetText("再点它，啊，我想到了。");
				break;
			case 13:
				GoodsClickInfo.mInstance.SetText("继续，这些书是我推荐的。");
				break;
			case 14:
				GoodsClickInfo.mInstance.SetText("继续点，我想想看。");
                break;
			case 15:
			    GoodsClickInfo.mInstance.SetText("看，桌子下面多了什么！");
				break;
			case 16:
				break;
			case 17:
				GoodsClickInfo.mInstance.SetText("你可以使用它，点击下面道具栏里的它。");
				if (selectingItem == smallAdsObj) {
					GoodsClickInfo.mInstance.SetText("他被选中了，然后再点击别处，比如桌子。");
					_guideCount++;
				}
				break;
			case 18:
				dGuide.Play();
				break;
			case 19:
				GoodsClickInfo.mInstance.SetText("很简单，对吧！");
				guidePush(3f);
				break;
			case 20:
				GoodsClickInfo.mInstance.SetText("虽然什么都没有发生。");
                guidePush(3f);
				break;
			case 21:
				GoodsClickInfo.mInstance.SetText("别急，只剩一点了。");
				guidePush(3f);
				break;
			case 22:
				GoodsClickInfo.mInstance.SetText("双击背包里的道具，看看写了什么。");
				guidePush(3f);
				break;
			case 23:
				GoodsClickInfo.mInstance.SetText("你自己试试看？我相信你会做的。");
				guidePush(3f);
				break;
			case 24:
				GoodsClickInfo.mInstance.SetText("这就是你需要知道的一切。");
				guidePush(3f);
				break;
			case 25:
				GoodsClickInfo.mInstance.SetText("我们还会再见的。");
				guidePush(3f);
				break;
			case 26:
				Router.guideClear = true;
				GoodsClickInfo.mInstance.SetText(null);
				Router.mInstance.DataSave();
				_OnBooks = 5;
				break;
			default:
				break;
		}
	}

	public void guideTouch(){
		if(_guideCount <= 8 && _guideCount >= 5)
		_guideCount++;
	}

	private void guidePush(float time)
	{
		if (_guideCountTime >= time)
		{
			_guideCount++;
			_guideCountTime = 0;
		}
	}

	// Update is called once per frame
	void Update()
    {
        tempTime += Time.deltaTime;
		textTempTIme += Time.deltaTime;

		if (Router.guideClear == false)
		{
			guide();
		}

        selectingItem_();
		ResetPosInfo();

        //BGM停止后重新播放
        if (BGMAudio.isPlaying == false)
        {
            if (recordAudio.isPlaying == false)
            {
                BGMAudio.Play();
            }
        }

		if (Router.guideClear == true)
		    if (textTempTIme >= textTime){
                GoodsClickInfo.mInstance.SetText(null);
				textTempTIme = 0;
        }
    }
}