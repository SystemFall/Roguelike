using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    private Animator _animator;

    public static Action<Player> OnPlayerCreating;

    public void Start()
    {
        _animator = GetComponent<Animator>();

        OnPlayerCreating?.Invoke(this);
    }

    public enum PlayerState
    {
        idle,
        movement
    }

    public enum PlayerAction
    {
        no,
        dash,
        meleeAttack
    }

    public PlayerState _playerState = PlayerState.idle;
    public PlayerAction _playerAction = PlayerAction.no;

    public void ChangeState(PlayerState state)
    {
        if(_playerState != state)
        {
            _playerState = state;
            Debug.Log(state);
            switch(state)
            {
                case PlayerState.idle:
                    _animator.SetBool("movement", false);
                    break;
                case PlayerState.movement:
                    _animator.SetBool("movement", true);
                    break;
            }
        }
    }

    public void TriggerAction(PlayerAction action)
    {
        switch(action)
        {
            case PlayerAction.dash:
                _animator.SetTrigger("dash");
                break;
            case PlayerAction.meleeAttack:

                break;
        }
    }
}
