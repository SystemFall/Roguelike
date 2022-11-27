using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _distanceToPlayer;

    private void Update()
    {
        transform.position = _player.position + _distanceToPlayer;
    }
}
