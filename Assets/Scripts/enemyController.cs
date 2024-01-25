using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
	private List<GameObject> targets = new List<GameObject>();
	
    // Start is called before the first frame update
    void Start()
    {
        targets.Add(GameObject.FindGameObjectWithTag("Player"));
		targets.AddRange(GameObject.FindGameObjectsWithTag("Targetable"));
		
		foreach(Transform child in this.transform)
		{
			int x = Random.Range(0, targets.Count - 1);
			GameObject target = targets[x];
			targets.RemoveAt(x);
			
			
			child.gameObject.GetComponent<enemyPathfinding>().setTarget(target.GetComponent<Rigidbody>());
		}
    }

    // Update is called once per frame
    void Update()
    {
		
    }
}
