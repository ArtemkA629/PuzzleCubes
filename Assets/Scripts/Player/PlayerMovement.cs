using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed = 5f;

    public void Move(Transform transform)
    {
        float horizontalInput = Input.GetAxis(AxisConstants.Horizontal);
        float verticalInput = Input.GetAxis(AxisConstants.Vertical);
        var moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(_speed * Time.deltaTime * moveDirection);
    }
}