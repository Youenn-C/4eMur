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
    public GameObject crosshair;
    
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
        HideCursor();
    }
    
    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        playerCanLookAround  = false;
        playerCanMove = false;
        
        crosshair.SetActive(false);
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        playerCanLookAround  = true;
        playerCanMove = true;
        
        crosshair.SetActive(true);
    }
}