using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //gets movement vector
    public void Move (Vector3 _velocity)
    {
        velocity = _velocity;
    }

    //gets rotation vector
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    //**
    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    //run physics iteration
    void FixedUpdate ()
    {
        PerformMovement();
        PerformRotation();
    }

    //perform movement based on velocity variable
    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler (rotation));
        }

    }

    //perform rotation
    void PerformRotation()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (cam != null)
        {
            cam.transform.Rotate(cameraRotation);
        }
    }



}
