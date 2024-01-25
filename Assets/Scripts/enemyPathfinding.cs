using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPathfinding : MonoBehaviour
{
	private Rigidbody target;
	private UnityEngine.AI.NavMeshAgent agent;
	
	public void setTarget(Rigidbody x)
	{
		target = x;
	}
	
	public Rigidbody getTarget()
	{
		return target;
	}
	
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.speed = 0.5F;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}
