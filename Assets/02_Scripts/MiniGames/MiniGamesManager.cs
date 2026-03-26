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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        _currentTime = _maxTime;
        StartCoroutine(TimeManagement());
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
            StartCoroutine(WaitBeforeLaunch());
        }
    }
    
    private IEnumerator WaitBeforeLaunch()
    {
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

        StartCoroutine(TimeManagement());
    }
}
