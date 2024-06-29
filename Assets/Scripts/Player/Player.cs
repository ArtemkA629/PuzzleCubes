using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    private void Update()
    {
        if (isLocalPlayer == false)
            return;
        _movement.Move(transform);
    }
}
