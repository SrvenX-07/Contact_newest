using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections.Generic;
using LitJson;

public class Router : MonoBehaviour
{
	public static Router mInstance;

	//全局路线开关
	public static List<bool> RouterAll;

	public static bool knifeUsed;
	public static bool postCardUsed;
	public static bool envelopUsed;
	public static bool keyUsed;
	public static bool cdUsed;
	public static bool adsUsed;
	public static bool dooUsed;
	public static bool ringUsed;
	public static bool teleCardUsed;
	public static bool diaNum1st;
	public static bool diaNum2nd;
	public static bool gifUsed;
	public static bool jpgUsed;
	public static bool comUsed;
	public static bool favUsed;
	public static bool dolphUsed;
	public static bool errUsed;
	public static bool musicUsed;
	public static bool gameClear;
	public static bool guideClear;
	public static bool knife2Used;
	public static bool cameraUsed;

	public static bool isLoaded = false;

	public string SceneNum = "";

	//字幕变量
	public static Text tips;

	//智障手段路由表
	//场景1道具状态获取
	public static List<bool> Scene1ItemStatus = new List<bool>(new bool[] { true, true, true, true,true,true });
	public static bool knife1;
	public static bool key;
	public static bool cd;
	public static bool ads;
	public static bool envelop;
	public static bool postcard;

	//场景2道具状态获取
	public static List<bool> Scene2ItemStatus = new List<bool>(new bool[] { true, true, true, true, true });
	public static bool ring = false;
	public static bool card = false;
	public static bool _camera;
	public static bool photo;
	public static bool knife2 = true;

	//场景3道具状态获取
	public static List<bool> Scene3ItemStatus = new List<bool>(new bool[] { true, true, true, true, true });
	public static bool myComp = false;
	public static bool jpg = false;
	public static bool png = false;
	public static bool fav = false;
	public static bool dolph = false;

	//结局内容
	public GameObject ED1;
	public GameObject ED2;
	public GameObject ED3;
	public GameObject ED4;

	public GameObject TR1;
	public GameObject TR2;

	//结局开关
	public static bool sED1;
	public static bool sED2;
	public static bool sED3;
	public static bool sED4;

	//计时器
	private float autoSaveTime;

	//结局控制
	public void result()
	{
		if (diaNum1st)
		{
			ED2.SetActive(true);
		}

		if (diaNum2nd)
		{
			Scene2Manager.mInstance.ringBoard.SetActive(true);
			if(cameraUsed)
			{
				TR2.SetActive(true);
			} else {
				TR1.SetActive(true);
			}
		}

		if (envelopUsed && favUsed)
		{
			ED4.SetActive(true);
		}

		if (postCardUsed)
		{
			ED1.SetActive(true);
		}

		if (dolphUsed)
		{
			ED3.SetActive(true);
		}
	}

	public void output()
	{
		DataSave();
		Debug.Log(RouterAll.Count);
		//Debug.Log(RouterName.Count);
		Debug.Log(Scene2ItemStatus);
	}

	public void DataSave()
	{
		SaveData saveData = new SaveData();

		string fileName = Application.dataPath + "/Save" + "/GameData.json";
		StreamWriter streamWriter = new StreamWriter(fileName);

		//手动保存场景1的flag
		Scene1ItemStatus[0] = knife1;
		Scene1ItemStatus[1] = key;
		Scene1ItemStatus[2] = cd;
		Scene1ItemStatus[3] = ads;
		Scene1ItemStatus[4] = envelop;
		Scene1ItemStatus[5] = postcard;

		//手动保存场景2的flag
		Scene2ItemStatus[0] = ring;
		Scene2ItemStatus[1] = card;
		Scene2ItemStatus[2] = _camera;
		Scene2ItemStatus[3] = photo;
		Scene2ItemStatus[4] = knife2;

		//手动保存场景3的flag
		Scene3ItemStatus[0] = myComp;
		Scene3ItemStatus[1] = jpg;
		Scene3ItemStatus[2] = png;
		Scene3ItemStatus[3] = fav;
		Scene3ItemStatus[4] = dolph;

		//手动保存全局路线FLAG
		RouterAll = new List<bool>(new bool[] { knifeUsed, postCardUsed, envelopUsed, keyUsed, cdUsed, adsUsed, dooUsed, ringUsed, teleCardUsed, diaNum1st, diaNum2nd, gifUsed, jpgUsed, comUsed, favUsed, dolphUsed, errUsed, musicUsed, gameClear,knife2Used });

		saveData.N1 = RouterAll;
		saveData.N2 = Scene1ItemStatus;
		saveData.N3 = Scene2ItemStatus;
		saveData.N4 = Scene3ItemStatus;
		saveData.sceneNum = SceneManager.GetActiveScene().name;

		string jSaveData = JsonMapper.ToJson(saveData);
		streamWriter.Write(jSaveData);
		streamWriter.Close();
	}

