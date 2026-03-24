using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler
    // , IBeginDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    [SerializeField] private RectTransform _goalRectTransform;
    
    private Vector3 _jackInSpawn,  _jackOutSpawn;
    
    private MiniGamesManager _manager;

    // private Image _image;
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        // _image = GetComponent<Image>();
        _manager = FindFirstObjectByType<MiniGamesManager>();
        
        _jackInSpawn = new Vector3(510,540,0);
        _jackOutSpawn = new Vector3(1700,540,0);
    }

    private void Start()
    {
        ReplaceJacks();
    }

    private void ReplaceJacks()
    {
        _rectTransform.transform.position = _jackInSpawn;
        _goalRectTransform.transform.position = _jackOutSpawn;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // _rectTransform.anchoredPosition += eventData.delta;
        transform.position = Input.mousePosition;
        if (EnterInBox.IsOverlapping(_rectTransform, _goalRectTransform))
        {
            ReplaceJacks();
            _manager.WinMiniGame();
        }
    }

    // public void OnBeginDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }

    // public void OnEndDrag(PointerEventData eventData)
    // {
    //     throw new System.NotImplementedException();
    // }
}
