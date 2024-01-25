using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setPowerLevel : MonoBehaviour
{
	public float level;
	public float cap = 100;
	
    // Start is called before the first frame update
    void Start()
    {
        int numLeds = (int)	Mathf.Floor((level/cap) * 3.0F);
		for (int i = 1; i < numLeds+1; i++)
		{
			gameObject.transform.Find(i.ToString()).gameObject.SetActive(true);
			gameObject.transform.Find(i.ToString() + "NG").gameObject.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void transferLevel(GameObject target)
	{
		int amount = (int)(target.GetComponent<setPowerLevel>().cap - target.GetComponent<setPowerLevel>().level);
		Debug.Log(level - Mathf.Max(0, (level - amount)));
		target.GetComponent<setPowerLevel>().level += level - Mathf.Max(0, (level - amount));
		this.level = Mathf.Max(0, this.level - amount);
		target.GetComponent<setPowerLevel>().setLed();
		this.setLed();
	}
	
	public void setLed()
	{
		int numLeds = (int)	Mathf.Floor((level/cap) * 3.0F);
		
		for (int i = 1; i < 4; i++)
		{
			gameObject.transform.Find(i.ToString()).gameObject.SetActive(false);
			gameObject.transform.Find(i.ToString() + "NG").gameObject.SetActive(true);
		}
		
		for (int i = 1; i < numLeds+1; i++)
		{
			gameObject.transform.Find(i.ToString()).gameObject.SetActive(true);
			gameObject.transform.Find(i.ToString() + "NG").gameObject.SetActive(false);
		}
	}
	
}
