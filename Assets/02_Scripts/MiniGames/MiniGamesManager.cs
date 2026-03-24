using System;
using System.Collections;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField] private GameObject _jackCanvas, _tapeTaupeCanvas;
    private MS_Player_Controller _playerController;

    private int _numberOfWins, _amountOfWinsToEarn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerController = MS_Player_Controller.Instance;
        _jackCanvas.SetActive(false);
        
        _numberOfWins = 0;
        _amountOfWinsToEarn = 3;
    }

    private void OnMouseDown()
    {
        _playerController.ShowCursor();
        LaunchRandomMinigame();
    }

    private void LaunchRandomMinigame() //pour le moment c'est pas random mais belek
    {
        _jackCanvas.SetActive(true);
    }

    public void WinMiniGame()
    {
        _numberOfWins++;
        _jackCanvas.SetActive(false);
        if (_numberOfWins < _amountOfWinsToEarn)
        {
            StartCoroutine(WaitBeforeLaunch());
        }
    }
    
    private IEnumerator WaitBeforeLaunch()
    {
        yield return new WaitForSeconds(1);
        LaunchRandomMinigame();
    }
}
