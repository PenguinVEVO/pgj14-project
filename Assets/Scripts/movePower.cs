using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePower : MonoBehaviour
{
	public GameObject connection;
	public GameObject target;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void move()
	{
		connection.GetComponent<setPowerLevel>().transferLevel(target);
	}
}
