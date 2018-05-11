using UnityEngine;
using System.Collections;

public class RouterInitia : MonoBehaviour
{
	Router router = new Router();
    public void RouterInit()
    {
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

		Router.guideClear = false;
		router.DataSave();
    }
}