	public void DataLoad()
	{
		string saveFile = Application.dataPath + "/Save" + "/GameData.json";
		StreamReader streamReader = new StreamReader(saveFile);
		string jLoadData = streamReader.ReadToEnd();
		streamReader.Close();

		SaveData loadData = new SaveData();
		loadData = JsonMapper.ToObject<SaveData>(jLoadData);

		//手动写入场景1的flag
		knife1 = loadData.N2[0];
		key = loadData.N2[1];
		cd = loadData.N2[2];
		ads = loadData.N2[3];
		envelop = loadData.N2[4];
		postcard = loadData.N2[5];
		Debug.Log("场景1FLAG");

        //手动写入场景2的flag
		ring = loadData.N3[0];
		card = loadData.N3[1];
		knife2 = loadData.N3[2];;
		Debug.Log("场景2FLAG");
		Debug.Log(ring);

        //手动写入场景3的flag
		myComp = loadData.N4[0];
		jpg = loadData.N4[1];
		png = loadData.N4[2];
		fav = loadData.N4[3];
		dolph = loadData.N4[4];
		Debug.Log("场景3FLAG");

        //手动写入路线控制FLAG
		knifeUsed = loadData.N1[0];
		postCardUsed = loadData.N1[1];
		envelopUsed = loadData.N1[2];
		keyUsed = loadData.N1[3];
		cdUsed = loadData.N1[4];
		adsUsed = loadData.N1[5];
		dooUsed = loadData.N1[6];
		ringUsed = loadData.N1[7];
		teleCardUsed = loadData.N1[8];
		diaNum1st = loadData.N1[9];
		diaNum2nd = loadData.N1[10];
		gifUsed = loadData.N1[11];
		jpgUsed = loadData.N1[12];
		comUsed = loadData.N1[13];
		favUsed = loadData.N1[14];
		dolphUsed = loadData.N1[15];
		errUsed = loadData.N1[16];
		musicUsed = loadData.N1[17];
		gameClear = loadData.N1[18];
		knife2Used = loadData.N1[19];
		Debug.Log("路线FLAG");

		SceneNum = loadData.sceneNum;

		isLoaded = true;

		loadEnd();
	}

	public void loadEnd() {
		//读取结束之后执行
		if (isLoaded == true)
		{
			SceneManager.LoadScene(SceneNum);
		}
	}

	public void SoundOff(){
		AudioListener.volume = 0;
	}

	public void SoundOn(){
		AudioListener.volume = 1;
	}

	[System.Serializable]
	public class SaveData {
		//接收Router的全局FLAG值
        public List<bool> N1;

	    //接受场景1的道具FLAG值
	    public List<bool> N2;

	    //接受场景2的道具FLAG值
	    public List<bool> N3;

	    //接受场景3的道具FLAG值
	    public List<bool> N4;

	    //接受存档时的场景编号
	    public string sceneNum;
    }

	// Use this for initialization
	void Start()
	{
		mInstance = this;
	}

	// Update is called once per frame
	void Update()
	{
		//1分钟之后自动保存数据
		autoSaveTime += Time.deltaTime;
		if(Time.deltaTime >= 120f)
		{
			if(SceneNum != "StartScene")
			    DataSave();
			autoSaveTime = 0;
			Debug.Log("auto save");
		}
			
	}
}
