using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(IMoveControl))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigid;
    private IMoveControl _moveControl;
    private Vector3 _direction;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _moveControl = GetComponent<IMoveControl>();
    }

    private void Move()
    {
        _direction = new Vector3(_moveControl.inputHorizontal, _rigid.velocity.y, _moveControl.inputVertical).normalized;

        _rigid.velocity = _direction * _speed;

        Rotate();
    }

    private void Rotate()
    {
        if (_direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.fixedDeltaTime * _turningSpeed);
        }
    }
}
