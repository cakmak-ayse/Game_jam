using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxBackground : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public ParallaxCamera parallaxCamera;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();
    private float initialZ;
    private float initialY;

    void Start()
    {
        initialZ = transform.position.z; // Store the initial Z position
        initialY = transform.position.y; // Store the initial Y position

        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;

        SetLayers();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, initialY, initialZ);
        Vector3 smoothedPosition = Vector3.Lerp(new Vector3(transform.position.x, initialY, initialZ), desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            Vector3 newPos = layer.transform.localPosition;
            newPos.x += delta * layer.parallaxFactor;
            layer.transform.localPosition = newPos;
        }
    }
}
