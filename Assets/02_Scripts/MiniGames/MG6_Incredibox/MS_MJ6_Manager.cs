using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MS_MJ6_Manager : MonoBehaviour
{
    public static MS_MJ6_Manager Instance;
    
    [Header("Reference"), Space(5)]
    public Image[] _objectvesImages;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private float _timer;
    [Space(5)]
    [SerializeField] private bool miniGameIsComplete;
    [Space(5)]
    public int[] _idOrder;
    [Space(5)]
    public Color[] colors;
    [Space(5)]
    public List<MS_MG6_Slot> _slotsRemain;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        ShuffleArray(_idOrder);
        Change_Objectives_Colors();
    }
    
    public void ShuffleArray(int[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n);
            n--;
        
            int temp = array[k];
            array[k] = array[n];
            array[n] = temp;
        }
    }

    void Change_Objectives_Colors()
    {
        _objectvesImages[0].color = colors[_idOrder[0]];
        _objectvesImages[1].color = colors[_idOrder[1]];
        _objectvesImages[2].color = colors[_idOrder[2]];
        _objectvesImages[3].color = colors[_idOrder[3]];
        _objectvesImages[4].color = colors[_idOrder[4]];
    }
    
    private void Update()
    {
        //if (!miniGameIsComplete)
        //{
        //    if (_timer > 0f)
        //    {
        //        _timer -= Time.deltaTime;
        //    }
        //
        //    if (_timer <= 0f)
        //    {
        //        EndOfMiniGame(miniGameIsComplete = false);
        //    }
        //}
    }

    public void Check_Slots_Remaining()
    {
        if (_slotsRemain.Count == 0) EndOfMiniGame(miniGameIsComplete = true);
        else EndOfMiniGame(miniGameIsComplete = false);
    }
    
    void EndOfMiniGame(bool miniGameIsComplete)
    {
        if (miniGameIsComplete)
        {
            Debug.Log("MiniGame Complete");
        }
        else 
        {
            Debug.Log("MiniGame Not Complete");
        }
    }
    
}
