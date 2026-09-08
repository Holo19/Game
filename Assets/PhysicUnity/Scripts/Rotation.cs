using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _speedRotation;

    private int _firstSide = 1;
    private int _secondSide = -1;

    private int _currentSide;

    private void Awake()
    {
        _currentSide = DetermineSideRotation();   
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * _currentSide * _speedRotation *  Time.deltaTime);
    }

    private int DetermineSideRotation()
    {
        int random = Random.Range(0, 2);

        return random == 0 ? _firstSide : _secondSide;
    }
}
