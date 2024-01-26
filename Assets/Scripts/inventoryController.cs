using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryController : MonoBehaviour
{
	public bool flare = false;
	public bool equipFlare = false;
	public int flareCount = 3;
	public float flareBurnTime = 0.0f;
	public bool rebreather = false;
	public bool isEquipRebreather = false;
	public int rebreatherCount = 4;
	public bool bait = true;
	public bool fuelRod = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void getFlare()
	{
		flare = true;
	}
	
	public void unequipFlare()
	{
		equipFlare = false;
	}
	
	public void useFlare()
	{
		if(equipFlare && flareBurnTime > 0)
		{
			return;
		}
		
		if (flareCount > 0 && flare && !equipFlare && flareBurnTime == 0.0f)
		{
			flareCount--;
			flareBurnTime = 30.0f;
			equipFlare = true;
			StartCoroutine(burnDownFlare());
		}
	}
	
	IEnumerator burnDownFlare()
	{
		while (flareBurnTime > 0)
		{
			yield return new WaitForSeconds (1);
			flareBurnTime -= 1.0f;
		}
		
		flareBurnTime = 0.0f;
		unequipFlare();
	}
	
	public void getRebreather()
	{
		rebreather = true;
	}
	
	public void equipRebreather()
	{
		if(isEquipRebreather)
		{
			isEquipRebreather = false;
			return;
		}
		
		if (rebreatherCount > 0 && !isEquipRebreather)
		{
			rebreatherCount--;
			isEquipRebreather = true;
		}
	}
	
	
	public void useBait()
	{
		bait = false;
	}
	
	public void getFuelRod()
	{
		fuelRod = true;
	}
}
