using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulnerable : MonoBehaviour
{
    public bool attacked = false;
    public CharacterAttribution other=null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attacked)
        {
            Debug.Log(gameObject.ToString() + " is Hit");
            attacked = false;
        }
    }
}
