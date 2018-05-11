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

    public GameObject pngObj;
    public GameObject smallPngObj;

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
    private int error = 0;
    private int music = 0;

    //选择计数器
    public int _myCompSelCount = 0;
    public int _jpgSelCount = 0;
    public int _pngSelCount = 0;
    public int _favSelCount = 0;
    public int _dolphSelCount = 0;

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
    }

    public void gotJpg()
    {
        jpg = true;
		Router.jpg = jpg;
    }

    public void gotPng()
    {
        png = true;
		Router.png = png;
    }

    public void gotFav()
    {
        fav = true;
		Router.fav = fav;
    }

    public void gotDolph()
    {
        dolph = true;
		Router.dolph = dolph;
    }

    //道具选择的操作
    public void selectMyComp()
    {
        _myCompSelCount++;
        select_(smallMyCompObj);
    }

    public void selectPng()
    {
        _pngSelCount++;
        select_(smallPngObj);
    }

    public void selectJpg()
    {
        _jpgSelCount++;
        select_(smallJpgObj);
    }

    public void selectFav()
    {
        _favSelCount++;
        select_(smallFavObj);
    }

    public void selectDolph()
    {
        _dolphSelCount++;
        select_(smallDolphObj);
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
            useFailed = true;
        if (_pngSelCount >= 2)
            useFailed = true;
        if (_jpgSelCount >= 2)
            useFailed = true;
        if (_favSelCount >= 2)
            useFailed = true;
        if (_dolphSelCount >= 2)
            useFailed = true;

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
        }
        else
        {
            useFailed = true;
        }
    }

    //对邮筒使用
    public void UseOnMailSender(){
        if (selectingItem == smallDolphObj)
        {
            mail1.SetActive(true);
            arrowL.SetActive(false);
            arrowR.SetActive(false);
            Router.dolphUsed = true;
            useSuccess = true;
        }

        if (selectingItem == smallFavObj)
        {
            mail2.SetActive(true);
            arrowL.SetActive(false);
            arrowR.SetActive(false);
            Router.favUsed = true;
            useSuccess = true;
        } else {
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
        } else {
            useFailed = true;
        }
    }

    //对海豚使用
    public void UseOnDolph(){
        if(selectingItem == smallMyCompObj)
        {
            dolphIcon.SetActive(false);
            dolphObj.SetActive(true);
            useSuccess = true;
        }

        if(selectingItem == smallJpgObj)
        {
            pngGirl.SetActive(true);
            desktopErr.SetActive(true);
            Destroy(smallPngObj);
			Router.jpgUsed = true;
            useSuccess = true;
        }

        if(selectingItem == smallPngObj){
            gifGirl.SetActive(true);
            Destroy(smallJpgObj);
			Router.gifUsed = true;
            useSuccess = true;
        } else {
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
        } else {
            useFailed = true;
        }
    }

    //点击部分
    public void OnNotFound() {
        ErrorAudio.PlayOneShot(ErrorClip);
        winRemixCount++;

        error++;
        if (error == 1)
            GoodsClickInfo.mInstance.SetText("我不知道哪里出错了……");
        else if (error == 2)
            GoodsClickInfo.mInstance.SetText("好吧……");
        else if (error >= 3)
            GoodsClickInfo.mInstance.SetText("我继续想办法试试看！");
        Debug.Log(winRemixCount);

        if (winRemixCount > 6)
        {
            BGMAudio.Pause();
            BGMWrongAudio.Pause();
            ErrorRemixAudio.Play();
        }
    }

    public void OnMusicFile()
    {
        music++;
        if (music == 1)
            GoodsClickInfo.mInstance.SetText("让我们来试试。");
        else if (music == 2)
            GoodsClickInfo.mInstance.SetText("看来他不合你的胃口。");
        else if (music == 3)
            GoodsClickInfo.mInstance.SetText("我是说，你真的不喜欢？");
        else if (music == 4)
            GoodsClickInfo.mInstance.SetText("你最好再考虑考虑。");
        else if (music == 5)
        {
            GoodsClickInfo.mInstance.SetText("拿去！");
            BGMAudio.Pause();
            ErrorRemixAudio.Pause();
            BGMWrongAudio.Play();
        }
    }

    public void OnNotFoundButton(){
        ErrorAudio.PlayOneShot(ErrorClip);
        ErrNotFound.SetActive(false);
        NotFoundTime = 0;
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
                break;
        }
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
				SetpropPos.mInstance.SetPos(smallPngObj);
				pngObj.SetActive(false);
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
				Destroy(smallPngObj);
			}
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
	}

	// Update is called once per frame
	void Update()
	{
        tempTime += Time.deltaTime;
        NotFoundTime += Time.deltaTime;
        selectingItem_();
        if (NotFoundTime >= 7.0f)
        {
            Debug.Log(NotFoundTime);
            ErrNotFound.SetActive(true);
            ErrorAudio.PlayOneShot(ErrorClip);
            NotFoundTime = 0;
        }

        //BGM停止后重新播放
        if (BGMAudio.isPlaying == false && BGMWrongAudio.isPlaying == false && startupAudio.isPlaying == false && ErrorRemixAudio.isPlaying == false)
            BGMAudio.Play();

        if (tempTime >= textTime)
        {
            GoodsClickInfo.mInstance.SetText(null);
        }
	}
}
