using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfTripHandler : MonoBehaviour
{
    [SerializeField] private Transform NPCsRoot;

    public static EndOfTripHandler Instance;

    public UnityEvent OnReachedTheDestination;

    [SerializeField] private float _maximalDistance = 1f;

    private void Awake() {
        Instance = this;
    }

    public bool IsReachedTheDestination { get; private set; } = false;

    private void FixedUpdate() {
        if (!IsReachedTheDestination) {
            if (Vector3.Distance(transform.position, NPCsRoot.position) < _maximalDistance) {
                IsReachedTheDestination = true;
                OnReachedTheDestination?.Invoke();
            }
        }
    }

    public void Next()
    {
        MainCounter.Instance.Level++;
        LoadScene(0);
    }

    public void LoadScene(int index) => SceneManager.LoadScene(index);
}
