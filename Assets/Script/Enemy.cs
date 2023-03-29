using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();

        Invoke("Think", 5);
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(nextMove,rigid.velocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.3f,rigid.position.y);
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platfrom"));

        if (rayHit.collider == null)
        {
            Return();
        }
        
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2); //최대 값은 random값에 포함 안됨


        anim.SetInteger("walkSpeed", nextMove);
        if(nextMove !=0)
        {

            spriteRenderer.flipX = nextMove == 1;
        }
        float nextThinkTime = Random.Range(2, 5);
        Invoke("Think", nextThinkTime);
    }

    void Return()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;
    }
}
