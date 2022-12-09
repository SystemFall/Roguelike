using UnityEngine;

public class PlayerMoveControl : IMoveControl
{
    public float inputHorizontal => Input.GetAxisRaw("Horizontal");

    public float inputVertical => Input.GetAxisRaw("Vertical");
}