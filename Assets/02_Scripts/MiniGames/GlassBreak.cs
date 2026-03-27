using System;
using UnityEngine;
using UnityEngine.UI;

public class GlassBreak : MonoBehaviour
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Image _glass;
    [SerializeField] private Sprite _cleanGlass, _destroyedGlass;
    private MiniGamesManager _manager;

    private void Start()
    {
        _manager = FindFirstObjectByType<MiniGamesManager>();
        Initialize();
    }

    public void Initialize()
    {
        _volumeSlider.value = 0;
        _glass.sprite = _cleanGlass;
    }

    public void BreakGlass()
    {
        if (Mathf.Approximately(_volumeSlider.value, 1))
        {
            _glass.sprite = _destroyedGlass;
            _manager.WinMiniGame();
        }
    }
}
