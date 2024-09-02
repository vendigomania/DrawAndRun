using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class NPCAnimatorHandler : MonoBehaviour
{
    private Animator _animator;

    private bool _enteredRunningState = false;

    private string _runningBoolName = "IsRunning";

    private string _victoryBoolName = "Victory";

    public bool _turnRunningOnGameStart;

    private void Awake() {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate() {
        TryToEnterRunningState();
        TryToEnterVictoryState();
    }

    private void TryToEnterRunningState() {
        if (_turnRunningOnGameStart && !EndOfTripHandler.Instance.IsReachedTheDestination) {
            if (DrawZoneHandler.Instance.HasTouchedZone && !_enteredRunningState) {
                TurnBool(_runningBoolName, true);
                _enteredRunningState = true;
            }
        }
    }

    private void TryToEnterVictoryState() {
        if (EndOfTripHandler.Instance.IsReachedTheDestination) {
            TurnBool(_victoryBoolName, true);
        }
    }

    public void TurnBool(string name, bool state) => _animator.SetBool(name, state);
}
