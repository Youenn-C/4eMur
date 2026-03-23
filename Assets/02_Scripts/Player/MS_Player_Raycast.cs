using UnityEngine;

public class MS_Player_Raycast : MonoBehaviour, I_Interactable
{
    [Header("References"), Space(5)]
    [SerializeField] private Transform _rayOrigine;

    [Header("Layer Mask à checker"), Space(5)]
    [SerializeField] private LayerMask _layerMaskToCheck;

    [Header("Raycast Settings"), Space(5)]
    [SerializeField] private float _rayRange;

    [Header("Debug"), Space(5)]
    public RaycastHit hit;

    void Update()
    {
        /*
        if (Physics.Raycast(_rayOrigine.position, _rayOrigine.forward, out hit, _rayRange, _layerMaskToCheck))
        {
            Debug.DrawRay(_rayOrigine.position, _rayOrigine.forward * hit.distance, Color.magenta);

            if (PlayerBrain.Instance.player.GetButtonDown("Interact"))
            {
                GameObject hitObject = hit.collider.gameObject;

                // Vérifie si l'objet est dans le LayerMask
                if (((1 << hitObject.layer) & _layerMaskToCheck) != 0)
                {
                    // Vérifie s’il implémente IActivatable
                    I_Interactable activatable = hitObject.GetComponent<I_Interactable>();
                    
                    if (activatable != null)
                    {
                        activatable.Activate();
                    }
                }
            }
        }
        */
    }

    public void Activate()
    {
    }
}