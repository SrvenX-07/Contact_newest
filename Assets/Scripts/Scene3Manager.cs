using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3Manager : MonoBehaviour
{
    //道具obj钩子
    public GameObject myCompObj;
    public GameObject smallMyCompObj;

    public GameObject jpgObj;
    public GameObject smallJpgObj;

    public GameObject gifObj;
	public GameObject smallGifObj;

    public GameObject favObj;
    public GameObject smallFavObj;

    public GameObject dolphObj;
    public GameObject smallDolphObj;

    //场景obj钩子
    public GameObject helper;
    public GameObject folder;
    public GameObject folerClose;
    public GameObject musicFile;
    public GameObject ErrNotFound;
	public GameObject ErrClone;
    public GameObject mailSender;

    public GameObject gifGirl;
    public GameObject pngGirl;
    public GameObject desktopErr;
    public GameObject dolphIcon;

    public GameObject mail1;
    public GameObject mail2;

    public GameObject arrowL;
    public GameObject arrowR;
	public GameObject Scene2;

	public GameObject ED1;
	public GameObject ED3;
	public GameObject ED4;
	public GameObject Setting;

    //道具获得状态
    public bool myComp = false;
    public bool jpg = false;
    public bool png = false;
    public bool fav = false;
    public bool dolph = false;
    public GameObject nullObj;

    //音频钩子
    //因为setTips几乎功能全灭
    //这边重新获取
    public GameObject BGM;
    AudioSource BGMAudio;
    AudioClip BGMClip;

    AudioSource BGMWrongAudio;
    AudioClip BGMWrongClip;

    AudioSource ErrorRemixAudio;
    AudioClip ErrorRemixClip;

    AudioSource ErrorAudio;
    AudioClip ErrorClip;

    AudioSource shutdownAudio;
    AudioClip shutdownClip;

    AudioSource dolphAudio;
    AudioClip dolphClip;

    public GameObject startup;
    AudioSource startupAudio;
    AudioClip startupClip;

    //计数器
    private int winRemixCount = 0;
    public float NotFoundTime = 0;
    private int dolphin = 0;
	private int _gifG;
    private int error = 0;
    private int music = 0;
	private float tempTextTime;

    //选择计数器
    public int _myCompSelCount;
    public int _jpgSelCount;
    public int _pngSelCount;
    public int _favSelCount;
    public int _dolphSelCount;

    //中继
    public GameObject selectingItem;
    public GameObject lastSelectItem;
	public GameObject lastLastSelectItem;
    public bool useSuccess = false;
    public bool useFailed = false;

    public float limitTime = 10f;
    public float textTime = 20f;
    public float startTime;
    public float endTime;
    public float tempTime;

    //选择道具时的操作 模板
    private void _lastScale(GameObject _object)
    {
        _object.GetComponent<RectTransform>().transform.localScale = new Vector2(1f, 1f);
		if (_object != nullObj)
            _object.transform.parent.GetChild(0).gameObject.SetActive(false);
    }

    private void _selectScale(GameObject _object)
    {
        _object.GetComponent<RectTransform>().transform.localScale = new Vector2(1.2f, 1.2f);
		if (_object != nullObj)
			_object.transform.parent.GetChild(0).gameObject.SetActive(true);
    }

    private void select_(GameObject _object)
    {
        selectingItem = _object;
        if (lastSelectItem != null)
            _lastScale(lastSelectItem);
        lastSelectItem = selectingItem;
        tempTime = 0;
		tempTextTime = 0;
		if (lastLastSelectItem == lastSelectItem == selectingItem)
			_lastScale(_object);
		lastLastSelectItem = lastSelectItem;
    }

    private int _initSelf(int count)
    {
        if (count >= 2)
        {
            useFailed = true;
            count = 0;
        }
        return count;
    }

    private void _initCount()
    {
        _myCompSelCount = 0;
        _jpgSelCount = 0;
        _pngSelCount = 0;
        _favSelCount = 0;
        _dolphSelCount = 0;
    }

    //获得道具时的操作
    //主要用来检查和备用
    public void gotMyComp()
    {
		myComp = true;
		Router.myComp = myComp;
		tempTextTime = 0;
    }

    public void gotJpg()
    {
        jpg = true;
		Router.jpg = jpg;
		tempTextTime = 0;
    }

    public void gotPng()
    {
        png = true;
		Router.png = png;
		tempTextTime = 0;
    }

    public void gotFav()
    {
        fav = true;
		Router.fav = fav;
		tempTextTime = 0;
    }

    public void gotDolph()
    {
        dolph = true;
		Router.dolph = dolph;
		tempTextTime = 0;
    }

    //道具选择的操作
    public void selectMyComp()
    {
        _myCompSelCount++;
        select_(smallMyCompObj);
		GoodsClickInfo.mInstance.SetText("全都是隐私，我得小心点。");
        //智障重置法2号机
        _jpgSelCount = 0;
        _pngSelCount = 0;
        _favSelCount = 0;
        _dolphSelCount = 0;
    }

    public void selectPng()
    {
        _pngSelCount++;
        select_(smallGifObj);
		GoodsClickInfo.mInstance.SetText("这是海豚的小姑娘吗？");
		_myCompSelCount = 0;
        _jpgSelCount = 0;
        _favSelCount = 0;
        _dolphSelCount = 0;
    }

    public void selectJpg()
    {
        _jpgSelCount++;
        select_(smallJpgObj);
		GoodsClickInfo.mInstance.SetText("这是海豚的小姑娘吗？");
		_myCompSelCount = 0;
        _pngSelCount = 0;
        _favSelCount = 0;
        _dolphSelCount = 0;
    }

    public void selectFav()
    {
        _favSelCount++;
        select_(smallFavObj);
		GoodsClickInfo.mInstance.SetText("不知道艾米会不会喜欢这颗星星。");
		_myCompSelCount = 0;
        _jpgSelCount = 0;
        _pngSelCount = 0;
        _dolphSelCount = 0;
    }

    public void selectDolph()
    {
        _dolphSelCount++;
        select_(smallDolphObj);
		GoodsClickInfo.mInstance.SetText("他说他会帮我解决问题。");
		_myCompSelCount = 0;
        _jpgSelCount = 0;
        _pngSelCount = 0;
        _favSelCount = 0;
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
		if (_myCompSelCount >= 2)
        {
            useFailed = true;
        }
		if (_pngSelCount >= 2)
        {
            useFailed = true;
        }
		if (_jpgSelCount >= 2)
        {
            useFailed = true;
        }
		if (_favSelCount >= 2)
        {
            useFailed = true;
        }
		if (_dolphSelCount >= 2)
        {
            useFailed = true;
        }

        _selectScale(selectingItem);
    }

    //对404错误使用
    public void UseOnErro()
    {
        if (selectingItem == smallDolphObj)
        {
            Destroy(ErrNotFound);
            //播放声音
            useSuccess = true;
			tempTextTime = 0;
        }
        else
        {
            useFailed = true;
        }
    }

	//对邮筒使用
	public void UseOnMailSender()
	{
		if (Router.comUsed)
		{
			if (selectingItem == smallDolphObj)
			{
				mail1.SetActive(true);
				arrowL.SetActive(false);
				arrowR.SetActive(false);
				Router.dolphUsed = true;
				GoodsClickInfo.mInstance.SetText("再见，谢谢您的慷慨和隐私！");
				useSuccess = true;
				tempTextTime = 0;
			}
			else
			{
				useFailed = true;
			}

			if (selectingItem == smallFavObj)
			{
				mail2.SetActive(true);
				arrowL.SetActive(false);
				arrowR.SetActive(false);
				Router.favUsed = true;
				useSuccess = true;
				tempTextTime = 0;
			}
			else
			{
				useFailed = true;
			}
		} else if (selectingItem != nullObj){
			GoodsClickInfo.mInstance.SetText("你不知道该往邮件里写些什么。");
			useFailed = true;
		}
	}

    //对音乐文件使用
    public void UseOnMusicFile(){
        if(selectingItem == smallDolphObj)
        {
            Destroy(musicFile);
            BGMWrongAudio.Pause();
            useSuccess = true;
			tempTextTime = 0;
        } else {
            useFailed = true;
        }
    }

    //对海豚使用
    public void UseOnDolph(){
		if (Router.gifUsed || Router.jpgUsed)
		{
			if (selectingItem == smallMyCompObj)
			{
				dolphIcon.SetActive(false);
				dolphObj.SetActive(true);
				GoodsClickInfo.mInstance.SetText("您可真是位绅士，我会尽我所能的帮助您，带我走吧。");
				Router.comUsed = true;
				useSuccess = true;
				tempTextTime = 0;
			} else if (selectingItem != nullObj){
				GoodsClickInfo.mInstance.SetText("哦，我暂时不需要它。");
				useFailed = true;
				tempTextTime = 0;
			}
		} else if (selectingItem != nullObj) {
			useFailed = true;
			GoodsClickInfo.mInstance.SetText("哦，我暂时不需要它。");
			tempTextTime = 0;
		}

        if(selectingItem == smallJpgObj)
        {
            pngGirl.SetActive(true);
            desktopErr.SetActive(true);
			smallJpgObj.SetActive(false);
			Router.jpgUsed = true;
			GoodsClickInfo.mInstance.SetText("好久不见！");
            useSuccess = true;
			tempTextTime = 0;
		} else if (selectingItem != nullObj) {
            useFailed = true;
        }

        if(selectingItem == smallGifObj){
            gifGirl.SetActive(true);
			GoodsClickInfo.mInstance.SetText("真是位美丽的姑娘。");
			smallGifObj.SetActive(false);
			Router.gifUsed = true;
            useSuccess = true;
			tempTextTime = 0;
		} else if (selectingItem != nullObj) {
            useFailed = true;
        }
    }

    //对404使用
    public void UseOn404Error(){
        if(selectingItem == smallDolphObj){
            Destroy(ErrNotFound);
            Destroy(ErrorAudio);
            Destroy(ErrorClip);
            GoodsClickInfo.mInstance.SetText("我会帮助你！");
            useSuccess = true;
			tempTextTime = 0;
		} else if (selectingItem != nullObj) {
            useFailed = true;
        }
    }

    //点击部分
    public void OnNotFound() {
        ErrorAudio.PlayOneShot(ErrorClip);
        winRemixCount++;
		float x = Random.Range(480, 1440);
		float y = Random.Range(270, 810);
        
		Instantiate(ErrClone,new Vector2(x,y),Quaternion.identity,ErrNotFound.transform);

        error++;
        if (error == 1)
            GoodsClickInfo.mInstance.SetText("你不知道哪里出错了。");
        else if (error == 2)
            GoodsClickInfo.mInstance.SetText("好吧。");
        else if (error >= 3)
            GoodsClickInfo.mInstance.SetText("你变得更加心烦了。");
        Debug.Log(winRemixCount);

        if (winRemixCount > 6)
        {
            BGMAudio.Pause();
            BGMWrongAudio.Pause();
            ErrorRemixAudio.Play();
        }

		if(Router.dolph)
			GoodsClickInfo.mInstance.SetText("可真烦人不是吗？不过我会帮您的。");

		tempTextTime = 0;
    }

    public void OnMusicFile()
    {
        music++;
        if (music == 1)
            GoodsClickInfo.mInstance.SetText("让我们来试试。");
        else if (music == 2)
            GoodsClickInfo.mInstance.SetText("看来它不合你的胃口。");
        else if (music == 3)
            GoodsClickInfo.mInstance.SetText("我是说，你真的不喜欢？");
        else if (music == 4)
            GoodsClickInfo.mInstance.SetText("再考虑一下吧。");
        else if (music == 5)
        {
            GoodsClickInfo.mInstance.SetText("好吧好吧，我投降。");
            BGMAudio.Pause();
            ErrorRemixAudio.Pause();
            BGMWrongAudio.Play();
        }

		if (Router.dolph)
            GoodsClickInfo.mInstance.SetText("来为派对预热一下吧！");

		tempTextTime = 0;
    }

    public void OnNotFoundButton(){
        ErrorAudio.PlayOneShot(ErrorClip);
        ErrNotFound.SetActive(false);
        NotFoundTime = 0;

		tempTextTime = 0;
    }

    public void OnDolphin()
    {
        dolphin++;
        switch (dolphin)
        {
            case 1:
                dolphAudio.PlayOneShot(dolphClip);
                GoodsClickInfo.mInstance.SetText("你好，我是只普通的海海豚。");
                break;
            case 2:
                GoodsClickInfo.mInstance.SetText("你遇到麻烦了？我想我能帮你。");
                break;
            case 3:
                GoodsClickInfo.mInstance.SetText("但是在帮你前，我想见到我的小伙伴。");
                break;
            case 4:
                GoodsClickInfo.mInstance.SetText("她就在不远的地方，是个无害的石头小姑娘。");
                break;
            default:
				GoodsClickInfo.mInstance.SetText("您找到她了吗？");
                break;
        }

		if (Router.gifUsed)
			OnGifGirl();

		if (Router.jpgUsed)
			OnJpgGirl();
		
		tempTextTime = 0;
			
    }

	public void OnMailSender(){
		tempTextTime = 0;
		GoodsClickInfo.mInstance.SetText("就像电子版的邮筒。");
		int index = Random.Range(1, 4);
		switch (index) {
			case 1:
				GoodsClickInfo.mInstance.SetText("或许可以通过写邮件联系她。");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("你不知道该往邮件里写些什么。");
				break;
			default:
				break;
		}

		if (Router.dolph)
			GoodsClickInfo.mInstance.SetText("噢，这就是您烦恼的根源吧，让我来帮你写。");
		tempTextTime = 0;
	}
    
	public void OnJpgGirl(){
		_gifG++;
		switch(_gifG){
			case 1:
				GoodsClickInfo.mInstance.SetText("Let’s party!");
				break;
			case 2:
				GoodsClickInfo.mInstance.SetText("噢不，我还得先帮助你吧，这位慷慨的人。");
                break;
			case 3:
				GoodsClickInfo.mInstance.SetText("我很想亲自报答您的恩情，但我需要多了解您一点。");
                break;
			case 4:
				GoodsClickInfo.mInstance.SetText("您知道，这不是为了窃取什么隐私，只是为了互相了解。");
                break;
			case 5:
				GoodsClickInfo.mInstance.SetText("我已经十足相信您是正派人士了，只是还需要再一点的信息。");
                break;
			case 6:
				GoodsClickInfo.mInstance.SetText("我需要存放有文件的电脑来得到信息。");
                break;
			default:
				GoodsClickInfo.mInstance.SetText("您可以再找一找电脑，交给我。");
				break;
		}

	}

	public void OnGifGirl(){
		GoodsClickInfo.mInstance.SetText("但这是谁？");
	}

    //复盘动作
	private void ResetPosInfo()
    {
        if (Router.isLoaded == true)
        {
			if (Router.myComp)
            {
				SetpropPos.mInstance.SetPos(smallMyCompObj);
				myCompObj.SetActive(false);
				gotMyComp();
            }
			if (Router.fav)
            {
				SetpropPos.mInstance.SetPos(smallFavObj);
				favObj.SetActive(false);
				gotFav();
            }
			if (Router.png)
			{
				SetpropPos.mInstance.SetPos(smallGifObj);
				gifObj.SetActive(false);
				gotPng();
			}
			if (Router.jpg)
			{
				SetpropPos.mInstance.SetPos(smallJpgObj);
				jpgObj.SetActive(false);
				gotJpg();
			}
			if (Router.dolph)
			{
				SetpropPos.mInstance.SetPos(smallDolphObj);
				arrowR.SetActive(false);
				arrowL.SetActive(true);
				Scene2.SetActive(true);
				dolphIcon.SetActive(false);
			}
			if (Router.gifUsed)
			{
				gifGirl.SetActive(true);
				Destroy(smallJpgObj);
			}

			if (Router.jpgUsed)
			{
				pngGirl.SetActive(true);
				desktopErr.SetActive(true);
				Destroy(smallGifObj);
			}

			Router.forGame = false;
            Router.isLoaded = false;
        }
    }

	// Use this for initialization
	void Start()
	{
        startupAudio = startup.GetComponent<AudioSource>();
        startupClip = startup.GetComponent<AudioSource>().clip;

        BGMAudio = BGM.GetComponent<AudioSource>();
        BGMClip = BGM.GetComponent<AudioSource>().clip;

        BGMWrongAudio = musicFile.GetComponent<AudioSource>();
        BGMWrongClip = musicFile.GetComponent<AudioSource>().clip;

        ErrorAudio = folerClose.GetComponent<AudioSource>();
        ErrorClip = folerClose.GetComponent<AudioSource>().clip;

        ErrorRemixAudio = ErrNotFound.GetComponent<AudioSource>();
        ErrorRemixClip = ErrNotFound.GetComponent<AudioSource>().clip;

        dolphAudio = dolphIcon.transform.GetComponent<AudioSource>();
        dolphClip = dolphIcon.transform.GetComponent<AudioSource>().clip;

        startupAudio.PlayOneShot(startupClip);

		Router.ED1 = ED1;
		Router.ED3 = ED3;
		Router.ED4 = ED4;
		Router.GameSetting = Setting;
	}

	// Update is called once per frame
	void Update()
	{
        tempTime += Time.deltaTime;
        NotFoundTime += Time.deltaTime;
		tempTextTime += Time.deltaTime;

        selectingItem_();
        if (NotFoundTime >= 7.0f)
        {
            ErrNotFound.SetActive(true);
			if(ErrNotFound.activeSelf == false)
                ErrorAudio.PlayOneShot(ErrorClip);
            NotFoundTime = 0;
        }

		if (tempTextTime >= textTime)
        {
            GoodsClickInfo.mInstance.SetText(null);
			tempTextTime = 0;
        }

		if (Router.forGame)
			ResetPosInfo();

        //BGM停止后重新播放
        if (BGMAudio.isPlaying == false && BGMWrongAudio.isPlaying == false && startupAudio.isPlaying == false && ErrorRemixAudio.isPlaying == false)
            BGMAudio.Play();

		if (tempTextTime >= textTime)
        {
            GoodsClickInfo.mInstance.SetText(null);
			tempTextTime = 0;
        }

		Destroy(GameObject.Find("error(clone)"), 5f);
			
	}

	public void OnSetting()
    {
        Router.mInstance.OnSetting();
    }

    public void result()
    {
        Router.mInstance.result();
    }

	public void DataSave(){
		Router.mInstance.DataSave();
	}

	public void SoundOn()
    {
        Router.mInstance.SoundOn();
    }
    public void SoundOff()
    {
        Router.mInstance.SoundOff();
    }
}
