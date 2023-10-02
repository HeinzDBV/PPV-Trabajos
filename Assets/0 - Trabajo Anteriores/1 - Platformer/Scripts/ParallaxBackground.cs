using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Transform myCam;

    [System.Serializable]
    public struct ParallaxLayer
    {
        public Transform layerTransform; // The transform of the background layer.
        public float parallaxSpeed;     // The speed at which the layer should move.
    }

    public ParallaxLayer[] layers;      // Array of background layers.

    private Vector3 previousCameraPosition;

    private void Start()
    {
        // Initialize the previous camera position.
        previousCameraPosition = myCam.position;
    }

    private void LateUpdate()
    {
        Vector3 cameraDelta = myCam.position - previousCameraPosition;

        foreach (ParallaxLayer layer in layers)
        {
            // Calculate the parallax offset for this layer.
            Vector3 parallaxOffset = cameraDelta * layer.parallaxSpeed;

            // Move the layer by the parallax offset.
            layer.layerTransform.position += parallaxOffset;

            // Update the previous camera position.
            previousCameraPosition = myCam.position;
        }
    }
} 
