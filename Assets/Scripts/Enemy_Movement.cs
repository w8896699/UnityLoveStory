using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigidBody;
[SerializeField] float moveSpeed = 1f;

bool isFacingRight;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // print(IsFacingRight());
        if(IsFacingRight()){

            myRigidBody.velocity = new Vector2(moveSpeed, 0f); 
        }else{
            myRigidBody.velocity = new Vector2(-moveSpeed, 0f); 
        }

    }
private bool IsFacingRight() {
    // print(transform.localScale.x);
    return transform.localScale.x>0;
}
    private void OnTriggerExit2D(Collider2D collision){
        // print("I bumping");
        // print(transform.localScale.x);
        // transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)*Mathf.Abs(transform.localScale.x)), 1*transform.localScale.y);
    }
}
