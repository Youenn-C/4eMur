using UnityEngine;
using UnityEngine.UI;

public class TapeTaupe : MonoBehaviour
{
    [SerializeField] private Button _button1,  _button2, _button3, _button4, _button5, _button6, _button7, _button8, _button9;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Inactivate(_button1);
        Inactivate(_button2);
        Inactivate(_button3);
        Inactivate(_button4);
        Inactivate(_button5);
        Inactivate(_button6);
        Inactivate(_button7);
        Inactivate(_button8);
        Inactivate(_button9);
    }
    
    private void Inactivate(Button button)
    {
        button.gameObject.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
    }

    private void Activate(Button button)
    {
        button.gameObject.GetComponent<Image>().color = new Color32(225, 205, 76, 255);
    }
}
