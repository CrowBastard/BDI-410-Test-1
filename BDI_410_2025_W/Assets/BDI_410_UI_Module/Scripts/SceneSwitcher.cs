using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Method to switch a scene by index
    public void SwitchSceneByIndex(int sceneIndex)
    {
        if(sceneIndex >=0 && sceneIndex <SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            Debug.LogWarning("Invalid scene index" + sceneIndex);
        }
    }
}
