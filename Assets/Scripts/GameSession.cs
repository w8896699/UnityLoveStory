using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Game Session")]
    [SerializeField] float levelLoadDelay = 1f;
    [SerializeField] int playerLives = 99;
    [SerializeField] int score = 0;
    [SerializeField] Text livesText ;
    [SerializeField] Text scoreText ;
    [SerializeField]  public Vector2[] Coordinates = {new Vector2(-63f, -29f), new Vector2(-3f, 3.5f), new Vector2(83f , 7f)};
     [SerializeField] public int CurrentLevel = 1;
     

    private void Awake() {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if(numGameSessions > 1){
            Destroy(gameObject);

        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
    

        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessPlayDeath(Collider2D other){
        if(playerLives > 1){
            TakeLife(other);
        }
        else{
            ResetGameSession();
        }
    }
    private void ResetGameSession(){
        SceneManager.LoadScene(0);
        Revive();
        Destroy(gameObject);
    }

    public void AddToScore (int pointsToAdd){
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    private void TakeLife(Collider2D player){ //TODO 需要改逻辑
        playerLives--;
        livesText.text = playerLives.ToString();
        // var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // SceneManager.LoadScene(1); 
       
        // player.gameObject.transform.position = Coordinates[CurrentLevel-1];

        // FindObjectOfType<Player>().Revive();
        StartCoroutine(RestartThisLevel(player));
    }
    
    private IEnumerator RestartThisLevel(Collider2D player)
    {
        yield return new WaitForSeconds(2);
        // SceneManager.LoadScene(1);
        player.gameObject.transform.position = Coordinates[CurrentLevel-1];
        Revive();
    }
    
    private void Revive(){
        PlayerHealth.isAlive = true;
        PlayerHealth.myBodyCollider2D.enabled = true;
        PlayerHealth.myAnimator.SetBool("Die", false);
    }
}
