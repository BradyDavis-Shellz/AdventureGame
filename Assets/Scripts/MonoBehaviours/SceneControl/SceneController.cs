﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;
    public event Action AfterSceneLoad;


    public CanvasGroup faderCanvasGroup;
    public float fadeDuration = 1f;
    public string startingSceneName = "SecurityRoom";
    public string initialStartingPositionName = "DoorToMarket";
    public SaveData playerSaveData;

    private bool isFading;


    private IEnumerator Start()
    {
        faderCanvasGroup.alpha = 1f;

        playerSaveData.Save(PlayerMovement.startingPositionKey, initialStartingPositionName);


        yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));

        StartCoroutine(Fade(0f));
    }


    public void FadeAndLoadScene(SceneReaction sceneReaction)
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneReaction.sceneName));
        }
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(Fade(1f));
        if (BeforeSceneUnload != null)
        {
            BeforeSceneUnload();
        }

        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));

        AfterSceneLoad?.Invoke();

        yield return StartCoroutine(Fade(0f));
    }

    private IEnumerator LoadSceneAndSetActive (String sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);

        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    /// <summary>
    /// Fades until final alpha is reached
    /// </summary>
    /// <param name="finalAlpha"></param>
    /// <returns></returns>
    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;
        faderCanvasGroup.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha) / fadeDuration;

        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed * Time.deltaTime);
            yield return null;
        }
       
        isFading = false;
        faderCanvasGroup.blocksRaycasts = false;
    }
}
