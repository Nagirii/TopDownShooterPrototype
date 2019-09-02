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

    private SpriteRenderer rend;
    private Color c;

    public bool isInvulnerable = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        
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
        else
        {
            StartCoroutine("ParaDeBater");

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

    IEnumerator ParaDeBater()
    {
        isInvulnerable = true;
        Physics2D.IgnoreLayerCollision(9, 10, true);
        c.a = (0.5f);
        rend.material.color = c;
        yield return new WaitForSeconds(2f);
        isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(9, 10, false);
        c.a = (1f);
        rend.material.color = c;
    }


    }
