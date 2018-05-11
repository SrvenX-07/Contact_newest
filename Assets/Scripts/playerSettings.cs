using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerSettings : MonoBehaviour {
    void OnMouseUp()                 //鼠标点击时调用，触发按钮事件

    {
        Invoke("Jump", 0.5F);       //0.5秒，调用jump方法

    }

    void Jump()

    {
        Application.LoadLevel("StartScene");//“loading”是所要跳转的目标场景名称

    }

}
