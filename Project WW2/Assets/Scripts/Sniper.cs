using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Soldier
{
    //bool getUp = false;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
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
                anim.SetBool("getUp", false);

                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            base.SelectThisSoldier();
    }

    public override void MoveTo(Transform tr)
    {
        anim.SetBool("getUp", true);
        StartCoroutine(GetUp(tr));
    }

    IEnumerator GetUp(Transform tr)
    {
        yield return new WaitForSeconds(1f);

        sprint = true;
        sprintPos = tr.position;
        transform.LookAt(sprintPos);
    }
}
