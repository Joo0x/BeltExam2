
using UnityEngine;

public class PuzzleItem : MonoBehaviour, IPuzzleable
{
    [SerializeField] private string item;

    public GameObject trigerred()
    {
        Debug.Log($"Collect + {item}");
        return gameObject;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}