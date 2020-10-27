using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadAtStart : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Image loadingBar;
    public SaveLoadSystem saveLoadSystem;
    void Start()
    {
        StartCoroutine(LoadingScene(1));
        saveLoadSystem = transform.GetComponent<SaveLoadSystem>();
        saveLoadSystem.LoadPlayer();
    }
    IEnumerator LoadingScene(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone){
            loadingBar.fillAmount = operation.progress;
            yield return null;
        } 
    }
}
