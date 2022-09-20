using UnityEngine;
using UnityEngine.Events;

public class ChestPuzzle : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private UnityEvent _onPuzzleStart;
    [SerializeField] private UnityEvent _onPuzzleComplete;
    private int puzzlePieces;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _onPuzzleStart.Invoke();
        }
    }

    public void UpdatePieces()
    {
        puzzlePieces++;
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        if (puzzlePieces >= 4)
        {
            _onPuzzleComplete.Invoke();
        }
    }
}
