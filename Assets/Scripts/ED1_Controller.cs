using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ED1_Controller : MonoBehaviour {
    
    public GameObject ED1;
    public GameObject ED4;

    public void ed1Controller() {
        if (Router.postCardUsed == true)
        {
            ED1.SetActive(true);
        } else {
            ED4.SetActive(true);
        }
    }
}
