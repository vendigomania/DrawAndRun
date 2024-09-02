using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCPlacer : MonoBehaviour
{
    public List<Vector3> NPCPositions = new List<Vector3>();

    public List<NPCMovement> NPCs = new List<NPCMovement>();

    [SerializeField] private LineDrawer _lineDrawer;

    [SerializeField] private Vector3 _offset;

    public static NPCPlacer Instance;

    private void Awake() {
        Instance = this;
    }

    private float _rayLength = 1000;

    public void RegisterNewPosition() {
        Vector3 input = Camera.main.WorldToScreenPoint(_lineDrawer.CurrentTouchPosition);
        Ray ray = Camera.main.ScreenPointToRay(input);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayLength)) {
            NPCPositions.Add(new Vector3(hit.point.x, hit.point.y, hit.point.z + Camera.main.transform.position.z));
        }
    }

    public void CleanAllPositions(){
        NPCPositions.Clear();
        MainCounter.Instance.CheckPeopleCount();    
    }

    public void PlaceAllNPCs() {
        for (int i = 0; i < NPCs.Count; i++) {
            try {
                if (!NPCs[i].enabled) NPCs[i].enabled = true;

                if (i < NPCPositions.Count) {
                    NPCs[i].TargetPointToFollow = NPCPositions[i] + _offset;
                    continue;
                }
                NPCs[i].TargetPointToFollow = NPCPositions[NPCPositions.Count - 1] + _offset;
            }
            catch { }
        }
    }
}
