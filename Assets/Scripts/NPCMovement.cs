using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public Vector3 TargetPointToFollow;

    private NPCDeathHandler _deathHandler;

    [SerializeField] private float _followSpeed = 3;

    private void Awake() {
        _deathHandler = GetComponent<NPCDeathHandler>();
    }

    private void Update() {
        FollowTargetPoint();
    }

    private void FollowTargetPoint() {
        if (DrawZoneHandler.Instance.HasTouchedZone && !LineDrawer.Instance.IsDrawing) {
            if (!_deathHandler.IsDead) {
                transform.position = Vector3.MoveTowards(transform.position, TargetPointToFollow, _followSpeed * Time.deltaTime);
            }
        }
    }
}
