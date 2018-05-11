using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine;
using LitJson;

public class Save : MonoBehaviour
{
	Router router = new Router();
	SaveData saveData = new SaveData();
    
	public string fileName;

	public void _Save()
	{
		saveData.RouterAll = Router.RouterAll;
		saveData.Scene1ItemStatus = Router.Scene1ItemStatus;
		saveData.Scene2ItemStatus = Router.Scene2ItemStatus;
		saveData.Scene3ItemStatus = Router.Scene3ItemStatus;
		string jSaveData = JsonMapper.ToJson(saveData);
		Debug.Log(jSaveData);
	}

	private void Start()
	{
		
		fileName = Application.dataPath + "/Save" + "/GameData.json";
	}
}

[System.Serializable]
public class SaveData
{
	//接收Router的全局FLAG值
	public List<bool> RouterAll;

	//接受场景1的道具FLAG值
    public List<bool> Scene1ItemStatus;

	//接受场景2的道具FLAG值
	public List<bool> Scene2ItemStatus;

	//接受场景3的道具FLAG值
	public List<bool> Scene3ItemStatus;

	//接受存档时的场景编号
	public string sceneNum;
}