using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public static string[] randomWeaponNames = { "DVD copy of Wild Wild West", "Coles gift card", "Maya LT license", "gun probably??"};

    [SerializeField]
    private string weaponName;

    private GameObject weaponPrefab;
    private bool isMurderWeapon;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Yer tbh");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public override string ToString()
    {
        return weaponName;
    }

    public void SetName(string name)
    {
        weaponName = name;
    }

    public void SetPrefab(GameObject p)
    {
        weaponPrefab = p;
    }
    
    public void SetMurderWeapon() { isMurderWeapon = true; }

    public bool CheckIsMurderWeapon() { return isMurderWeapon; }
    public void SetRandomName()
    {
        int i = Random.Range(0, randomWeaponNames.Length);

        name = randomWeaponNames[i];
    }
}
