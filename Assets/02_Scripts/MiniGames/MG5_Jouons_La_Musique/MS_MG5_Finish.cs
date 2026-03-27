using System;
using UnityEngine;

public class MS_MG5_Finish : MonoBehaviour
{
    private MiniGamesManager _miniGamesManager;

    private void Start()
    {
        _miniGamesManager = FindFirstObjectByType<MiniGamesManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MS_MG5_Player>() != null)
        {
            _miniGamesManager.WinMiniGame();
            MS_MG5_Manager.Instance.miniGameIsComplete = true;
        }
    }
}
