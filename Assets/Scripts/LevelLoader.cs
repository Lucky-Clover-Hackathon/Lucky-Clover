using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static void Load(string level)
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("Base");
            
        SceneManager.LoadScene(level);
        var cam = GameObject.FindGameObjectWithTag("MainCamera");
        cam.SetActive(false);
        cam.SetActive(true);
    }
}
