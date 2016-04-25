using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody _rigidbody;
    private float xInput;
    private float yInput;
    


    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    
void Update()
    {

        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 adjustedHeightPoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(adjustedHeightPoint);
        }

    }



    // Use this for initialization
    void FixedUpdate ()
    {
        Vector3 direction = new Vector3(xInput, 0f, yInput);
         Vector3 velocity = direction.normalized * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + velocity);
        
	}
	
	
	
}
