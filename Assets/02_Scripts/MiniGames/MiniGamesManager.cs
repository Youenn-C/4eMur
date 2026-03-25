using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField] private GameObject _jackCanvas, _tapeTaupeCanvas;
    private List<GameObject> _minigames;
    private GameObject _currentMinigame;
    private MS_Player_Controller _playerController;

    [SerializeField] private TapeTaupe _tapeTaupeManager;

    private int _numberOfWins, _amountOfWinsToEarn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _minigames = new List<GameObject>();
        _minigames.Add(_jackCanvas);
        _minigames.Add(_tapeTaupeCanvas);
        
        _playerController = MS_Player_Controller.Instance;
        
        foreach (GameObject minigame in _minigames)
        {
            minigame.SetActive(false);
        }
        
        _numberOfWins = 0;
        _amountOfWinsToEarn = 3;
    }

    private void OnMouseDown()
    {
        _playerController.ShowCursor();
        LaunchRandomMinigame();
    }

    private void LaunchRandomMinigame()
    {
        int r = Random.Range(0, _minigames.Count);
        _currentMinigame =  _minigames[r];
        _currentMinigame.SetActive(true);

        if (_currentMinigame == _tapeTaupeCanvas)
        {
            _tapeTaupeManager.Play();
        }
    }

    public void WinMiniGame()
    {
        _numberOfWins++;
        _currentMinigame.SetActive(false);
        if (_numberOfWins < _amountOfWinsToEarn)
        {
            StartCoroutine(WaitBeforeLaunch());
        }
        else
        {
            _currentMinigame.SetActive(false);
            _playerController.HideCursor();
            _numberOfWins = 0;
            _amountOfWinsToEarn = 3;
        }
    }
    
    private IEnumerator WaitBeforeLaunch()
    {
        yield return new WaitForSeconds(1);
        LaunchRandomMinigame();
    }
}
