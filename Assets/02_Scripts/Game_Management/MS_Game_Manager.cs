using UnityEngine;

public class MS_Game_Manager : MonoBehaviour
{
    [Header("References"), Space(5)]
    [SerializeField] private GameObject player;
    
    [Header("Variables"), Space(5)]
    public int _targetFrameRate = 60;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = _targetFrameRate;
        
    }
}
