using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntraNaClaraboia : MonoBehaviour
{
    bool playerContact;
    public Transform target;
    public float xPosition;
    public float yPosition;
    public Transform playerObject;
    GameObject[] spookTargets;

    private void Start()
    {
        if (playerObject == null)
        {
            playerObject = GameObject.Find("Player").transform;
            target = playerObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && playerContact == true)
        {
            DontDestroyOnLoad(target.gameObject);
            target.position = new Vector3(xPosition, yPosition, 0);
            spookTargets = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < spookTargets.Length; i++)
            {
                Destroy(spookTargets[i].gameObject);
            }
            SceneManager.LoadScene("Claraboia");
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
}
