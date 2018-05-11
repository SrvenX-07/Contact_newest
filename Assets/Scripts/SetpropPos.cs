using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetpropPos : MonoBehaviour
{
    public GameObject[] PropGameObjects;
	public static SetpropPos mInstance;
	public GameObject GameObjectSE;
    public GameObject knife;
    public GameObject cd;
    public GameObject envelop_me;
    public GameObject envelope;
    public GameObject key;
    public GameObject postcard;

	AudioSource SE;
	AudioClip getItem;

    // Use this for initialization
    void Start () {
		mInstance = this;

		SE = GameObjectSE.GetComponent<AudioSource>();
		getItem = GameObjectSE.GetComponent<AudioSource>().clip;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetPos(GameObject go)
    {
		SE.PlayOneShot(getItem);
        for (int i = 0; i < PropGameObjects.Length; i++)
        {
            Debug.Log(PropGameObjects[i].transform.childCount);
            if (PropGameObjects[i].transform.childCount == 1)
            {
                go.transform.SetParent(PropGameObjects[i].transform);
                go.SetActive(true);
                go.transform.localPosition = Vector3.zero;
            }
        }
    }

  
  
}
