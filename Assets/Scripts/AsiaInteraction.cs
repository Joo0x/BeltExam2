using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsiaInteraction : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    [SerializeField] private Transform _spawnPos;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _healthbar.fillAmount -= 0.2f;
            if (_healthbar.fillAmount <= 0)
            {
                transform.position = _spawnPos.position;
                _healthbar.fillAmount = 1;
            }
        }
    }
}