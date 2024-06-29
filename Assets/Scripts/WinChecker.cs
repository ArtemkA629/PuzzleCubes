using System.Linq;
using UnityEngine;

public class WinChecker : MonoBehaviour
{
    [SerializeField] private FirstZoneCubesSpawner _cubeSpawner;
    [SerializeField] private GameObject _winPanel;

    private int[] _occupiedPlacesNumbers;
    private int _currentIndexToAdd;

    private void Awake()
    {
        _occupiedPlacesNumbers = new int[_cubeSpawner.CubesCount];
    }

    public void AddOccupiedPlaceNumber(int placeNumber)
    {
        _occupiedPlacesNumbers[_currentIndexToAdd] = placeNumber;
        if (_currentIndexToAdd == _occupiedPlacesNumbers.Length)
            throw new System.Exception("Invalid currentIndexToAdd");
        _currentIndexToAdd++;
        TryShowWinPanel();
    }

    public void RemoveOccupiedPlaceNumber(int placeNumber)
    {
        if (_currentIndexToAdd == 0)
            throw new System.Exception("Invalid currentIndexToAdd");
        _currentIndexToAdd--;
        _occupiedPlacesNumbers[_currentIndexToAdd] = placeNumber;
    }

    private void TryShowWinPanel()
    {
        foreach (var placeNumber in _occupiedPlacesNumbers)
            if (_cubeSpawner.PlacesNumbers.Contains(placeNumber) == false)
                return;
        _winPanel.SetActive(true);
    }
}
