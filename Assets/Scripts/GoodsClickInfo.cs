using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoodsClickInfo : MonoBehaviour
{

    public  List<string> info=new List<string>(); 
    public Text TipsText;
    public int desknum;
    public int phonographNum;
    public int phonebokkNum;

    public Button CurtainButton;
    public Button TwiButton;
    public Button CDButton;
    public Button DresserButton;
    public Button KeyButton;
    public Button RoadButton;

    public Button bedButton;
    public Button PosterButton;

	public Component outline;

	public int curtain = 0;

    //场景1声音
    AudioSource audiocurtain;
    AudioClip clipCurtain;
    AudioSource audioTwi;
    AudioClip clipTwi;
    AudioSource audioCD;
    AudioClip clipCD;
    AudioSource audiokey;
    AudioClip clipkey;
    AudioSource audioBed;
    AudioClip clipBed;
    AudioSource audioPoster;
    AudioClip clipPoster;
    AudioSource audioDresser;
    AudioClip clipDresser;

    //场景2声音
    AudioSource audioRoad;
    AudioClip clipRoad;
    public static GoodsClickInfo mInstance;
    // Use this for initialization
    void Start ()
    {
        mInstance = this;
        if (PosterButton != null)
        {
            audioPoster= PosterButton.GetComponent<AudioSource>();
            clipPoster= PosterButton.GetComponent<AudioSource>().clip;
        }
        if (bedButton != null)
        {
            audioBed = bedButton.GetComponent<AudioSource>();
            clipBed = bedButton.GetComponent<AudioSource>().clip;
        }

        if (CurtainButton != null)
        {
            audiocurtain = CurtainButton.GetComponent<AudioSource>();
            clipCurtain = CurtainButton.GetComponent<AudioSource>().clip;
        }
        if (TwiButton != null)
        {
            audioTwi = TwiButton.GetComponent<AudioSource>();
            clipTwi = TwiButton.GetComponent<AudioSource>().clip;
        }
        if (CDButton != null)
        {
            audioCD = CDButton.GetComponent<AudioSource>();
            clipCD = CDButton.GetComponent<AudioSource>().clip;
        }
        if (DresserButton != null)
        {
            audioDresser = DresserButton.GetComponent<AudioSource>();
            clipDresser = DresserButton.GetComponent<AudioSource>().clip;
        }
        if (KeyButton != null)
        {
            audiokey = KeyButton.GetComponent<AudioSource>();
            clipkey = KeyButton.GetComponent<AudioSource>().clip;
        }
        if (RoadButton != null)
        {
            Debug.Log("road enter");
            audioRoad =RoadButton.GetComponent<AudioSource>();
            clipRoad = RoadButton.GetComponent<AudioSource>().clip;
        }
    }

    // Update is called once per frame
    void Update () {	
	}

    public void PlayPoster()
    {
     audioPoster.PlayOneShot(clipPoster);   
    }

    public void PlayBed()
    {
        audioBed.PlayOneShot(clipBed);
    }

    public void OnPhoneBook()
    {
        phonebokkNum++;
        if (phonebokkNum == 1)
        {
            TipsText.text = "你有想要联系的人吗？";
        }
        else if (phonebokkNum == 2)
        {
            TipsText.text = "我不知道才来问的。";
        }
    }

    public void tele()
    {
        int index = Random.Range(0, 3);
        Debug.Log("index"+index);
        if (index == 0)
        {
            TipsText.text = "我想我们需要一个进去的方法。";
        }
        else if (index == 1)
        {
            TipsText.text = "外面有点冷，不是吗？";
        }
        else if (index == 2)
        {
			TipsText.text = "打不开，难道进个公用电话亭也需要暗号吗？";
        }
    }

    public void OnRoad()
    {
        Debug.Log(clipRoad.name);
        audioRoad.PlayOneShot(clipRoad);
		TipsText.text = "这感觉真像一场梦。";
    }

    public void OnKey()
    {
        audiokey.PlayOneShot(clipkey);
        TipsText.text = "噢，是⼀把钥匙，会打开哪⾥呢？";
    }

    public void SetText(string content)
    {
        TipsText.text = content;
    }

    public void OnCD()
    {
        audioCD.PlayOneShot(clipCD);
        TipsText.text = "你竟然发现了它！";
    }

    public void Onphonograph()
    {
        phonographNum++;
        if (phonographNum == 1)
        {
            TipsText.text = "你有唱片的话可以试试。";
        }
        else if (phonographNum == 2)
        {
            TipsText.text = "或许我们应该放点什么？";
        }
    }

    public void OnTwi()
    {
		int count = Random.Range(1, 4);
		switch (count){
			case 1:
				SetText("你总是不回复我给你的转发。");
				break;
			case 2:
				audioTwi.PlayOneShot(clipTwi);
				SetText("啾啾~");
				break;
			case 3:
				audioTwi.PlayOneShot(clipTwi);
				SetText("见面与网聊不同，你什么时候才会明白？");
				break;
			default:
				break;
		}
    }

    public void OpenCurtain()
    {
		curtain++;
        audiocurtain.PlayOneShot(clipCurtain);
		Scene1Item.mInstance.curtainActive.SetActive(true);
		if (curtain <= 1)
		{
			TipsText.text = "刚刚有什么东西掉下来了？";
			Scene1Item.mInstance.knifeObj.SetActive(true);
			Scene1Item.mInstance.aKnife_();
		} else {
			TipsText.text = "我不明白外面为什么灰蒙蒙的。";
		}
        
    }
}
