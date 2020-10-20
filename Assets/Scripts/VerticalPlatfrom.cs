using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatfrom : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitTime;
    private  PlatformEffector2D effector2D;
    void Start()
    {
       effector2D = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            waitTime = 0.5f;

        }
        
        if(Input.GetKey(KeyCode.DownArrow) ){
            if(waitTime <= 0){
                
                effector2D.rotationalOffset = 180f;
                waitTime = 0.5f;
            }else{
                waitTime -= Time.deltaTime;
            }
        }
        // print(transform.position);
      if(UnityEngine.Input.GetButtonDown("Jump")|| Input.GetKey (KeyCode.UpArrow)){
            effector2D.rotationalOffset = 0;
      }
    }
//      public void ReverseDirection ()
//  {
//      effector2D = GetComponent<PlatformEffector2D>();
//             effector2D.rotationalOffset = 0;
//  }
 }
