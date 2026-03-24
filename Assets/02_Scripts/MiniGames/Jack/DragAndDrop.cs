using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;

    // private Image _image;
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        // _image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        // _rectTransform.anchoredPosition += eventData.delta;
        transform.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
