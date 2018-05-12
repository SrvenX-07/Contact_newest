using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Globe
{
    public static string nextSceneName;
}

public class SceneLoading : MonoBehaviour
{
    public Slider loadingSlider;
    public Text loadingText;
	public static SceneLoading mInstance;
    private float loadingSpeed = 1.0f;
    private float targetValue;
    private AsyncOperation operation;

    // Use this for initialization
    void Start()
    {
		mInstance = this;

        if (SceneManager.GetActiveScene().name == "loading")
        {
			loadingSlider.value = 0.00f;
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);
        //阻止当加载完成自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }

	// Update is called once per frame
	void Update()
	{
		if (SceneManager.GetActiveScene().name == "loading")
		{
			targetValue = operation.progress;

			if (operation.progress >= 0.90f)
			{
				//operation.progress的值最大为0.9
				targetValue = 1.00f;
			}

			if (targetValue != loadingSlider.value)
			{
				//插值运算
				loadingSlider.value = Mathf.Lerp(loadingSlider.value, targetValue, Time.deltaTime * loadingSpeed);
				if (Mathf.Abs(loadingSlider.value - targetValue) < 0.01f)
				{
					loadingSlider.value = targetValue;
				}
			}

			loadingText.text = ((int)(loadingSlider.value * 100)).ToString() + "%";

			if ((int)(loadingSlider.value * 100) == 100)
			{
				//允许异步加载完毕后自动切换场景
				operation.allowSceneActivation = true;
			}
		}
	}

	public void LoadNewScene()  
    {
		//保存需要加载的目标场景  
		switch (SceneManager.GetActiveScene().name)
		{
			case "StartScene":
				Globe.nextSceneName = "1-1";
				break;
			case "1-1":
				Globe.nextSceneName = "2-1";
				break;
			case "2-1":
				Globe.nextSceneName = "3-1";
				break;
			case "3-1":
				Globe.nextSceneName = "xx";
				break;
		}

		if (Router.forGame)
			Globe.nextSceneName = Router.SceneNum;
		
        SceneManager.LoadScene("loading");        
    }  
}
