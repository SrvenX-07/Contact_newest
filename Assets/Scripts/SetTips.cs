using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTips : MonoBehaviour
{
    public Text MText;
    public int music;
    public int error;
    public int dolphin;


    //public GameObject ErrorGameObject;
    //public GameObject dolphinGameObject;
    //public GameObject iconMusicGameObject;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setTips(string content)
    {
        MText.gameObject.SetActive(true);
        MText.text = content;
    }
    //public void setmusicTips()
    //{
    //    music++;
    //    if (music == 1)
    //    {
    //        MText.text = "让我们来试试。";

    //    }else if (music == 2)
    //    {
    //        MText.text = "看来他不合你的胃口。";
    //    }else if (music == 3)
    //    {
    //        MText.text = "我是说，你真的不喜欢？";
    //    }else if (music == 4)
    //    {
    //        MText.text = "你最好再考虑考虑。";
    //    }else if (music == 5)
    //    {
    //        MText.text = "拿去！";
    //        //iconMusicAudio.Play();
    //    }

    //}

    //public void SetError()
    //{
    //    error++;
    //    if (error == 1)
    //    {
    //    //audio.PlayOneShot(clip);
    //        MText.text = "我不知道哪里出错了……";
    //    }else if (error == 2)
    //    {
    //        //audio.PlayOneShot(clip);
    //        MText.text = "好吧……";
    //    }else if (error >= 3)
    //    {
    //        //audio.PlayOneShot(clip);
    //    }
    //}

    //public void Seticondolphin()
    //{
    //    dolphin++;
    //    if (dolphin == 1)
    //    {
    //        //audiodolphin.PlayOneShot(clipdolphin);
    //        MText.text = "你好，我是只普通的海海豚。";
    //    }
    //   else if (dolphin == 2)
    //    {
    //        MText.text = "你遇到麻烦了？我想我能帮你。";
    //    }
    //    else if (dolphin == 3)
    //    {
    //        MText.text = "但是在帮你前，我想见到我的小伙伴。";
    //    }
    //    else if (dolphin == 4)
    //    {
    //        MText.text = "她就在不远的地方，是个无害的石头小姑娘。";
    //    }

    //}
}
