using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToObject : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] Vector3 _offset;

    private void LateUpdate()
    {
        transform.position = _target.transform.position + _offset;
    }
}
