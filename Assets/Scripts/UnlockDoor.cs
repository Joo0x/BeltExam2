using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] private UnityEvent onPuzzleComplete;
    public static event Action DoorUnlock;

    private bool isTriggered = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isTriggered)
        {
            isTriggered = false;
            onPuzzleComplete.Invoke();
            DoorUnlock?.Invoke();
        }
        
    }
}
