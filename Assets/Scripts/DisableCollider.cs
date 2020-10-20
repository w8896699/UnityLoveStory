using UnityEngine;
using UnityEngine.Tilemaps;
 
public class DisableCollider : MonoBehaviour
{
    private TilemapCollider2D platforms;
 
    private void Start()
    {
        platforms = GetComponent<TilemapCollider2D>();
    }
 
    private void Update ()
    {
        // if (UnityEngine.Input.GetKey(KeyCode.Space))
        // {
            // print("I am here");
            // platforms.enabled = false;
        // }
    }
}