using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip coinPickUpSFX;
    [SerializeField] int pointsForCoin = 10;
bool pickedUp = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(!pickedUp){
            pickedUp= true; //因为player有两个物理体积。。所以跳起来会触发两次捡硬币。。我不太会调单个的物理体积不发生碰撞，就只能用这个方法了
            FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
            AudioSource.PlayClipAtPoint(coinPickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }
}
