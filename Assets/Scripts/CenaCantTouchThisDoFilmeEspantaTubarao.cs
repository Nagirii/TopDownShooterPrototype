using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenaCantTouchThisDoFilmeEspantaTubarao : MonoBehaviour
{
    Renderer rend;
    Color c;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        c = rend.material.color;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Enemy"))
        {
            StartCoroutine ("CantTouch");
        }
    }

    IEnumerator CantTouch()
    {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        c.a = 0.5f;
        rend.material.color = c;
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(9, 10, false);
        c.a = 1f;
        rend.material.color = c;

    }
}
