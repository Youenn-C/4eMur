using System;
using UnityEngine;

public class MS_MG5_Note : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MS_MG5_Player _currentPlayer = other.gameObject.GetComponent<MS_MG5_Player>();
            _currentPlayer.Return_To_Start_Point();
        }
    }

    private void Update()
    {
        transform.position += new Vector3(-2, 0, 0);
    }
}
