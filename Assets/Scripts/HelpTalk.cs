using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpTalk : MonoBehaviour {

    private int help = 0;
    private int okerror = 0;
    public GameObject go1;
    public GameObject go2;
    public GameObject go3;

    public GameObject ok1;
    public GameObject ok2;
    public GameObject ok3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickHelp()
    {
        help++;
        if (help == 1)
        {
            go1.SetActive(true);
        }
        if (help == 2)
        {
            go2.SetActive(true);
        }
        if (help == 3)
        {
            go3.SetActive(true);
        }
    }
}
