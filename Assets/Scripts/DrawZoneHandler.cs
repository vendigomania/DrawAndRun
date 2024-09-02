using UnityEngine.Events;
using UnityEngine;
using UnityEngine.EventSystems;

public class DrawZoneHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [field: SerializeField]
    public bool IsInDrawZone { get; private set; } = false;

    public UnityEvent OnEndDrawing;

    [field: SerializeField]
    public bool HasTouchedZone { get; private set; } = false;

    public static DrawZoneHandler Instance;

    private bool _reactOnPointerUpAndDown = true;

    private void Awake() {
        Instance = this;
    }

    public void OnPointerEnter(PointerEventData data) => IsInDrawZone = true;

    public void OnPointerExit(PointerEventData data) {
        IsInDrawZone = false;
        if(!HasTouchedZone) HasTouchedZone = true;
        OnEndDrawing?.Invoke();
    }

    public void OnPointerDown(PointerEventData data) {
        if (_reactOnPointerUpAndDown) {
            IsInDrawZone = true;
        }
    }

    public void OnPointerUp(PointerEventData data) {
        if (_reactOnPointerUpAndDown) {
            IsInDrawZone = false;
            if (!HasTouchedZone) HasTouchedZone = true;
            OnEndDrawing?.Invoke();
        }
    }
}
