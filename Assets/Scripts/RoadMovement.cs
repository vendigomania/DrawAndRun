using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 3;

    private void Update() => MoveRoadBackwards();

    private void MoveRoadBackwards() {
        if(DrawZoneHandler.Instance.HasTouchedZone && !EndOfTripHandler.Instance.IsReachedTheDestination) {
            transform.Translate(-transform.forward * _movementSpeed * Time.deltaTime, Space.World);
        }
    }

    public void Stop() => _movementSpeed = 0;
}
