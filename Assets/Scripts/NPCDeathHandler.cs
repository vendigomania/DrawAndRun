using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDeathHandler : MonoBehaviour
{
    private SkinnedMeshRenderer _meshRenderer;

    public bool IsDead { get; private set; } = false;

    private NPCVFXHandler _vfxHandler;

    private string _obstacleTag = "Obstacle";

    private void Awake() {
        _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _vfxHandler = GetComponent<NPCVFXHandler>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == _obstacleTag) {
            Die();
        }
    }

    public void Die() {
        if (!IsDead) {
            StopNPC();
            HideNPC();
            IsDead = true;
            _vfxHandler.TurnVFX(0);
            AudioMynager.Instance.Wrong();

        }
    }

    private void StopNPC() {
        transform.parent = null;
    }

    private void HideNPC() {
        _meshRenderer.enabled = false;
        MainCounter.Instance.CheckPeopleCount();
    }
}
