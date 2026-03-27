using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MS_MG5_Manager : MonoBehaviour
{
    public static MS_MG5_Manager Instance;
    
    [Header("References"), Space(5)]
    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private GameObject _prefabToInstantiate; 

    [Header("Variables"), Space(5)]
    [SerializeField] private float _timer;
    public bool miniGameIsComplete;
    
    private MiniGamesManager _minigamesManager;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        _minigamesManager = FindFirstObjectByType<MiniGamesManager>();
        StartCoroutine(Create_Note());
    }

    IEnumerator Create_Note()
    {
        while (!miniGameIsComplete)
        {
            int randomInt = Random.Range(0, _spawnPoints.Count);

            Instantiate(_prefabToInstantiate, _spawnPoints[randomInt].transform);
            
            yield return new WaitForSeconds(0.75f);
        }
    }
}