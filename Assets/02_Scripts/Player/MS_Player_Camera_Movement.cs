using UnityEngine;
using Rewired;

public class MS_Player_Camera_Movement : MonoBehaviour
{
    [Header("Variables CameraRotation"), Space(5)] [SerializeField]
    private float _rotationOnX;
    private float _rotationOnY;
    [SerializeField, Range(0f, 1f)] private float _sensibility = 0.5f; // Sensibilité
    [Space(5)]
    [SerializeField, Range(-75f, 0)] private float _limitVerticalCameraRotationMin = -45f; // Limite minimale
    [SerializeField, Range(0, 75f)] private float _limitVerticalCameraRotationMax = 45f; // Limite maximale
    [SerializeField] private float currentVerticalRotation;
    
    void Update()
    {
        if (MS_Player_Controller.Instance.playerCanLookAround)
        {
            // ## ROTATION AXE Y #######################################################################################
            _rotationOnX = MS_Player_Controller.Instance.player.GetAxis("Camera_X_Rotation");
            _rotationOnY = MS_Player_Controller.Instance.player.GetAxis("Camera_Y_Rotation");

            MS_Player_Controller.Instance.playerGameObject.transform.localEulerAngles += Vector3.up * (_rotationOnY * _sensibility);

            // ## ROTATION AXE X #######################################################################################
            currentVerticalRotation += (_rotationOnX * _sensibility);
            currentVerticalRotation = Mathf.Clamp(currentVerticalRotation, _limitVerticalCameraRotationMin, _limitVerticalCameraRotationMax);

            // Appliquer la rotation avec clamp
            MS_Player_Controller.Instance.cinemachineTargetGameObject.transform.localEulerAngles = new Vector3(-currentVerticalRotation, 0f, 0f);
        }
    }
}