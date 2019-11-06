using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public GameObject Character;
    private Outline _outline;

    // Start is called before the first frame update
    void Awake()
    {
        _outline = GetComponent<Outline>();
        Debug.Log("PlayerCharacter awake " + _outline);
        //_outline.OutlineMode = Outline.Mode.Disable;
        //_outline.OutlineColor = Color.green;
        //_outline.OutlineWidth = 10;
    }

    public void Select()
    {
        Debug.Log("PlayerCharacter Select " + _outline);
        _outline.OutlineMode = Outline.Mode.OutlineAll;
    }

    public void UnSelect()
    {
        _outline.OutlineMode = Outline.Mode.Disable;
    }
}
