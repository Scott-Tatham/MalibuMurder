using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The 'scene' of the crime.
/// Who died? How? With what?
/// </summary>
public class MurderScenario : MonoBehaviour
{
    public MurderSolveUI solverUI;

    List<Actor> actors;
    List<Weapon> weapons;


    public void Start()
    {
        actors = new List<Actor>();
        weapons = new List<Weapon>();
        GenerateRandomScenario();

        solverUI.AddActor(actors, weapons);
    }

    public void PopulateUI()
    {

    }

    public void ProposeSolution()
    {
        Actor propKiller = null;
        Actor propVictim = null;
        Weapon propWeapon = null;

        
        foreach(Weapon w in weapons)
        {
            if (w.ToString() ==  solverUI.weapon.options[solverUI.weapon.value].text)
            {
                propWeapon = w;
            }
        }

        foreach(Actor a in actors)
        {
            if (a.ToString() == solverUI.victim.options[solverUI.victim.value].text)
            {
                propVictim = a;
            }
            if (a.ToString() == solverUI.killer.options[solverUI.killer.value].text)
            {
                propKiller = a;
            }


        }

        Debug.Log("Vic: " + propVictim.ToString());
        Debug.Log("Kil: " + propKiller.ToString());
        Debug.Log("Wep: " + propWeapon.ToString());

        if (SolveMurder(propVictim, propKiller, propWeapon))
            solverUI.ShowWinScreen();
    }
    /// <summary>
    /// Calculate this caper! 
    /// </summary>
    /// <param name="proposedVictim">Who fucking died</param>
    /// <param name="proposedKiller">Whomst'd've dun it</param>
    /// <param name="proposedWeapon">What the heck killed em</param>
    /// <returns>True if correct, false if not.</returns>
    private bool SolveMurder(Actor proposedVictim, Actor proposedKiller, Weapon proposedWeapon)
    {
        if (proposedVictim.GetRole() == Actor.Role.Victim && proposedKiller.GetRole() == Actor.Role.Killer && proposedWeapon.CheckIsMurderWeapon())
            return true;
        else
            return false;
    }

    /// <summary>
    /// Create a random sceneario!
    /// </summary>
    /// <param name="actorCount">Must be at least 2 (victim and killer)</param>
    public void GenerateRandomScenario()
    {
        for (int i = 0; i < ActorTypes.colours.Count; i++)
        {
            GameObject gameObject = new GameObject("Belligerant");

            Actor newActor = gameObject.AddComponent(typeof(Actor)) as Actor;

            actors.Add(newActor);
            if (i == 0)
            {
                newActor.SetRole(Actor.Role.Killer);
                newActor.SetColour(Color.red);
                Weapon wep = gameObject.AddComponent(typeof(Weapon)) as Weapon;
                wep.SetMurderWeapon();
                wep.SetName(Weapon.randomWeaponNames[i]);
                weapons.Add(wep);
            }
            else if (i == 1)
            {
                newActor.SetRole(Actor.Role.Victim);
                newActor.SetColour(Color.blue);
            }
            else
            {
                newActor.SetRole(Actor.Role.Unrelated);
                newActor.SetColour(Color.white);
                Weapon wep = gameObject.AddComponent(typeof(Weapon)) as Weapon;
                wep.SetName(Weapon.randomWeaponNames[i]);
                weapons.Add(wep);

            }
            //actors.Add(new Actor())

        }

    }
}
