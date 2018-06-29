using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MurderSolveUI : MonoBehaviour
{
    public Dropdown killer;
    public Dropdown victim;
    public Dropdown weapon;
    public Image winImage;

    private Actor a;
    
	// Use this for initialization
	void Start ()
    {
        killer.ClearOptions();
        victim.ClearOptions();
        weapon.ClearOptions();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddActor(List<Actor> a, List<Weapon>w)
    {
        List<Dropdown.OptionData> actorOptions = new List<Dropdown.OptionData>();

        foreach (Actor ac in a)
        {
            actorOptions.Add(new Dropdown.OptionData(ac.ToString()));
        }

        killer.AddOptions(actorOptions);
        victim.AddOptions(actorOptions);

        List<Dropdown.OptionData> weaponOptions = new List<Dropdown.OptionData>();
        foreach (Weapon wp in w)
        {
            weaponOptions.Add(new Dropdown.OptionData(wp.ToString()));
        }

        weapon.AddOptions(weaponOptions);
    }

    public void ShowWinScreen()
    {
        winImage.gameObject.SetActive(true);
    }
}
