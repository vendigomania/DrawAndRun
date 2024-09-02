using System.Linq;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public List<Vector2> LinePoints = new List<Vector2>();

    [SerializeField] private LineRenderer _targetLine;

    private Vector3 _startTouchPosition = Vector2.zero;

    public static LineDrawer Instance;

    public Vector3 CurrentTouchPosition { get; private set; } = Vector3.zero;

    [SerializeField] private Vector3 _offset;

    public UnityEvent OnNewPointAdded;

    [field: SerializeField]
    public bool IsDrawing { get; private set; } = false;

    private float _zDistanceFromCamera = 1;

    [SerializeField] private float _maximalDeltaBetweenPoint;

    private void Awake() {
        Instance = this;
        ResetLine();
    }

    private void ResetLine() {
        for (int i = 0; i < _targetLine.positionCount; i++) {
            _targetLine.SetPosition(i, Vector3.zero);
        }
        LinePoints.Clear();
        IsDrawing = false;
        UpdateLine();
    }

    private void Update() {
        WaitForTap();
        TryToContinueDrawing();
    }

    private void WaitForTap() {
        if(Input.touchCount > 0) {
            if (DrawZoneHandler.Instance.IsInDrawZone) {
                Touch currentTouch = Input.GetTouch(0);
                CurrentTouchPosition = Camera.main.ScreenToWorldPoint(new Vector3(currentTouch.position.x, currentTouch.position.y, _zDistanceFromCamera));
                if (currentTouch.phase == TouchPhase.Began) {
                    _startTouchPosition = currentTouch.position;
                    AddLinePoint(_startTouchPosition);
                    IsDrawing = true;
                }
                else if (currentTouch.phase == TouchPhase.Ended) {
                    ResetLine();
                }
            }
            else ResetLine();
        }
    }

    private void TryToContinueDrawing() {
        if (IsDrawing) {
            if (Vector2.Distance(LinePoints.Last(), CurrentTouchPosition) > _maximalDeltaBetweenPoint) AddLinePointPrepared(CurrentTouchPosition);
        }
    }

    private void AddLinePoint(Vector2 rawInput) {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(rawInput.x, rawInput.y, _zDistanceFromCamera));
        LinePoints.Add(worldPosition);
        OnNewPointAdded?.Invoke();
        UpdateLine();
    }

    private void AddLinePointPrepared(Vector2 resultInput) {
        LinePoints.Add(resultInput);
        OnNewPointAdded?.Invoke();
        UpdateLine();
    }

    private void UpdateLine() {
        _targetLine.positionCount = LinePoints.Count;
        for (int i = 0; i < _targetLine.positionCount; i++) {
            _targetLine.SetPosition(i, new Vector3(LinePoints[i].x, LinePoints[i].y, Camera.main.transform.position.z) + _offset);
        }
    }
}
