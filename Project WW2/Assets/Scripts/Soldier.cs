using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    Animator anim = null;
    [HideInInspector]
    public int range = 1;
    [HideInInspector]
    public int size  = 1;
    int speed = 8;
    bool sprint = false;
    Vector3 sprintPos;

    // Terrain
    [SerializeField]
    public Terrains currentTerrain;
    [HideInInspector]
    public int currentInsidePos;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sprint)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, sprintPos, step);

            if (Vector3.Distance(transform.position, sprintPos) < 0.001f)
            {
                // Swap the position of the cylinder.
                transform.position = sprintPos;
                sprint = false;
                anim.SetBool("sprint", sprint);
            }
        }
    }

    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
            SelectThisSoldier();
    }

    public void SelectThisSoldier()
    {
        GameController.Instance.selectedSoldier = this;
    }

    public void MoveTo(Transform tr)
    {
        sprint = true;
        sprintPos = tr.position;
        anim.SetBool("sprint", sprint);
        transform.LookAt(sprintPos);
    }

}
