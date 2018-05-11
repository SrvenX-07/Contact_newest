using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EdisonLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    /// <summary>
    /// 跳转场景通用函数
    /// </summary>
    /// <param name="SceneName"></param>
    public void SceneLoad(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        Debug.Log(SceneName);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
        }
}
