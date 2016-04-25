
using UnityEngine;
using System.Collections;


namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class enemySight : MonoBehaviour
    {

        public NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public enum State
        {
            PATROL,
            CHASE,
            INVESTIGATE
        }

        public State state;
        private bool alive;

        // variables for patrolling
        public GameObject[] waypoints;
        private int waypointInd;
        public float patrolSpeed = 0.5f;

        //variables for chasing

        public float chaseSpeed = 1f;
        public GameObject target;

        //variables for Inv

        private Vector3 investigateSpot;
        private float timer = 0;
        public float investigateWaits = 10;

        //variables for seight
        public float heightMultiplier;
        public float sightDist = 10;

        void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updatePosition = true;
            agent.updateRotation = false;

            state = enemySight.State.PATROL;

            alive = true;

            heightMultiplier = 1.36f;

            StartCoroutine("FSM");


        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
                {
                    case State.PATROL:
                        Patrol();
                        break;
                    case State.CHASE:
                        Chase();
                        break;
                    case State.INVESTIGATE:
                        Investigate();
                        break;
                }
                yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move (agent.desiredVelocity, false, false);
            }
            else if (Vector3.Distance(this.transform.position, waypoints[waypointInd].transform.position) <= 2)
            {
                waypointInd += 1;
                if (waypointInd >= waypoints.Length)
                {
                    waypointInd = 0;
                }


            }

            else
            {
                character.Move(Vector3.zero, false, false);
            }
        }

        void Chase()
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);

        }

        void Investigate()
        {
            timer += Time.deltaTime;
            RaycastHit hit;
            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, transform.forward * sightDist, Color.green);
            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right). normalized * sightDist, Color.green);
            Debug.DrawRay(transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized * sightDist, Color.green);
            if (Physics.Raycast (transform.position + Vector3.up * heightMultiplier, transform.forward, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "player1")
                {
                    state = enemySight.State.CHASE;
                    target = hit.collider.gameObject;
                }
            }

            if (Physics.Raycast(transform.position + Vector3.up * heightMultiplier, (transform.forward + transform.right).normalized, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "player1")
                {
                    state = enemySight.State.CHASE;
                    target = hit.collider.gameObject;
                }
            }

            if (Physics.Raycast (transform.position + Vector3.up * heightMultiplier, (transform.forward - transform.right).normalized, out hit, sightDist))
            {
                if (hit.collider.gameObject.tag == "player1")
                {
                    state = enemySight.State.CHASE;
                    target = hit.collider.gameObject;
                }
            }

            agent.SetDestination(this.transform.position);
            character.Move(Vector3.zero, false, false);
            transform.LookAt(investigateSpot);
            if (timer >= investigateWaits)
            {
                state = enemySight.State.PATROL;
                timer = 0;
            }
        }

        void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "player1")
            {
                state = enemySight.State.INVESTIGATE;
                investigateSpot = coll.gameObject.transform.position;
            }
        }
    }


}
