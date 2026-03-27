using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // public GameObject textQuiFaitPeur;

    private static Manager instance;

    private void Awake()
    {
        instance = this;

        Screen.SetResolution(1920, 1080, true);
        Application.runInBackground = true;
        // textQuiFaitPeur.SetActive(false);
    }

    static bool WantsToQuit()
    {
        if (instance != null)
        {
            // instance.textQuiFaitPeur.SetActive(true);
            // Screen.SetResolution(1920, 1080, true);
            return true;
        }

        return false; // bloque la fermeture
    }

    [RuntimeInitializeOnLoadMethod]
    static void RunOnStart()
    {
        Application.wantsToQuit += WantsToQuit;
    }

    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         Application.wantsToQuit -= WantsToQuit;
    //     }
    //
    //     if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         PopupSpawner.CreatePopup();
    //     }
    // }
}

    // private IEnumerator Coroutine()
    // {
    //     Screen.SetResolution(haha, haha, false);
    //     haha++;
    //     yield return new WaitForSeconds(0.3f);
    //     StartCoroutine(Coroutine());
    // }
    

