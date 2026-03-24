using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpeedClick : MonoBehaviour
{
    [SerializeField]
    private ClickableCube _cube1, _cube2, _cube3, _cube4, _cube5, _cube6, _cube7, _cube8,  _cube9;
    private List<ClickableCube> _cubes = new();

    private int _score;
    public int activeCubes;
    [SerializeField] private TextMeshPro _scoreText;

    private void Start()
    {
        _scoreText.text = _score.ToString();
        _cubes.Add(_cube1);
        _cubes.Add(_cube2);
        _cubes.Add(_cube3);
        _cubes.Add(_cube4);
        _cubes.Add(_cube5);
        _cubes.Add(_cube6);
        _cubes.Add(_cube7);
        _cubes.Add(_cube8);
        _cubes.Add(_cube9);
    }

    private void Update()
    {
        if (activeCubes<2)
        {
            LaunchRandomCube();
        }
    }

    public void LaunchRandomCube()
    {
        int r = Random.Range(0, _cubes.Count);
        _cubes[r].LaunchCoroutine();
        activeCubes++;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
