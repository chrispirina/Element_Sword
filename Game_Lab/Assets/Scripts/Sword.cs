using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Element : uint
{
    FIRE = 0xFFFF0000,
    EARTH = 0xFF503232,
    WATER = 0xFF0000FF,
    AIR = 0xFF00FF77,
    LIFE = 0xFFFFFFFF,
    DEATH = 0xFF000000
}

public class Sword : MonoBehaviour
{
    Animator anim;
    private Element selected;
    private List<Element> elements = new List<Element>();

    public Renderer[] elementRenderers = { };
    public int elementLimit = 2;

    private bool storing = false;
    private Color dColor;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        dColor = elementRenderers[0].material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Active");


        if (Input.GetKeyDown(KeyCode.E))
            ElementCycle();

        if (Input.GetKeyDown(KeyCode.Q))
            ElementAdd();

        if (Input.GetKeyDown(KeyCode.Space))
            storing = true;

    }

    public void ElementCycle()
    {
        int sel = Array.IndexOf(Enum.GetValues(typeof(Element)), selected) + 1;

        if (sel >= Enum.GetValues(typeof(Element)).Length)
            sel = 0;

        selected = Enum.GetValues(typeof(Element)).Cast<Element>().ElementAt(sel);
        Debug.Log(selected);
    }

    public void ElementAdd()
    {
        if (!storing)
            elements.Clear();
        storing = false;

        if (elements.Count >= elementLimit)
            return;

        elements.Add(selected);

        Debug.Log("SEL: " + string.Join(", ", elements.Select(e => e.ToString()).ToArray()));

        for (int i = 0; i < elementRenderers.Length; i++)
        {
            if (i < elements.Count)
                elementRenderers[i].material.color = GetColor((uint)elements[i]);
            else
                elementRenderers[i].material.color = dColor;
        }
    }

    private void OnValidate()
    {
        if (elementRenderers == null)
            elementRenderers = new Renderer[elementLimit];

        if (elementRenderers.Length != elementLimit)
            Array.Resize(ref elementRenderers, elementLimit);
    }

    private Color GetColor(uint argb)
    {
        uint alpha = (argb >> 24) & 0xFF;
        uint red = (argb >> 16) & 0xFF;
        uint green = (argb >> 8) & 0xFF;
        uint blue = argb & 0xFF;

        Debug.LogFormat("{0} {1} {2} {3}", alpha / 255F, red / 255F, green / 255F, blue / 255F);

        return new Color(red / 255F, green / 255F, blue / 255F, alpha / 255F);
    }
}
