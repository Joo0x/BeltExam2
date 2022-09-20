using UnityEngine;
using UnityEngine.Events;

public class ChestPieces : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPiecePickup;
    [SerializeField] private ChestPuzzle _puzzle;
    private bool isTriggered = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isTriggered)
        {
            isTriggered = false;
            _onPiecePickup.Invoke();
            _puzzle.UpdatePieces();
        }
    }
}
