﻿using System.Collections;
using UnityEngine;

public class AsyncSceneLoader : MonoBehaviour
{
    

    public GameObject Loader;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        string sceneKey = "";

        switch (SceneManager.Scene)
        {
            case Scene.MENU_MAIN:
                sceneKey = "MainMenu";
                break;
            case Scene.MENU_CREDITS:
                sceneKey = "CreditMenu";
                break;
            case Scene.MENU_WIN:
                sceneKey = "WinMenu";
                break;
            case Scene.LEVEL:
                sceneKey = "Level X";
                break;
        }

        AsyncOperation op = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneKey);
        float progress = 0;

        while (!op.isDone)
        {
            float add = op.progress - progress;
            this.Loader.transform.Rotate(0, 0, add * 360.0f);
            progress = op.progress;
            yield return null;
        }
    }
}
