using UnityEngine;
using System.Collections;

public class aiEasy : MonoBehaviour {


    public float fpsTargetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float damping;
    public Transform fpsTarget;
    Rigidbody theRigidBody;
    Renderer myRender;




    void Start()
    {
        myRender = GetComponent<Renderer>();
        theRigidBody = GetComponent<Rigidbody>();



    }


    void FixedUpdate()
    {

        fpsTargetDistance = Vector3.Distance(fpsTarget.position, transform.position);
        if (fpsTargetDistance < enemyLookDistance)
        {
            myRender.material.color = Color.yellow;
            lookAtPlayer();
            //print("look ar player pleae");
        }

        if (fpsTargetDistance < attackDistance)
        {
            attackPlease();
            myRender.material.color = Color.red;
            //print("Attack!!");
        }
        else
        {
            myRender.material.color = Color.blue;
        }

    }

    void lookAtPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(fpsTarget.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation, Time.deltaTime * damping);


    }


    void attackPlease()
    {
        theRigidBody.AddForce(transform.forward*enemyMovementSpeed);
    }


}