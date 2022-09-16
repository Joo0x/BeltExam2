using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckList : MonoBehaviour
{
    private int puzzlestatus = 0;
    [SerializeField] private UnityEvent onPuzzleComplete;
    public static event Action DoorUnlock;
    
    private void OnCollisionEnter(Collision collision)
    {
        List<GameObject> temp = collision.gameObject.GetComponent<AsiaInteraction>().getItems();
        foreach (var item in temp)
        {
            if (item.name.Contains("sword"))
            {
                transform.GetChild(1).gameObject.SetActive(true);
                puzzlestatus += 1;
            }

            if (item.name.Contains("goblet"))
            {
                transform.GetChild(0).gameObject.SetActive(true);
                puzzlestatus += 1;
            }

            if (item.name.Contains("skull"))
            {
                transform.GetChild(2).gameObject.SetActive(true);
                puzzlestatus += 1;
            }
        }
        
        //Clear list for no duplications
        temp.Clear();
        //check the if puzzle compeleted
        if (puzzlestatus == 3)
        {
            Debug.Log("Compelete");
            onPuzzleComplete.Invoke();
            DoorUnlock?.Invoke();
        }
    }
    
}