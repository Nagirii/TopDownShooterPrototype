using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Door : MonoBehaviour
{
    bool playerContact = false;
    public Transform target;
    public float xPosition;
    public float yPosition;
    GameObject[] spookTargets;
    GameObject player;
    Player rocambole;
    public Transform playerObject;

    

    private void Start()
    {
        StartCoroutine("ChupaMeuPiru");
        player = GameObject.Find("Player");
        rocambole = player.GetComponent<Player>();
        if (playerObject == null)
        {
            playerObject = GameObject.Find("Player").transform;
            target = playerObject;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e") && playerContact == true && rocambole.keyCount >= 3)
        {
            DontDestroyOnLoad(target.gameObject);
            target.position = new Vector3(xPosition, yPosition, 0);
            spookTargets = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < spookTargets.Length; i++)
            {
                Destroy(spookTargets[i].gameObject);
            }
            rocambole.keyCount = 0;
            rocambole.UpdateKeyUI(rocambole.keyCount);
            SceneManager.LoadScene("MaisEmbaixo");
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>();
            playerContact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerContact = false;
        }
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    IEnumerator ChupaMeuPiru()
    {
        yield return new WaitForSeconds(3f);
    }
}
