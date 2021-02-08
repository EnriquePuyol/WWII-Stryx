using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrains : MonoBehaviour
{
    public Transform[] neighbours;
    public Transform[] insidePositions;
    [SerializeField]
    bool[] areOccupiedPositions = {false, false, false};

    [HideInInspector]
    public int defense = 0;
    [SerializeField]
    int currentSize = 0;
    int maxSize = 3;

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

    private void OnMouseOver()
    {
        Soldier soldier = GameController.Instance.selectedSoldier;

        if (Input.GetMouseButtonUp(0))
            GameController.Instance.selectedSoldier = null;

        if (Input.GetMouseButtonUp(1) && soldier != null && soldier.currentTerrain.transform.position != this.transform.position)
        {
            if (Vector3.Distance(soldier.currentTerrain.transform.position, transform.position) > 17.5f * soldier.range || 
                currentSize + soldier.size > maxSize)
            {
                Debug.Log("Out of Range // Out of Size");
                return;
            }

            //Mover unidad seleccionada
            for(int i = 0; i < areOccupiedPositions.Length; i++)
            {
                if(areOccupiedPositions[i] == false)
                {
                    soldier.currentTerrain.currentSize -= soldier.size;
                    soldier.currentTerrain.areOccupiedPositions[soldier.currentInsidePos] = false;

                    soldier.MoveTo(insidePositions[i]);

                    soldier.currentTerrain = this;
                    areOccupiedPositions[i] = true;
                    soldier.currentInsidePos = i;
                    currentSize += soldier.size;
                    return;
                }
            }
        }
    }

}
