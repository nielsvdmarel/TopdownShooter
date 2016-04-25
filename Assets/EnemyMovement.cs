using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{

    private NavMeshAgent _navMeshAgent;
    private GameObject _playerObj;

    void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _navMeshAgent.SetDestination(_playerObj.transform.position);
    }

}