using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public GameObject[] selves;
    public List<GameObject> Enemies;
    CapsuleCollider capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isSelf(other.gameObject)) return;
        Enemies.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        if (isSelf(other.gameObject)) return;
        Enemies.Remove(other.gameObject);
    }
    bool isSelf(GameObject gameObject)
    {
        foreach(GameObject go in selves)
        {
            if (go == gameObject) return true;
        }
        return false;
    }
}
