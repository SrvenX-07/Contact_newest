using UnityEngine;
using System.IO;
using System.Collections;

public class RouterInitia : MonoBehaviour
{
	public static RouterInitia mInstance;
    public void RouterInit()
    {
		//多周目保证博物馆内CG和收集正常
		//做收集系统的FLAG还不够
        
		Router.mInstance.DataLoad();

        Router.knifeUsed = false;
        Router.postCardUsed = false;
        Router.envelopUsed = false;
        Router.keyUsed = false;
        Router.cdUsed = false;
        Router.adsUsed = false;
        Router.dooUsed = false;
        Router.ringUsed = false;
        Router.teleCardUsed = false;
        Router.diaNum1st = false;
        Router.diaNum2nd = false;
        Router.gifUsed = false;
        Router.jpgUsed = false;
        Router.comUsed = false;
        Router.favUsed = false;
        Router.dolphUsed = false;
        Router.errUsed = false;
        Router.musicUsed = false;
		Router.knife2Used = false;
		Router.cameraUsed = false;
        
        //场景1道具状态重置
		Router.knife1 = false;
		Router.key = false;
		Router.cd = false;
		Router.ads = false;
		Router.envelop = false;
		Router.postcard = false;

        //场景2道具状态重置
        Router.ring = false;
        Router.card = false;
		Router._camera = false;
		Router.photo = false;
        Router.knife2 = true;

		//场景3道具状态重置
		Router.myComp = false;
		Router.jpg = false;
        Router.png = false;
        Router.fav = false;
        Router.dolph = false;

		//gameClear 状态
		Router.gameClear = false;
		Router.guideClear = false;

		if (Router.gameClearTimes >= 1)
			Router.guideClear = true;
        
        //清空游戏主体内容进度
		Router.mInstance.DataSave();
    }
}