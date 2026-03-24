using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClickableCube : MonoBehaviour
{
    public bool clickable;
    private bool _able;
    [SerializeField]
    private Material _notAbleMaterial, _ableMaterial;

    private SpeedClick _cubesManager;

    private void Start()
    {
        _cubesManager = FindFirstObjectByType<SpeedClick>();
        gameObject.GetComponent<Renderer>().material = _notAbleMaterial;
    }

    public void LaunchCoroutine()
    {
        // if (_able)
        // {
            BecomeClickable();
        // }
        // else
        // {
        //     StartCoroutine(Roll());
        // }
    }

    private void OnMouseDown()
    {
        if (clickable)
        {
            StopAllCoroutines();
            StopBeingAble();
            _cubesManager.IncreaseScore();
        }
    }

    private void BecomeClickable()
    {
        clickable = true;
        gameObject.GetComponent<Renderer>().material = _ableMaterial;
        StartCoroutine(BecomeNotAble());
    }

    private void StopBeingAble()
    {
        clickable = false;
        _able = false;
        gameObject.GetComponent<Renderer>().material = _notAbleMaterial;
        _cubesManager.activeCubes--;
    }

    // private IEnumerator Roll()
    // {
    //     int r = Random.Range(1, 5);
    //     if (r == 1)
    //     {
    //         _able = true;
    //     }
    //     yield return new WaitForSeconds(1f);
    // }

    private IEnumerator BecomeNotAble()
    {
        int r = Random.Range(1, 2);
        yield return new WaitForSeconds(r);
        StopBeingAble();
    }
}
