using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAddHandler : MonoBehaviour
{
    [SerializeField] private Material _workingMaterial;

    private SkinnedMeshRenderer _skinnedMeshRenderer;

    private NPCAnimatorHandler _animatorHandler;

    private NPCVFXHandler _vfxHandler;

    private NPCMovement _npcMovement;

    private void Awake() {
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        _npcMovement = GetComponent<NPCMovement>();
        _animatorHandler = GetComponent<NPCAnimatorHandler>();
        _vfxHandler = GetComponent<NPCVFXHandler>();
    }

    private string _npcTag = "NPC";

    private void OnTriggerEnter(Collider other) {
        if(other.tag == _npcTag) {
            ConnectToRoot(other);
        }
    }

    private void ConnectToRoot(Collider other) {
        if(transform.parent != other.transform.parent) {
            transform.parent = other.transform.parent;
            SetupNPC();
        }
    }

    private void SetupNPC() {
        _skinnedMeshRenderer.material = _workingMaterial;
        NPCPlacer.Instance.NPCs.Add(_npcMovement);
        _animatorHandler._turnRunningOnGameStart = true;
        _vfxHandler.TurnVFX(1);

        AudioMynager.Instance.Right();

        enabled = false;
    }
}
