using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infantry : Soldier
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            base.SelectThisSoldier();
    }
}
