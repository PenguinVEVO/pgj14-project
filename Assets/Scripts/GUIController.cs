using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System; 
using System.IO; 
using System.Text; 

public class GUIController : MonoBehaviour
{
	public Texture2D crosshairTexture;
    public float crosshairScale = 1;
	public GameObject progressBar;
	private mainControllerScript mainController;
	public GameObject randomsystext;
	private List<string> randText = new List<string>();
	
    // Start is called before the first frame update
    void Start()
    {
		mainController = GameObject.Find("FED").GetComponent<mainControllerScript>();
		const int BufferSize = 128;
		using (var fileStream = File.OpenRead(Application.dataPath + "/Prefabs/RANDOMCOMPUTER.TXT"))
		{
			using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize)) 
			{
				String line;
				while ((line = streamReader.ReadLine()) != null)
				{
				  randText.Add(line);
				}
			}
		}
        StartCoroutine(progressFill());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
    void OnGUI()
    {
        //if not paused
        if(Time.timeScale != 0)
        {
        	if(crosshairTexture!=null)
				GUI.DrawTexture(new Rect((Screen.width-crosshairTexture.width*crosshairScale)/2 ,(Screen.height-crosshairTexture.height*crosshairScale)/2, crosshairTexture.width*crosshairScale, crosshairTexture.height*crosshairScale),crosshairTexture);
        }
    }
	
	IEnumerator progressFill()
	{
		int count = 0;
		
		while (count < 1500)
		{
			yield return new WaitForSeconds (1);
			count++;
			progressBar.GetComponent<UnityEngine.UI.Image>().fillAmount = count/1500.0f;
			int x = UnityEngine.Random.Range(0, randText.Count - 1);
			string target = randText[x];
			randomsystext.GetComponent<TextMeshProUGUI>().text = target;
			
		}
		
		mainController.unlockCommand();
	}
	
	public void qt()
	{
		Application.Quit();
	}
	
	public void st()
	{
		SceneManager.LoadScene("mainStage", LoadSceneMode.Single);
	}
}
