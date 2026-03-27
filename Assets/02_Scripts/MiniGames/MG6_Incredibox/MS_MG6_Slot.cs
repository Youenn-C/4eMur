using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MS_MG6_Slot : MonoBehaviour
{
    [Header("Reference"), Space(5)]
    [SerializeField] private Collider2D _collider2D;
    [SerializeField] private MS_MG6_Grabbable_Item _currentGrabedItem;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private bool _isHovered;
    [SerializeField] private bool _currentGrabedItemIsCorrect;
    [SerializeField] private int _idTarget;

    private void Start()
    {
        MS_MJ6_Manager.Instance._slotsRemain.Add(this);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MS_MG6_Grabbable_Item>() != null)
        {
            _currentGrabedItem = other.GetComponent<MS_MG6_Grabbable_Item>();
            
            Check_IDs();
            
            if (_currentGrabedItemIsCorrect)
            {
                _currentGrabedItem.canBeGrabbable = false;
                _currentGrabedItem.isGrabbable = false;
                
                Snap_Grabed_Item(_currentGrabedItem);
            }
        }
        
    }

    private void Snap_Grabed_Item(MS_MG6_Grabbable_Item item)
    {
        item.transform.SetParent(gameObject.transform);
        item.transform.localPosition = Vector2 .zero;
    }
    
    private void Check_IDs()
    {
        if (_currentGrabedItem.ID == MS_MJ6_Manager.Instance._idOrder[_idTarget])
        {
            _currentGrabedItemIsCorrect =  true;
            MS_MJ6_Manager.Instance._slotsRemain.Remove(this);
            MS_MJ6_Manager.Instance.Check_Slots_Remaining();
        }
    }
}
