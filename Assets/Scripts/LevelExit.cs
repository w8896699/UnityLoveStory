using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelExitSlowMoFactor = 0.2f;

    bool isColliding = false;


 

    void OnTriggerEnter2D(Collider2D player)
    {
        if(isColliding) return;
        isColliding = true;
        // StartCoroutine(LoadNextLevel(other));
        // LoadNextLevel(other);
            if(FindObjectOfType<GameSession>().CurrentLevel < FindObjectOfType<GameSession>().Coordinates.Length){
          
                    print("when do I reach here level exit");
                    print(FindObjectOfType<GameSession>().CurrentLevel);
                   player.gameObject.transform.position = FindObjectOfType<GameSession>().Coordinates[FindObjectOfType<GameSession>().CurrentLevel++];
               }else{
                     var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;// I want to have every level in one Scene
                    SceneManager.LoadScene(currentSceneIndex +1);
               }
        }
       
    }

    // Update is called once per frame
    // void LoadNextLevel(Collider2D player) //IEnumerator
    // {
    //     // Time.timeScale = LevelExitSlowMoFactor;
    //     // yield return new WaitForSecondsRealtime(LevelLoadDelay);
    //     // Time.timeScale = 1f;
        
    //     // var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;// I want to have every level in one Scene
    //     // SceneManager.LoadScene(currentSceneIndex +1);
 
    // }
// }
