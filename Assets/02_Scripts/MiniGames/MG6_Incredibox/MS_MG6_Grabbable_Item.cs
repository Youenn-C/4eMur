using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MS_MG6_Grabbable_Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Reference"), Space(5)]
    [SerializeField] private Image _image;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private bool _isHovered;
    public bool isGrabbable;
    public bool canBeGrabbable = true;
    public int ID;
    
    private void Start()
    {
        _image.color = MS_MJ6_Manager.Instance.colors[ID];
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        _isHovered = true;
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        _isHovered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isHovered && canBeGrabbable)
            {
                isGrabbable = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isGrabbable = false;
        }
        
        if (isGrabbable)
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }
}
