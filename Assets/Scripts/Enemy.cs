using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }


    void Update()
    {
        if (!PlayerMovement._hide)
        {
            if (_target != null)
            {
                if (Vector3.Distance(_target.position, transform.position) < 10f)
                {
                    agent.SetDestination(_target.position);
                }
            }
        }
        else
        {
            agent.Stop();
        }
    }

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
