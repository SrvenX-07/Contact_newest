using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueEnding : MonoBehaviour {

	public GameObject list;
	public GameObject ed5;
	public GameObject edApplause;
	public GameObject SE;

	Animation aList;
	AudioSource listSource;
	AudioSource SESource;

	private int i;
    // 放声音
	public void PlaySound(AudioClip clip){
		SESource.PlayOneShot(clip);
	}

	// Use this for initialization
	void Start () {
		aList = list.GetComponent<Animation>();
		listSource = edApplause.GetComponent<AudioSource>();
		SESource = SE.GetComponent<AudioSource>();

		Router.sED5 = true;
		Router.gameClear = true;
		Router.mInstance.DataSave();
	}
	
	// Update is called once per frame
	void Update () {
		    if(list.activeSelf)
		        if (aList.isPlaying == false){
			        edApplause.SetActive(true);
		}

		if (edApplause.activeSelf)
			if (listSource.isPlaying == false)
				ed5.SetActive(true);
	}
}
