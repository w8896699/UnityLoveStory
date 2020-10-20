using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
        [Header("Player Health")]
    // [SerializeField] Collider2D bodyCollider;
    
    [SerializeField] float deathKnockbackForce = 10f;
        public static bool isAlive = true;
            Vector2 directionOfLaunch;
 
 
    // Cached References
    public static Animator myAnimator;
    private Rigidbody2D myRigidbody2D;
    private GameSession myGameSession;
    public static CapsuleCollider2D myBodyCollider2D;
     void Start()
    {
        GetComponents();
        FindObjectsOfType();
        
    }
     private void GetComponents()
    {
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FindObjectsOfType()
    {
        myGameSession = FindObjectOfType<GameSession>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isAlive) { return; }
        else
        {
            directionOfLaunch = transform.position - collision.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        KillPlayer();
    }
    private void KillPlayer()
    {
        if (myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) & isAlive)
        {

            myAnimator.SetBool("Die", true);
            isAlive = false;

            Vector2 deathKnockback = new Vector2(-Mathf.Sign(directionOfLaunch.x) * deathKnockbackForce, deathKnockbackForce * 1);
            Debug.Log(deathKnockback);
            myRigidbody2D.velocity = deathKnockback;

            myBodyCollider2D.enabled = false;

            StartCoroutine(ImmobilizePlayerCorpse());
            FindObjectOfType<GameSession>().ProcessPlayDeath(GetComponent<Collider2D>());

           
        }
    }

    IEnumerator ImmobilizePlayerCorpse()
    {
        yield return new WaitForSeconds(3);
        // myRigidbody2D.velocity = new Vector2(0f, 0f);
    }
}
