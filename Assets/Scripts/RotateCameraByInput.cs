using Mirror;
using UnityEngine;

public class RotateCameraByInput : NetworkBehaviour
{
    private static float _clampRotation = 90f;

    [SerializeField] private Transform _target;
    [SerializeField] private float _rotateSpeed = 5f;

    private Vector3 _offset;
    private float _xRotation;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        if (isLocalPlayer == false)
        {
            gameObject.SetActive(false);
            return;
        }

        float mouseX = Input.GetAxis(AxisConstants.MouseX) * _rotateSpeed;
        float mouseY = Input.GetAxis(AxisConstants.MouseY) * _rotateSpeed;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_clampRotation, _clampRotation);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _target.Rotate(Vector3.up * mouseX);
    }
}
