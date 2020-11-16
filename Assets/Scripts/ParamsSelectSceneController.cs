using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParamsSelectSceneController : MonoBehaviour
{
    private RuntimeData runtimeData;

    void Start()
    {
        runtimeData = GameObject.Find("RuntimeData").GetComponent<RuntimeData>();
    }

    public void NextButton()
    {
        runtimeData.setRandomVelocity(2375, 2425);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
