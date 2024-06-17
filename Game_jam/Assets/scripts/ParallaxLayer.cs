using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public float parallaxFactor;
    private float initialZ;
    private float initialY;

    void Start()
    {
        initialZ = transform.localPosition.z; // Store the initial Z position
        initialY = transform.localPosition.y; // Store the initial Y position
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, initialY, initialZ);
        Vector3 smoothedPosition = Vector3.Lerp(new Vector3(transform.localPosition.x, initialY, initialZ), desiredPosition, smoothSpeed);
        transform.localPosition = smoothedPosition;
    }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;
        transform.localPosition = newPos;
    }
}
