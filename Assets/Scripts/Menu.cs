using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame updatepublic

    public void StartFirstLevel(){
        SceneManager.LoadScene(1);
    }
        public void LoadMianMenue(){
        SceneManager.LoadScene(0);
    }
}
