using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class MS_MG5_Player : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private RectTransform _playerGameObject;
    [SerializeField] private RectTransform _startPoint;
    [SerializeField] private RectTransform _endPoint;
    [Space(5)]
    public BoxCollider2D _currentLigne;
    
    [Header("Varaibles"), Space(5)]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private List<float> _positionsY;
    [Space(5)]
    [SerializeField] private int _currentLigneID;
    
    [Header("Rewired"), Space(5)]
    public int playerID;
    public Player MG5_player;

    void Awake()
    {
        MG5_player = ReInput.players.GetPlayer(playerID);
    }

    void Update()
    {
        if (_playerGameObject.position.x < _endPoint.position.x)
        {
            _playerGameObject.position += new Vector3(_playerSpeed, 0f, 0f);
        }

        if (MG5_player.GetButtonDown("MG5_GoUp"))
        {
            if (_currentLigneID >= 1)
            {
                _currentLigneID--;
                _playerGameObject.position = new Vector3(_playerGameObject.position.x, _positionsY[_currentLigneID], 0f);
                
                Debug.Log("Action Up trigger");
                Debug.Log("Ligne ID :  " + _currentLigneID);
            }
        }
        
        if (MG5_player.GetButtonDown("MG5_GoDown"))
        {
            if (_currentLigneID <= 3)
            {
                _currentLigneID++;
                _playerGameObject.position = new Vector3(_playerGameObject.position.x, _positionsY[_currentLigneID], 0f);
                
                Debug.Log("Action Down trigger");
                Debug.Log("Ligne ID :  " + _currentLigneID);
            }
        }
    }

    public void Return_To_Start_Point()
    {
        _playerGameObject.position = _startPoint.position;
        _currentLigneID = 2;
    } 
}
