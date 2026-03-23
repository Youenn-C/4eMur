using UnityEngine;
using Rewired;

public class MS_Player_Movement : MonoBehaviour
{
    [Header("Variables"), Space(5)]
    [SerializeField] private float _forwardMovement;
    [SerializeField] private float _lateralMovement;
    [Space(5)]
    [SerializeField] private bool isMoving;
    [Space(5)]
    [SerializeField] private Animation _idleAnimation;
    [SerializeField] private Animation _walkAnimation;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        MS_Player_Controller.Instance.playerCameraAnimator.SetTrigger("Idle");
    }
    
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    // -- MOVEMENT -------------------------------------------------------------------------------------------------
    // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    void Update()
    {
        // Mises à jour des directions basées sur les boutons
        _forwardMovement = MS_Player_Controller.Instance.player.GetAxis("Forward_Movement");
        _lateralMovement = MS_Player_Controller.Instance.player.GetAxis("Lateral_Movement");
        
        if (_forwardMovement == 0f && _lateralMovement == 0f) isMoving = false;
        else isMoving = true;

        if (isMoving)
        {
            MS_Player_Controller.Instance.playerCameraAnimator.SetTrigger("Walk");
        }
        else
        {
            MS_Player_Controller.Instance.playerCameraAnimator.SetTrigger("Idle");
        }
    }
    
    void FixedUpdate()
    {
        if (MS_Player_Controller.Instance.playerCanMove)
        {
            Vector3 direction = Vector3.zero;
            
            if (_forwardMovement > 0f) direction += transform.forward;
            if (_forwardMovement < 0f) direction -= transform.forward;
            if (_lateralMovement > 0f) direction += transform.right;
            if (_lateralMovement < 0f) direction -= transform.right;
    
            direction.Normalize();
    
            Vector3 velocity = direction * MS_Player_Controller.Instance.playerSpeed;
            velocity.y = MS_Player_Controller.Instance.playerRigidbody.linearVelocity.y;
    
            MS_Player_Controller.Instance.playerRigidbody.linearVelocity = velocity;
        }
    }
}