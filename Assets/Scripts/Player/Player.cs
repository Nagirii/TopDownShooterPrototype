using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 moveAmount;
    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * speed;

        //IsRunning check
        if(moveInput != Vector2.zero)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage){
        health = health - damage;
        UpdateHealthUI(health);
        if(health<=0){
            Destroy(this.gameObject);
        }
    }
    public void ChangeWeapons(Weapon weaponToEquip){
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, transform.position, transform.rotation, transform);

    }

    public void UpdateHealthUI(int currentHeatlh)
    {
        for (int i=0; i < hearts.Length; i++)
        {
            if (i < currentHeatlh)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    public void IncreaseHealth(int heal)
    {
        health = health + heal;
        if (health > 5)
        {
            health = 5;
        }
        UpdateHealthUI(health);
    }
    

}
