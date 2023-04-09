using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutlineObject : MonoBehaviour
{
    private IOutlineObject outlineObject;

    private void Start()
    {
        outlineObject = gameObject.GetComponent<IOutlineObject>();
    }

    private void OnMouseOver()
    {
        if (outlineObject != null)
        {
            outlineObject.HandleOnOutlineStart();
        }    
    }

    private void OnMouseExit()
    {
        if (outlineObject != null)
        {
            outlineObject.HandleOnOutlineEnd();
        }        
    }
}
