using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeTaupe : MonoBehaviour
{
    [SerializeField] private Button _button1,  _button2, _button3, _button4, _button5, _button6, _button7, _button8, _button9;
    private List<Button> _buttons, _activeButtons;
    
    private MiniGamesManager _manager;
    
    private void Awake()
    {
        _manager = FindFirstObjectByType<MiniGamesManager>();
        
        _buttons = new List<Button>();
        _activeButtons = new List<Button>();
        _buttons.Add(_button1);
        _buttons.Add(_button2);
        _buttons.Add(_button3);
        _buttons.Add(_button4);
        _buttons.Add(_button5);
        _buttons.Add(_button6);
        _buttons.Add(_button7);
        _buttons.Add(_button8);
        _buttons.Add(_button9);

        foreach (var button in _buttons)
        {
            Inactivate(button);
        }
    }
    
    private void Inactivate(Button button)
    {
        button.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
        if (_activeButtons.Contains(button))
        {
            _activeButtons.Remove(button);
        }
    }

    private void Activate(Button button)
    {
        if (_activeButtons.Contains(button))
        {
            return;
        }
        button.gameObject.GetComponent<Image>().color = new Color32(225, 205, 76, 255);
        _activeButtons.Add(button);
    }

    public void Play()
    {
        int r =  Random.Range(0, _buttons.Count);
        Activate(_buttons[r]);
        StartCoroutine(CheckActiveButtonsToDisable());
    }
    
    public void ClickOnButton(Button button)
    {
        if (_activeButtons.Contains(button))
        {
            Inactivate(button);
            _manager.WinMiniGame();
        }
    }

    private IEnumerator CheckActiveButtonsToDisable()
    {
        int r = Random.Range(1, 2);
        yield return new WaitForSeconds(r);
        if (_activeButtons.Count > 0)
        {
            foreach (var button in _activeButtons)
            {
                Inactivate(button);
                break;
            }
        }
        Play();
    }
}
