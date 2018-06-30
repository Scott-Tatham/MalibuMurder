using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A device for just straight up murderin' 
/// </summary>
public class Weapon : MonoBehaviour
{
    public static string[] randomWeaponNames = { "DVD copy of Wild Wild West", "Coles gift card", "Maya LT license", "gun probably??"};

    [SerializeField]
    private string weaponName;

    private GameObject weaponPrefab;
    private bool isMurderWeapon;
    
    /// <summary>
    /// Get a string rep of this weapon
    /// </summary>
    /// <returns>weapon as string</returns>
    public override string ToString()
    {
        return weaponName;
    }

    /// <summary>
    /// Set what this weapon is called.
    /// </summary>
    /// <param name="name">Name of weapon</param>
    public void SetName(string name)
    {
        weaponName = name;
    }

    /// <summary>
    /// Set the associated model/prefab of this weapon.
    /// </summary>
    /// <param name="p">prefab gameobject</param>
    public void SetPrefab(GameObject p)
    {
        weaponPrefab = p;
    }
    
    /// <summary>
    /// Sets this as the murder weapon.
    /// </summary>
    public void SetMurderWeapon() { isMurderWeapon = true; }

    /// <summary>
    /// Is this the murder weapon?
    /// </summary>
    /// <returns>True if it is, false if it aint</returns>
    public bool CheckIsMurderWeapon() { return isMurderWeapon; }

    /// <summary>
    /// Just call this something random
    /// </summary>
    public void SetRandomName()
    {
        int i = Random.Range(0, randomWeaponNames.Length);

        name = randomWeaponNames[i];
    }
}
