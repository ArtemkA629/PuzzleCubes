using UnityEngine;

public class CubeOnGridState : PickableState
{
    public override void Switch(Rigidbody rigidbody, Collider collider)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        rigidbody.useGravity = true;
        collider.isTrigger = false;
        rigidbody.isKinematic = false;
    }
}
