using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Element
{
    FIRE,
    EARTH,
    WATER,
    AIR,
    LIFE,
    DEATH
}

    

public class Sword : MonoBehaviour
{
    Animator anim;
    public int[] element;
    private bool storeing = false;

	// Use this for initialization
	void Start ()
    {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        
            anim.SetTrigger("Active");
        

        if (Input.GetKeyDown(KeyCode.E))
            ElementSwitch();

        if (Input.GetKeyDown(KeyCode.Q) && storeing == false)
            ElementEquip();

        else if (Input.GetKeyDown(KeyCode.Q) && storeing == true)
            ElementJoin();

        if (Input.GetKeyDown(KeyCode.Space))
            ElementStore();

	}
    public void ElementSwitch()
    {

    }

    public void ElementEquip()
    {

    }

    public void ElementStore()
    {

    }

    public void ElementJoin()
    {

    }
}
