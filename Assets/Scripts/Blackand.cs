using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackand : MonoBehaviour {

    public float mtime;
    public float temp = 2.5f;
    public GameObject ed2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mtime += Time.deltaTime;
        if (mtime >= temp)
        {
            ed2.SetActive(true);
        }
    }
}
