using System;
using UnityEngine;

public class MS_MG4_Manager : MonoBehaviour
{
    [Header("Reference"), Space(5)]
    [SerializeField] private GameObject _musicQueue;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private int _musicNumber;
    [SerializeField] private float _timer;
    [SerializeField] private bool miniGameIsComplete;
    
    private MiniGamesManager _minigameManager;

    private void Start()
    {
        _minigameManager = FindFirstObjectByType<MiniGamesManager>();
        // Application.targetFrameRate = 60;
        
        _musicNumber = _musicQueue.transform.childCount;
    }


    private void Update()
    {
        // if (!miniGameIsComplete)
        // {
        //     if (_timer > 0f)
        //     {
        //         _timer -= Time.deltaTime;
        //     }
        //
        //     if (_timer <= 0f)
        //     {
        //         EndOfMiniGame(miniGameIsComplete = false);
        //     }
        // }
    }


    public void DecrementMusicNumber()
    {
        _musicNumber--;
        if (_musicNumber <= 2)
        {
            EndOfMiniGame(miniGameIsComplete = true);
        }
    }

    void EndOfMiniGame(bool miniGameIsComplete)
    {
        if (miniGameIsComplete)
        {
            _minigameManager.WinMiniGame();
        }
        else 
        {
            Debug.Log("MiniGame Not Complete");
        }
    }
    
}
