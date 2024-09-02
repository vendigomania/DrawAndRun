using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotationAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 _angleToRotate;

    private void Update() => Rotate();

    private void Rotate() {
        transform.Rotate(_angleToRotate * Time.deltaTime, Space.World);
    }
}
