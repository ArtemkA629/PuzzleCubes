using System.Linq;
using UnityEngine;
using Mirror;

public class FirstZoneCubesSpawner : NetworkBehaviour
{
    [SerializeField] private Transform[] _transformsToSpawn;
    [SerializeField] private Transform _cubePrefab;
    [SerializeField] private int _cubesCount = 5;

    private int[] _placesNumbers;

    public int CubesCount => _cubesCount;
    public int[] PlacesNumbers => _placesNumbers;

    private void Start()
    {
        if (isServer == false)
            return;

        _placesNumbers = new int[_cubesCount];

        for (int i = 0; i < _cubesCount; i++)
        {
            int newNumber = Random.Range(1, _transformsToSpawn.Length + 1);
            while (_placesNumbers.Contains(newNumber))
                newNumber = Random.Range(1, _transformsToSpawn.Length + 1);
            _placesNumbers[i] = newNumber;
            var randomPositionToSpawn = _transformsToSpawn[newNumber - 1].position;
            Spawn(_transformsToSpawn[newNumber - 1].position);
        }
    }

    private void Spawn(Vector3 randomPositionToSpawn)
    {
        var cube = Instantiate(_cubePrefab, new Vector3(randomPositionToSpawn.x, _cubePrefab.position.y, randomPositionToSpawn.z), 
            Quaternion.identity);
        NetworkServer.Spawn(cube.gameObject);
    }
}
