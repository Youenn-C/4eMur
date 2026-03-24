using System;
using UnityEngine;

public class EnterInBox : MonoBehaviour
{
    [SerializeField] private Collider _goalCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other == _goalCollider)
        {
            Destroy(gameObject);
            Debug.Log("gg t'as branché la prise jack");
        }
    }
}

