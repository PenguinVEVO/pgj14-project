using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class puzzleBController : MonoBehaviour
{
	public GameObject connectedTile;
	private GameObject goal;
	private mainControllerScript mainController;
	public bool puzzleBComplete = false;
	
    // Start is called before the first frame update
    void Start()
    {
        connectedTile.SetActive(false);
		goal = GameObject.Find("PuzzleBGoal");
		mainController = GameObject.Find("FED").GetComponent<mainControllerScript>();
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
			connectedTile.SetActive(true);
			
			if(gameObject == goal)
			{
				puzzleBComplete = true;
				mainController.onPuzzleBComplete();
			}
			
		}
    }
	
	void OnCollisionExit(Collision collision)
    {
        if((bool)Variables.Object(collision.gameObject).Get("Power"))
		{
			Variables.Object(transform.parent.gameObject).Set("Power", false);
			connectedTile.SetActive(false);
		}
    }
	
	void rotate()
	{
		if (!puzzleBComplete)
		{
			gameObject.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
		}
		//gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, Quaternion.LookRotation(new Vector3(0.0f, 90.0f, 0.0f), Vector3.up), 0.1f);
	}
	
}
