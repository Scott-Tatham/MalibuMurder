using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A person involved in the scene.
/// Can be a killer, be the dead one or completely unrelated.
/// </summary>
public class Actor : MonoBehaviour
{
    public enum Role { Killer, Victim, Unrelated}

    [SerializeField]
    private string name = "";
    [SerializeField]
    private Role actorRoll;
    [SerializeField]
    private Color actorColour;

    public void SetRole(Role r)
    {
        actorRoll = r; 
    }

    public void SetColour(Color c)
    {
        actorColour = c;
    }

    public void SetName(string n)
    {
        name = n;
    }

    public Role GetRole() { return actorRoll; }

    public override string ToString()
    {
        //If a name has been pre specified, just return that.
        if (name != "")
            return name;

        //Else we'll generate a name based on our colour! Neat!
        string colourName = "COLOUR_NOT_FOUND";
        //Go through our list of defined colour to attempt to get a name.
        foreach (KeyValuePair<string, Color> item in ActorTypes.colours)
        {
            if (item.Value == actorColour)
                colourName = item.Key;
        }
        return colourName;

        
    }

    public void SetRandomColour()
    {
        //ActorTypes.colours.Count
        //SetColour(ActorTypes.colours[4]);
    }
}

/// <summary>
/// Different types of actors.
/// Always present in memory so we may look upon it
/// </summary>
public static class ActorTypes
{
    //Is this garbage? Hell yea!
    //Is it needed? Kinda.
    public static IDictionary<string, Color> colours = new Dictionary<string, Color>()
    {
        {"Red",Color.red},
        {"Green", Color.green},
        {"Blue", Color.blue},
        {"White",Color.white}

    };
}
