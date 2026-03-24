using System;
using UnityEngine;

public class MiniGamesManager : MonoBehaviour
{
    [SerializeField] private GameObject _jackCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _jackCanvas.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        _jackCanvas.SetActive(true);
    }
}
