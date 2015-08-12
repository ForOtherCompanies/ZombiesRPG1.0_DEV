using UnityEngine;
using System.Collections;

public class UnitControlAgent : MonoBehaviour {

	//keep public 
	//public Transform goal;
	public NavMeshAgent agent;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
		//agent.SetDestination (goal.position);
		
	}

	public void SetTarget (Vector3 newTarget){
		
		//goal.transform.position = newTarget;
		//agent.SetDestination (newTarget);
		
		agent.SetDestination(newTarget);
	}
}
