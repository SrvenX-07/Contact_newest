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
	public static bool knife2Used;
	public static bool cameraUsed;
	public static bool photoUsed;

	//读取目的开关
	public static bool isLoaded;
	public static bool forGame;
	public static bool forHistory;
	public static bool forStart;
	public static bool loadFaild;
	public static bool isOnly;

	public static string SceneNum = "";

	//字幕变量
	public static Text tips;

	//智障手段路由表
	//场景1道具状态获取
	public static List<bool> Scene1ItemStatus = new List<bool>(new bool[] { true, true, true, true, true, true });
	public static bool knife1;
	public static bool key;
	public static bool cd;
	public static bool ads;
	public static bool envelop;
	public static bool postcard;

	//场景2道具状态获取
	public static List<bool> Scene2ItemStatus = new List<bool>(new bool[] { true, true, true, true, true });
	public static bool ring;
	public static bool card;
	public static bool _camera;
	public static bool photo;
	public static bool knife2 = true;

	//场景3道具状态获取
	public static List<bool> Scene3ItemStatus = new List<bool>(new bool[] { true, true, true, true, true });
	public static bool myComp;
	public static bool jpg;
	public static bool png;
	public static bool fav;
	public static bool dolph;

	//结局内容
	public static GameObject ED1;
	public static GameObject ED2;
	public static GameObject ED3;
	public static GameObject ED4;
	public static GameObject ED5;
    
	public static GameObject TR1;
	public static GameObject TR2;
	public GameObject TR3;
	public GameObject TR4;

	//标题界面用
	public static GameObject LoadingButton;
	public static GameObject GameSetting;
	public static GameObject SE;
	private int _settingCount;
    
	public static Animation SettingFadeIn;
	AnimationClip SettingFadeOut;

	AudioSource SESource;


	//结局开关
	public static List<bool> EndingStatus = new List<bool>(new bool[] { true, true, true, true, true, true, true });
	public static bool sED1;
	public static bool sED2;
	public static bool sED3;
	public static bool sED4;
	public static bool sED5;
	public static bool gameClear;
	public static bool guideClear;
	public static int gameClearTimes;
	public static bool isFirstTime;

	//系统
	public static bool isSaving;

	//计时器
	private float autoSaveTime;

	//存档位置
	public static string saveFile;
	public static string savePath;

	//结局控制
	public void result()
	{      
		Debug.Log("cameraUsed" + Router.cameraUsed);
		Debug.Log("favUsed" + Router.favUsed);
		Debug.Log("envelopUsed" + Router.envelopUsed);
		if (SceneManager.GetActiveScene().name == "2-1")
		{
			if (diaNum1st)
			{
				ED2.SetActive(true);
				sED2 = true;
			}

			if (diaNum2nd)
			{
				if (cameraUsed)
				{
					TR2.SetActive(true);
				}
				else
				{
					TR1.SetActive(true);
				}
			}
		}

		if (SceneManager.GetActiveScene().name == "3-1")
		{
			if (envelopUsed)
			{
				ED1.SetActive(true);
				sED1 = true;
			}

			if (dolphUsed)
            {
                ED3.SetActive(true);
                sED3 = true;
            }

			if (postCardUsed)
			{
				if (favUsed)
					if (cameraUsed)
					{
						//ED5.SetActive(true);
					    SceneLoading.mInstance.LoadNewSceneWithName("TrueEnding");
						sED5 = true;
					}
					else
					{
						ED4.SetActive(true);
						sED4 = true;
					}
			}
		}
		DataSave();
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

		Debug.Log("Start Saving.");
		isSaving = true;

		SaveData saveData = new SaveData();

		StreamWriter streamWriter = new StreamWriter(saveFile);

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
		RouterAll = new List<bool>(new bool[] { knifeUsed, postCardUsed, envelopUsed, keyUsed, cdUsed, adsUsed, dooUsed, ringUsed, teleCardUsed, diaNum1st, diaNum2nd, gifUsed, jpgUsed, comUsed, favUsed, dolphUsed, errUsed, musicUsed, knife2Used });

		//手动保存结局与教程FLAG
		EndingStatus[0] = sED1;
		EndingStatus[1] = sED2;
		EndingStatus[2] = sED3;
		EndingStatus[3] = sED4;
		EndingStatus[4] = sED5;
		EndingStatus[5] = gameClear;
		EndingStatus[6] = guideClear;

		//将存档放入存档数据结构中
		saveData.N1 = RouterAll;
		saveData.N2 = Scene1ItemStatus;
		saveData.N3 = Scene2ItemStatus;
		saveData.N4 = Scene3ItemStatus;
		saveData.N5 = EndingStatus;
		saveData.sceneNum = SceneManager.GetActiveScene().name;
		if (SceneManager.GetActiveScene().name == "TrueEnding")
			saveData.sceneNum = "StartScene";
		saveData.gameClearTimes = gameClearTimes;

		//写入
		string jSaveData = JsonMapper.ToJson(saveData);
		streamWriter.Write(jSaveData);
		streamWriter.Close();

		Debug.Log("Saved.");
		isSaving = false;
	}

	public void DataLoad()
	{
		StreamReader streamReader = new StreamReader(saveFile);
		string jLoadData = streamReader.ReadToEnd();
		streamReader.Close();

		SaveData loadData = new SaveData();
		loadData = JsonMapper.ToObject<SaveData>(jLoadData);

		if (loadData == null)
		{
			Debug.Log("Load Faild");

		}

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
		_camera = loadData.N3[2];
		photo = loadData.N3[3];
		knife2 = loadData.N3[4];
		Debug.Log("场景2FLAG");
		//Debug.Log(ring);

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
		knife2Used = loadData.N1[18];
		Debug.Log("路线FLAG");

		sED1 = loadData.N5[0];
		sED2 = loadData.N5[1];
		sED3 = loadData.N5[2];
		sED4 = loadData.N5[3];
		sED5 = loadData.N5[4];
		gameClear = loadData.N5[5];
		guideClear = loadData.N5[6];
		Debug.Log("结局FLAG");

		SceneNum = loadData.sceneNum;

		gameClearTimes = loadData.gameClearTimes;

		isFirstTime = loadData.isFirstTime;

		isLoaded = true;

		LoadEnd();
	}

	private void LoadEnd()
	{
		//读取结束之后执行
		if (isLoaded == true)
		{
			if (forGame)
			{
				SceneLoading.mInstance.LoadNewScene();
			}
			else if(forHistory) 
			{
				if (SceneManager.GetActiveScene().name == "StartScene")
				    history.mInstance.forHistory();
			} else if(forStart)
			{
				forStart = false;
			}


		}
	}

	public void PlaySound(AudioClip clip)
    {
		SESource.PlayOneShot(clip);
    }

	public void loadForContinue()
	{
		forGame = true;
		DataLoad();
	}

	public void loadForHistory()
	{
		forHistory = true;
		DataLoad();
	}

	public void SoundOff()
	{
		AudioListener.volume = 0;
	}

	public void SoundOn()
	{
		AudioListener.volume = 1;
	}

	[System.Serializable]
	public class SaveData
	{
		//接收Router的全局FLAG值
		public List<bool> N1;

		//接受场景1的道具FLAG值
		public List<bool> N2;

		//接受场景2的道具FLAG值
		public List<bool> N3;

		//接受场景3的道具FLAG值
		public List<bool> N4;

		//接受结局和教程的FLAG值
		public List<bool> N5;

		//接受存档时的场景编号
		public string sceneNum;

		public int gameClearTimes;

		public bool isFirstTime;
	}
    
	public void OnSetting(){
		_settingCount++;
		if (_settingCount >= 2)
		{
			SettingFadeIn["setting"].speed = -1f;
			SettingFadeIn["setting"].time = SettingFadeIn["setting"].length;
			SettingFadeIn.Play();
			_settingCount = 0;
		}
		else
		{
			SettingFadeIn["setting"].speed = 1f;
			SettingFadeIn["setting"].time = 0;
			SettingFadeIn.Play();
		}

	}

	// Use this for initialization
	void Start()
	{
		Globe.nextSceneName = "StartScene";
		SceneManager.LoadScene("loading");

		mInstance = this;
		DontDestroyOnLoad(this);

		saveFile = Application.persistentDataPath + "/Save" + "/GameData.json";
		savePath = Application.persistentDataPath + "/Save";

		if (!Directory.Exists(savePath))
		{
			isSaving = true;
			Directory.CreateDirectory(savePath);
			if (!File.Exists(saveFile))
			{
				File.CreateText(saveFile);
				isFirstTime = true;
			}
		} else {
			DataLoad();
		}

		if (SceneManager.GetActiveScene().name != "StartScene" && SceneManager.GetActiveScene().name != "HQ")
		    SettingFadeIn = GameSetting.GetComponent<Animation>();

		if (SceneManager.GetActiveScene().name != "StartScene" && SceneManager.GetActiveScene().name != "HQ")
		    SESource = SE.GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update()
	{
		//1分钟之后自动保存数据
		autoSaveTime += Time.deltaTime;
		if (Time.deltaTime >= 60f)
		{
			if (SceneNum != "StartScene")
			{
				DataSave();
				autoSaveTime = 0;
				Debug.Log("auto save");
			}
		}

		if (gameClear)
		{
			gameClearTimes++;
			gameClear = false;
		}

		if (isFirstTime || loadFaild)
		{
			DataSave();
			loadFaild = false;
			isFirstTime = false;
			DataLoad();
		}

		if (SceneManager.GetActiveScene().name == "StartScene")
		if (SceneNum == "StartScene" || SceneNum == null)
			LoadingButton.GetComponent<Button>().interactable = false;
		else {
			LoadingButton.GetComponent<Button>().interactable = true;
		}
	}
}
