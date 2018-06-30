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

    [Tooltip("Should we generate the scenario or scan for it?")]
    public bool genScenario = false;
    public int maxProposals;

    List<Actor> actors;
    List<Weapon> weapons;
    int proposalsLeft;

    public void Start()
    {
        proposalsLeft = maxProposals;
        actors = new List<Actor>();
        weapons = new List<Weapon>();

        if (genScenario)
            GenerateRandomScenario();
        else
            ScanScenario();

        PopulateUI();
    }

    public void PopulateUI()
    {
        if (actors.Count == 0 || weapons.Count == 0)
        {
            Debug.LogWarning("WARINING! We don't have actors or weapons. Fix that shitt");
            return;
        }
        solverUI.PopulateDropdowns(actors, weapons);
        solverUI.SetProposalsLeft(proposalsLeft);
    }

    public void ScanScenario()
    {
        foreach (Transform child in transform)
        {
            Actor a = child.gameObject.GetComponent<Actor>();
            if (a != null)
                actors.Add(a);

            Weapon w = child.gameObject.GetComponent<Weapon>();
            if (w != null)
                weapons.Add(w);

        }
    }

    /// <summary>
    /// We'll read through the dropdown menus to infer what the user assumes is the murder scenario
    /// </summary>
    public void ProposeSolution()
    {
        //Our proposed solution.
        Actor propKiller = null;
        Actor propVictim = null;
        Weapon propWeapon = null;

        
        foreach(Weapon w in weapons) //For our the weapons in the field.
        {
            if (w.ToString() ==  solverUI.weapon.options[solverUI.weapon.value].text) //Convert the dropdown string to the weapon.
            {
                propWeapon = w; //Find the one the user has selected and set that as the proposed.
            }
        }

        foreach(Actor a in actors) //Same for actors like we did for weapons.
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

        if (SolveMurder(propVictim, propKiller, propWeapon)) //Did we guess right?
            solverUI.ShowWinScreen(); //We're winar 
        else
            NegateProposals();

    }

    public void NegateProposals()


    {
        proposalsLeft--;
        solverUI.SetProposalsLeft(proposalsLeft);
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
        for (int i = 0; i < ActorTypes.colours.Count; i++) //Foreach defined colour.
        {
            //Actors will eventually be real gameobjects in space so we're prepping for that.
            GameObject gameObject = new GameObject("Belligerant " + i); //Create a new gameobject contrainer for actor data.

            Actor newActor = gameObject.AddComponent(typeof(Actor)) as Actor; //All deez game objects are actors.

            actors.Add(newActor);
            if (i == 0) //First we'll create a killer. we need one.
            {
                //Set em up with some default junk.
                newActor.SetRole(Actor.Role.Killer);
                newActor.SetColour(Color.red);
                Weapon wep = gameObject.AddComponent(typeof(Weapon)) as Weapon;
                wep.SetMurderWeapon();
                wep.SetName(Weapon.randomWeaponNames[i]);
                weapons.Add(wep);
            }
            else if (i == 1) //Now we need a victim
            {
                newActor.SetRole(Actor.Role.Victim);
                newActor.SetColour(Color.blue);
            }
            else //Fill out our red-herrings.
            {
                newActor.SetRole(Actor.Role.Unrelated);
                newActor.SetColour(Color.white);
                Weapon wep = gameObject.AddComponent(typeof(Weapon)) as Weapon;
                wep.SetName(Weapon.randomWeaponNames[i]);
                weapons.Add(wep);

            }     
        }
    }
}
