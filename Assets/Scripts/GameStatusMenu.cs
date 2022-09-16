using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatusMenu : MonoBehaviour
{
    public static event Action<int> canvasIDevent;
    [SerializeField] private int canvasID;

    private void OnTriggerEnter(Collider other)
    {
        Cursor.visible = true;
        transform.GetChild(canvasID).GetComponent<Canvas>().gameObject.SetActive(true);
        canvasIDevent?.Invoke(canvasID);
    }

    private void Awake()
    {
        StartCoroutine("DisableInfo");
    }

    private IEnumerator DisableInfo()
    {
        yield return new WaitForSeconds(3);
        transform.GetChild(0).GetComponent<Canvas>().gameObject.SetActive(false);
    }
}