using UnityEngine;

public class CubePickedUpState : PickableState
{
    public override void Switch(Rigidbody rigidbody, Collider collider)
    {
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        rigidbody.constraints = RigidbodyConstraints.None;
        collider.isTrigger = true;
    }
}
