using UnityEngine;

public abstract class PickableState
{
    public abstract void Switch(Rigidbody rigidbody, Collider collider);
}
