using UnityEngine;
using System.Collections;

public class TopDownCamera : MonoBehaviour
{

    public Transform target;


    [System.Serializable]
    public class PositionSettings
    {
        public float distanceFromTarget = -50;
        public bool allowZoom = true;
        public float zoomSmooth = 100;
        public float zoomStep = 2;
        public float maxZoom = -30;
        public float MinZoom = -60;
        public bool smoothFollow = true;
        public float smooth = 0.05f;

        [HideInInspector]
        public float newDistance = -50;
    }

    [System.Serializable]
    public class OrbitSettings
    {
        public float xRotation = -65;
        public float yRotation = -180;
        public bool allowOrbit = true;
        public float yOrbitSmooth = 0.05f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public string MOUSE_ORBIT = "MouseOrbit";
        public string ZOOM = "Mouse ScrollWheel";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();

    Vector3 destination = Vector3.zero;
    Vector3 camVelocity = Vector3.zero;
    
    float mouseOrbitInput, zoomInput;

    void start()
    {
        SetCameraTarget(target);

        if (target)
        {
            MoveToTarget();
        }
    }

    public void SetCameraTarget(Transform t)
    {
        target = t;

        if (target== null)
        {
            Debug.LogError("your camera needs a target");
        }
    }

    void GetInput()
    {
        mouseOrbitInput = Input.GetAxisRaw(input.MOUSE_ORBIT);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
    }

    void Update()
    {
        GetInput();
        if (position.allowZoom)
        {
            ZoomInOnTarget();
        }
    }

    void FixedUpdate()
    {
        if (target)
        {
            MoveToTarget();
            LookAtTarget();
            MouseOrbitTarget();
        }
    }


    void MoveToTarget()
    {
        destination = target.position;
        destination += Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;

        if (position.smoothFollow)
        {
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVelocity, position.smooth);
        }
        else
            transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = targetRotation;
    }

    void MouseOrbitTarget()
    {

    }

    void ZoomInOnTarget()
    {
        position.newDistance += position.zoomStep * zoomInput;

        position.distanceFromTarget = Mathf.Lerp(position.distanceFromTarget, position.newDistance, position.zoomSmooth * Time.deltaTime);

        if (position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom;
            position.newDistance = position.maxZoom;
        }

        if (position.distanceFromTarget < position.MinZoom)
        {
            position.distanceFromTarget = position.MinZoom;
            position.newDistance = position.MinZoom;
        }
    }
}

