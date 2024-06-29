using UnityEngine;

public class CubeOnFloorState : PickableState
{
    public override void Switch(Rigidbody rigidbody, Collider collider)
    {
        rigidbody.useGravity = true;
        collider.isTrigger = false;
        rigidbody.isKinematic = false;
    }
}
