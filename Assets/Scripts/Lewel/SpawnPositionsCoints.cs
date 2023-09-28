using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionsCoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _positionSpawm;

    public Transform[] GetPositions() => _positionSpawm.ToArray();
}
