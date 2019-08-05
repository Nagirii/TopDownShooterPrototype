using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChutaPorta : MonoBehaviour
{
  bool playerContact;
  public Transform target;
    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown("e") && playerContact == true){
                 DontDestroyOnLoad(target.gameObject);
         SceneManager.LoadScene("k");
            }
            
             
    
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.tag == "Player"){
            playerContact = true;
            }
            else
            {
                playerContact = false;
            }
            }  
  
    }
    public void LoadScene(string sceneName){
         SceneManager.LoadScene(sceneName);
    }
}
}

