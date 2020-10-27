using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoading : MonoBehaviour
{
    // Start is called before the first frame update
    public void SceneLoad(){
        SceneManager.LoadSceneAsync(gameObject.name);
    }
    public void LoadHomeScene(){
        SceneManager.LoadSceneAsync("HomeScene");
    }
    public void LoadArcadeModeScene(){
        SceneManager.LoadSceneAsync("ArcadeModeScene");
    } 
}
