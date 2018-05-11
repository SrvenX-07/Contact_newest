using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLoadScene : MonoBehaviour
{
    public float mtime;
    public float temp=2.5f;
    public string scenename;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    mtime += Time.deltaTime;
	    if (mtime >= temp)
	    {
	        SceneManager.LoadScene(scenename);
	    }
	}
}
