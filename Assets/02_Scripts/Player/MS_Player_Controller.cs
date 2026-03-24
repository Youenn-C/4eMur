using UnityEngine;
using Rewired;

public class MS_Player_Controller : MonoBehaviour
{
    public static MS_Player_Controller Instance;
    
    [Header("References"), Space(5)]
    public Rigidbody playerRigidbody;
    public GameObject playerGameObject;
    public GameObject cinemachineTargetGameObject;
    public GameObject playerInteractUI;
    public Animator playerCameraAnimator;
    
    [Header("Player Scripts"), Space(5)]
    public MS_Player_Movement playerMovement;
    public MS_Player_Camera_Movement playerCameraMovement;
    
    [Header("Variables"), Space(5)]
    public float playerSpeed;
    [Space(5)]
    public bool playerCanMove = true;
    public bool playerCanLookAround = true;
    
    [Header("Rewired"), Space(5)]
    public int playerID;
    public Player player;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
        
        player = ReInput.players.GetPlayer(playerID);
    }

    void Start()
    {
        playerInteractUI.SetActive(false);
    }
}