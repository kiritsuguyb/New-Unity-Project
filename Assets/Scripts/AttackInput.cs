using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Rendering;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterAttribution))]
public class AttackInput : NetworkBehaviour
{
    LineRenderer lr;
    Animator animator;
    CharacterAttribution ca;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ca = GetComponent<CharacterAttribution>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetKey(KeyCode.Q))
        {
            lr=showRange();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            normalAttack();
            Destroy(lr);
        }
        else
        {
            doNotAttack();
        }

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Slash")) GetComponent<PlayerControl>().stopMoving = true;
        else GetComponent<PlayerControl>().stopMoving = false;

    }
    LineRenderer showRange()
    {
        return drawCircle(0.1f, ca.rangeMaterial);
    }
    void normalAttack()
    {
        animator.SetBool("isSlash", true);
    }
    void doNotAttack()
    {
        animator.SetBool("isSlash", false);
    }
    private LineRenderer GetLineRenderer(float CircleWidth, Material CircleMaterial, int smooth)
    {
        LineRenderer lr = GetComponent<LineRenderer>();
        if (lr == null)
        {
            lr = transform.gameObject.AddComponent<LineRenderer>();
        }
        lr.startWidth = CircleWidth;
        lr.endWidth = CircleWidth;
        lr.material = CircleMaterial;
        lr.loop = true;
        lr.positionCount = smooth;
        lr.receiveShadows = false;
        lr.shadowCastingMode = ShadowCastingMode.Off;
        return lr;
    }
    private LineRenderer drawCircle(float CircleWidth, Material CircleMaterial, int smooth = 36)
    {

        LineRenderer lr = GetLineRenderer(CircleWidth, CircleMaterial, smooth);
        for (int i = 0; i < smooth; i++)
        {
            float x = Mathf.Cos(2 * Mathf.PI * i / smooth) * GetComponentInParent<CharacterAttribution>().attackRange;
            float z = Mathf.Sin(2 * Mathf.PI * i / smooth) * GetComponentInParent<CharacterAttribution>().attackRange;

            lr.SetPosition(i, new Vector3(x, 0.1f, z) + transform.position);
        }
        return lr;
    }

}
