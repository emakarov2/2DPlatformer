using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Flipper : MonoBehaviour
{
    private Quaternion _defaultRotation = Quaternion.identity;
    private Quaternion _rotatedByY = Quaternion.Euler(0f, 180f, 0f);

    public void SetRotation(bool isOrientDefault)
    {
        transform.rotation = isOrientDefault ? _defaultRotation : _rotatedByY;
    }
}