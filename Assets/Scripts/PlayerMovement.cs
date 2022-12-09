using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : Movement
{
    [SerializeField] private GameObject _dashEffect;

    private Rigidbody _rigid;
    private Player _player;

    private float _speed = 3;
    private float _turningSpeed = 4;
    private float _initialDashForce = 4;
    private float _dashDuration = .16f;
    private float _dashCooldown = .6f;

    private float _currentDashForce = 1;

    private bool _isDashAvailable = true;

    private Vector3 _direction;
    private Coroutine _dashCoroutine;

    public void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
    }

    private void Move()
    {
        _direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if(_direction != Vector3.zero)
        {
            _direction = Quaternion.AngleAxis(45, Vector3.up) * _direction;

            if (Input.GetButtonDown("Jump") && _dashCoroutine == null && _isDashAvailable)
            {
                _currentDashForce = _initialDashForce;
                _isDashAvailable = false;
                _player.TriggerAction(Player.PlayerAction.dash);
                
                _dashCoroutine = StartCoroutine(DashDuration());
                StartCoroutine(DashCooldown());
            }

            _player.ChangeState(Player.PlayerState.movement);
        }
        else
        {
            _player.ChangeState(Player.PlayerState.idle);
        }
    }

    private IEnumerator DashDuration()
    {
        yield return new WaitForSeconds(_dashDuration);
        _currentDashForce = 1;
        _dashCoroutine = null;
    }

    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(_dashCooldown);
        _isDashAvailable = true;
    }
}