using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The UI responsible for the seletion of a killer, victim and weapon.
/// </summary>
public class MurderSolveUI : MonoBehaviour
{
    public Dropdown killer;
    public Dropdown victim;
    public Dropdown weapon;
    public Image winImage;
    public Text turnsLeft;

	// Use this for initialization
	void Start ()
    {
        killer.ClearOptions();
        victim.ClearOptions();
        weapon.ClearOptions();
	}

    /// <summary>
    /// Add all our actors and weapons for selection.
    /// </summary>
    /// <param name="a">All avaliable actors.</param>
    /// <param name="w">All avaliable weapons</param>
    public void PopulateDropdowns(List<Actor> a, List<Weapon>w)
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

    /// <summary>
    /// Set how many guesses we have left.
    /// </summary>
    /// <param name="turns">Guesses</param>
    public void SetProposalsLeft(int proposals)
    {
        turnsLeft.text = "Proposals left: " + proposals;
    }

    /// <summary>
    /// Conglaturations. You have completed a great game.
    /// You have prooved the justice of our culture.
    /// Now go and rest our heroes. 
    /// </summary>
    public void ShowWinScreen()
    {
        winImage.gameObject.SetActive(true);
    }
}
