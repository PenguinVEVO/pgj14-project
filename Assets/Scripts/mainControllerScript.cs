using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainControllerScript : MonoBehaviour
{
	private bool puzzleAflag = false;
	private bool puzzleBflag = false;
	private bool endingAflag = false;
	private bool endingBflag = false;
	private bool commandRoomUnlockedFlag = false;
	private bool puzzleARoomInfestedFlag = false;
	private bool puzzleBRoomInfestedFlag = false;
	private bool itemARoomInfestedFlag = false;
	private bool itemBRoomInfestedFlag = false;
	private bool centralCommandUnlocked = false;
	private bool rebreatherFlag = false;
	private bool powerOnFlag = false;
	private bool airlockCanBeUnlocked = false;
	private bool suitRoomClear = false;
	
	private GameObject[] ceilLightUnlit;
	private GameObject[] ceilLightLit;
	private GameObject[] redLightUnlit;
	private GameObject[] redLightLit;
	
	public GameObject litRed;
	public GameObject litCeil;
	
    // Start is called before the first frame update
    void Start()
    {
        ceilLightUnlit = GameObject.FindGameObjectsWithTag("ceilUnlit");
		redLightUnlit = GameObject.FindGameObjectsWithTag("redUnlit");
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void onPuzzleAComplete()
	{
		for (int i = 0; i < ceilLightUnlit.Length; i++)
		{
			GameObject newObject;
			newObject = (GameObject)Instantiate(litCeil, ceilLightUnlit[i].transform.position, ceilLightUnlit[i].transform.rotation);

			DestroyImmediate(ceilLightUnlit[i]);
		}
		
		for (int i = 0; i < redLightUnlit.Length; i++)
		{
			GameObject newObject;
			newObject = (GameObject)Instantiate(litCeil, redLightUnlit[i].transform.position, redLightUnlit[i].transform.rotation);

			DestroyImmediate(redLightUnlit[i]);
		}
		
		puzzleAflag = true;
	}
	
	public void onPuzzleBComplete()
	{
		puzzleBflag = true;
	}
	
	public void unlockCommand()
	{
		centralCommandUnlocked = true;
	}

}
