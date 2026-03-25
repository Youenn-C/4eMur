using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MS_Music_Item : MonoBehaviour, IPointerEnterHandler
{
    [Header("References"), Space(5)]
    [SerializeField] private TMP_Text _musicName;
    [SerializeField] private Image _musicIcone;
    [SerializeField] private Collider2D _buttonCollider2D;
    [SerializeField] private Button _button;
    [SerializeField] private SO_MusicDatas _currentMusicDatas;
    
    [Header("Variables"), Space(5)]
    [SerializeField] private Vector3 _topLeftMaxPosition;
    [SerializeField] private Vector3 _bottomRightMaxPosition;
    [SerializeField] private Vector3 _randomizedPosition;
    
    

    public void OnPointerEnter(PointerEventData eventData)
    {
        float percent = Random.Range(0, 10);
        
        Debug.Log("Trigger");
        
        if (percent <= 0.5f)
        {
            Debug.Log("Randomize position");
            RandomizePosition();
        }
    }
    
    void RandomizePosition()
    {
        _randomizedPosition.x = Random.Range(_topLeftMaxPosition.x, _bottomRightMaxPosition.x);
        _randomizedPosition.y = Random.Range(_topLeftMaxPosition.y, _bottomRightMaxPosition.y);
        
        _button.transform.position = _button.transform.parent.position + _randomizedPosition;
    }
    
    private void Start()
    {
        _musicName.text = _currentMusicDatas.musicName;
        _musicIcone.sprite = _currentMusicDatas.musicIcon;
    }

    public void RemoveMusicFromQueue()
    {
        Destroy(gameObject);
    }
}
