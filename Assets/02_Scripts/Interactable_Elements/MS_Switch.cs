using UnityEngine;

public class MS_Switch : MonoBehaviour, I_Interactable
{
    [Header("Static Variables"), Space(5)]
    [SerializeField] private Material _onMaterial;
    [SerializeField] private Material _offMaterial;
    
    [Header("Dynamic Variables"), Space(5)]
    [SerializeField] private bool _isOn;
    
    public void Activate()
    {
        _isOn = !_isOn;
        SwitchMaterial();
    }
    
    void SwitchMaterial()
    {
        if (_isOn) gameObject.GetComponent<Renderer>().material = _onMaterial;
        else gameObject.GetComponent<Renderer>().material = _offMaterial;
    }
    
}
