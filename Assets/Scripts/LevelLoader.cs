using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelLoader
{
    public static void Load(string level)
    {
        SceneManager.LoadScene("Base");
            
        SceneManager.LoadScene(level);
    }
}
