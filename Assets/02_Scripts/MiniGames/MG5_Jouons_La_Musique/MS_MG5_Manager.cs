using UnityEngine;
using Rewired;


public class MS_MG5_Manager : MonoBehaviour
{
    [Header("Rewired"), Space(5)]
    public int playerID;
    public Player MG5_player;

    void Awake()
    {
        MG5_player = ReInput.players.GetPlayer(playerID);
    }
    
    
    
    
    
    
}