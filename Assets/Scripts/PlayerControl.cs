using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
[RequireComponent(typeof(CharacterAttribution))]
public class PlayerControl : NetworkBehaviour
{
    Camera cam;
    Vector3 destination;
    Vector3 moveDir;
    CharacterController cc;
    float runspeed;
    bool attacking;
    public bool stopMoving;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        cc = GetComponent<CharacterController>();
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        runspeed = GetComponent<CharacterAttribution>().RunSpeed/100f;
        if (!isLocalPlayer) return;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);//屏幕射线

        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,1<<8))//确保只跟第八层碰撞，注意layermask是用二进制位来判断的
            {
                destination = hit.point;
            }
            
        }
        moveDir = destination - transform.position;
        destination.y = transform.position.y;
        moveDir.y = 0;

        if (Vector3.Distance(transform.position, destination) > 0.5f&&!stopMoving)
        {
            cc.SimpleMove(moveDir.normalized*runspeed);
            GetComponent<Animator>().SetBool("isRun", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRun", false);
        }
        if(Vector3.Dot(transform.forward.normalized, moveDir.normalized) < 0.99f)
        {
            transform.forward = Vector3.Lerp(transform.forward, moveDir.normalized, Time.deltaTime * 5f).normalized;
        }

    }
}
