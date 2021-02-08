using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    protected Animator anim = null;
    [HideInInspector]
    public int range = 1;
    [HideInInspector]
    public int size  = 1;
    protected int speed = 8;
    protected bool sprint = false;
    protected Vector3 sprintPos;

    // Terrain
    [SerializeField]
    public Terrains currentTerrain;
    [HideInInspector]
    public int currentInsidePos;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
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

                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }

    public virtual void SelectThisSoldier()
    {
        GameController.Instance.selectedSoldier = this;
    }

    public virtual void MoveTo(Transform tr)
    {
        sprint = true;
        sprintPos = tr.position;
        anim.SetBool("sprint", sprint);
        transform.LookAt(sprintPos);
    }

}
