using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleAController : MonoBehaviour
{
	private GameObject tankA;
	private GameObject tankB;
	private GameObject[] buttons;
	private bool puzzleAComplete = false;
	private mainControllerScript mainController;
    // Start is called before the first frame update
    void Start()
    {
        tankA = GameObject.Find("PuzzleA_A");
        tankB = GameObject.Find("PuzzleA_B");
		buttons = GameObject.FindGameObjectsWithTag("PuzzleAButton");
		mainController = GameObject.Find("FED").GetComponent<mainControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tankA.GetComponent<setPowerLevel>().numLevel == tankB.GetComponent<setPowerLevel>().numLevel && !puzzleAComplete)
		{
			foreach(GameObject button in buttons)
			{
				button.GetComponent<SphereCollider>().enabled = false;
			}
			
			puzzleAComplete = true;
			mainController.onPuzzleAComplete();
		}
    }
}
