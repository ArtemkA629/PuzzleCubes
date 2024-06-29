using Mirror;
using UnityEngine;

public class Pickable : NetworkBehaviour
{
    private static bool _hasPickable;

    [SerializeField] private float _distance = 5f;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;
    [SerializeField] private WinChecker _winChecker;

    private PickableState _state;
    private Transform _pickableObjectTransform;
    private PlaceToPut _occupiedPlace;
    private Quaternion _quaternionAtSart;

    private void Start()
    {
        _quaternionAtSart = transform.localRotation;
        _state = new CubeOnFloorState();
    }

    private void OnMouseDown()
    {
        if (_hasPickable || isClientOnly) 
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!(Physics.Raycast(ray, _distance)) && _state is CubePickedUpState)
            return;

        if (_pickableObjectTransform == null)
            _pickableObjectTransform = GameObject.FindGameObjectWithTag(Tags.PickableObjectPosition).transform;

        if (_state is CubeOnGridState)
        {
            _winChecker.RemoveOccupiedPlaceNumber(_occupiedPlace.PlaceNumberFromUpRight);
            _occupiedPlace.IsOccupied = false;
            _occupiedPlace = null;
        }

        ChangeState(new CubePickedUpState());
        _hasPickable = true;
        _rigidbody.MovePosition(_pickableObjectTransform.position);
    }

    private void FixedUpdate()
    {
        if ((_state is CubePickedUpState) == false || isClientOnly)
            return;

        transform.position = _pickableObjectTransform.position;

        if (Input.GetKey(KeyCode.G))
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, _distance)
                && hit.transform.TryGetComponent(out PlaceToPut place))
            {
                if (place.IsOccupied)
                    return;

                var hitPosition = hit.transform.position;
                transform.position = new Vector3(hitPosition.x, transform.position.y, hitPosition.z);
                transform.rotation = _quaternionAtSart;

                place.IsOccupied = true;
                _occupiedPlace = place;

                ChangeState(new CubeOnGridState());
                _winChecker.AddOccupiedPlaceNumber(_occupiedPlace.PlaceNumberFromUpRight);
            }

            ChangeState(new CubeOnFloorState());
            _hasPickable = false;
        }
    }

    private void ChangeState(PickableState state)
    {
        _state = state;
        _state.Switch(_rigidbody, _collider);
    }
}
