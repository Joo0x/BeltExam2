using System.Collections.Generic;
using UnityEngine;

public class AsiaInteraction : MonoBehaviour
{
    public List<GameObject> puzzleList = new List<GameObject>();

    public List<GameObject> getItems()
    {
        return puzzleList;
    }

    private void OnTriggerEnter(Collider other)
    {
        puzzleList.Add(other.GetComponent<IPuzzleable>()?.trigerred());
        other.GetComponent<IPuzzleable>()?.Die();
        print(puzzleList);
    }
}