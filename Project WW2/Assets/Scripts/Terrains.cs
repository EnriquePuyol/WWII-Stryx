using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrains : MonoBehaviour
{

    public Transform[] neighbours;

    [HideInInspector]
    public int defense = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set up defense based on the name´s last character
        defense = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
