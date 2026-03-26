using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Slider = UnityEngine.UI.Slider;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField] private GameObject _backgroundCanvas, _jackCanvas, _tapeTaupeCanvas;
    private List<GameObject> _minigames;
    private GameObject _currentMinigame;
    private MS_Player_Controller _playerController;

    [SerializeField] private TapeTaupe _tapeTaupeManager;

    private int _numberOfWins, _amountOfWinsToEarn, _maxTime, _currentTime, _maxLife, _currentLife;
    [SerializeField] Slider _timeSlider;
    
    void Start()
    {
        _backgroundCanvas.SetActive(false);
        
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

        _maxLife = 3;
        _currentLife = _maxLife;

        _maxTime = 5;
        _currentTime = _maxTime;
        _timeSlider.minValue = 0;
        _timeSlider.maxValue = _maxTime;
        _timeSlider.value = _currentTime;
    }

    private void OnMouseDown()
    {
        _playerController.ShowCursor();
        LaunchRandomMinigame();
        
        _backgroundCanvas.SetActive(true);
        
        PopupSpawner.ShowLife(_currentLife);
    }

    private void LaunchRandomMinigame()
    {
        int r = Random.Range(0, _minigames.Count);
        _currentMinigame =  _minigames[r];
        _currentMinigame.SetActive(true);
        _currentTime = _maxTime;
        _timeSlider.value = _currentTime;
        StartCoroutine(TimeManagement());

        if (_currentMinigame == _tapeTaupeCanvas)
        {
            _tapeTaupeManager.Play();
        }
    }

    public void WinMiniGame()
    {
        StopAllCoroutines();
        _numberOfWins++;
        if (_numberOfWins < _amountOfWinsToEarn)
        {
            StartCoroutine(WaitBeforeLaunch());
        }
        else
        {
            ShutDownMinigame();
        }
    }

    public void ShutDownMinigame()
    {
        _currentMinigame.SetActive(false);
        _playerController.HideCursor();
        _numberOfWins = 0;
        _amountOfWinsToEarn = 3;
        _backgroundCanvas.SetActive(false);
    }

    private void LoseLife()
    {
        StopAllCoroutines();
        _currentLife--;
        if (_currentLife <= 0)
        {
            ShutDownMinigame();
            PopupSpawner.LosingMinigame();
        }
        else
        {
            PopupSpawner.ShowLife(_currentLife);
            StartCoroutine(WaitBeforeLaunch());
        }
    }
    
    private IEnumerator WaitBeforeLaunch()
    {
        _currentMinigame.SetActive(false);
        yield return new WaitForSeconds(1);
        LaunchRandomMinigame();
    }

    private IEnumerator TimeManagement()
    {
        yield return new WaitForSeconds(1);
        _currentTime--;
        _timeSlider.value = _currentTime;
        if (_currentTime == 0)
        {
            LoseLife();
        }
        else
        {
            StartCoroutine(TimeManagement());
        }
    }
}
