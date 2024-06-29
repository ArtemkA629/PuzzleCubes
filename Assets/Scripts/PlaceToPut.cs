using UnityEngine;

public class PlaceToPut : MonoBehaviour
{
    [SerializeField] private int _placeNumberFromUpRight;

    private bool _isOccupied;

    public bool IsOccupied { get { return _isOccupied; } set { _isOccupied = value; } }
    public int PlaceNumberFromUpRight => _placeNumberFromUpRight;
}
