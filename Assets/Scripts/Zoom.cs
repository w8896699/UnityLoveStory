using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Start is called before the first frame update
 public float zoomSpeed = 0.5f;     public float targetOrtho;
     public float smoothSpeed = 0.2f;
 
     public Vector3 TargetPosition = new Vector3(20f, 15f, -10.0f);
     private float TargetSize = 65f;
     float currentSize ;
     private Vector3 velocity = Vector3.zero;
    void Start() {
         currentSize = Camera.main.orthographicSize;
               
      
     }
    void Update () {
         

          
         Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, TargetSize, zoomSpeed * Time.deltaTime);
        //  Vector3 pos = new Vector3( Camera.main.aspect, 5.0f, -10.0f);
        // print(Camera.main.gameObject.transform.position);
         Camera.main.gameObject.transform.position = Vector3.SmoothDamp(Camera.main.gameObject.transform.position, TargetPosition, ref velocity, smoothSpeed);
     }
    
}
