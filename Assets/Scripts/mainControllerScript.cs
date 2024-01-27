using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System; 
using System.IO; 
using System.Text;

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
	public GameObject dialogue;
	public Camera boom;
	public Camera main;
	public GameObject player;
	public GameObject explode;
	
	private List<string> AIDial = new List<string>();
	
    // Start is called before the first frame update
    void Start()
    {
		dialogue.GetComponent<TextMeshProUGUI>().text = "";
		const int BufferSize = 128;
		using (var fileStream = File.OpenRead(Application.dataPath + "/Prefabs/AIDIALOGUE.TXT"))
		{
			using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) 
			{
				String line;
				while ((line = streamReader.ReadLine()) != null)
				{
				  AIDial.Add(line);
				}
			}
		}
		
		StartCoroutine(displayText(1));
		
        ceilLightUnlit = GameObject.FindGameObjectsWithTag("ceilUnlit");
		redLightUnlit = GameObject.FindGameObjectsWithTag("redUnlit");

    }
	
	IEnumerator displayText(int index)
	{
		int count = 0;
		dialogue.GetComponent<TextMeshProUGUI>().text = "";
		while (count < AIDial[index].Length)
		{
			yield return new WaitForSeconds (0.1f);
			dialogue.GetComponent<TextMeshProUGUI>().text += AIDial[index][count];
			count++;		
		}
		
		yield return new WaitForSeconds (3);
		dialogue.GetComponent<TextMeshProUGUI>().text = "";

	}	
	
	IEnumerator loadNext()
	{
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene("GNOME", LoadSceneMode.Additive);
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
		
		StartCoroutine(displayText(7));
		DestroyImmediate(player.GetComponent<PlayerMovement>());
		main.gameObject.SetActive(false);
		boom.gameObject.SetActive(true);
		explode.SetActive(true);
		StartCoroutine(loadNext());
	}
	
	public void onPuzzleBComplete()
	{
		puzzleBflag = true;
	}
	
	public void unlockCommand()
	{
		centralCommandUnlocked = true;
		StartCoroutine(displayText(2));
	}
	
	public void warnPlayer()
	{
		StartCoroutine(displayText(6));
	}

}
