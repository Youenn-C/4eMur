using System;
using UnityEngine;

public class MS_MG5_Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MS_MG5_Player>() != null)
        {
            MS_MG5_Manager.Instance.miniGameIsComplete = true;
        }
    }
}
