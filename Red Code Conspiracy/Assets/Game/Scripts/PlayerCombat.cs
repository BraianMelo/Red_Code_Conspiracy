using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;


public class PlayerCombat : MonoBehaviour
{
    private float timeAttack;
    public float startTimeAttack;
    private Rigidbody2D rb;
    private Animator myAnimator;
    public bool haveKnife = false;
    public int attackDamage;
    public int attackRange;
    public Vector3 attackOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && haveKnife == true)
        {
            AttackP();
        }
    }

    void AttackP()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;


        Collider2D collInfo = Physics2D.OverlapCircle(pos, attackRange);
        if (collInfo != null)
        {
            collInfo.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }
        myAnimator.SetTrigger("attack");
    }


    private void FixedUpdate() {
        HandleLayers();
    }

    private void HandleLayers()
    {
        if (haveKnife)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
