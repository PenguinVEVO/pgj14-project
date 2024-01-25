using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class puzzleBController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnCollisionEnter(Collision collision)
    {
        if((bool)Variables.Object(collision.gameObject).Get("Power"))
		{
			Variables.Object(transform.parent.gameObject).Set("Power", true);
		}
    }
	
	void OnCollisionExit(Collision collision)
    {
        if((bool)Variables.Object(collision.gameObject).Get("Power"))
		{
			Variables.Object(transform.parent.gameObject).Set("Power", false);
		}
    }
	
}
