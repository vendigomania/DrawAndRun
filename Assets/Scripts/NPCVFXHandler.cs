using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVFXHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _VFXs;

    public void TurnVFX(int index) {
        ParticleSystem newvfx = Instantiate(_VFXs[index], transform.position, Quaternion.identity);
        newvfx.Play(true);
    }
}
