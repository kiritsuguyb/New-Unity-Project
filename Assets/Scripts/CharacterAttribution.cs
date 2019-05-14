using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Vulnerable))]
public class CharacterAttribution : MonoBehaviour
{
    public float attackRange=2.3f;
    public float attackAngle = 120f;
    public float RunSpeed = 300f;
    public bool isVulnerable = true;
    public Material rangeMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if (isVulnerable)
        {
            if (GetComponent<Vulnerable>() == null) gameObject.AddComponent<Vulnerable>();
        }
        else
        {
            if (GetComponent<Vulnerable>() != null) gameObject.GetComponent<Vulnerable>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
