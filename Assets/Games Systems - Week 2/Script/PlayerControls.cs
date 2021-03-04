using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float move;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float sprintMultiplier = 2;
    [SerializeField] private float jetPackForce = 20;
    [SerializeField] private bool grounded = true;
    [SerializeField] private bool doubleJump = true;

    [SerializeField] private float currentFuel = 5;
    [SerializeField] private float maxFuel = 15;
    public GameObject jetpackSprite;
    public GameObject CanvasA;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        jetpackSprite.SetActive(false);
        //CanvasA = GetComponent<PauseMenu>;
    }

    private void Update()
    {
        move = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump"))
        {

            if (grounded == true && doubleJump == false)
            {
                rb2D.velocity += Vector2.up * jumpHeight;
                grounded = false;
            }
            else if (grounded == false && doubleJump == false)
            {
                rb2D.velocity = Vector2.up * jumpHeight;
                doubleJump = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= sprintMultiplier;
        }

        // Open pause menu on P
        if (Input.GetKeyDown(KeyCode.P))
        {
            enterThePauseTheMenu();
        }

        if (Input.GetKey(KeyCode.W))
        {
            grounded = false;

            if (currentFuel > 0)
            {
                rb2D.velocity += Vector2.up * jetPackForce * Time.deltaTime;
                currentFuel -= Time.deltaTime;
                jetpackSprite.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            jetpackSprite.SetActive(false);
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2D.velocity = new Vector2(move, rb2D.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            doubleJump = false;
            currentFuel = maxFuel;
        }
    }

    public void RaiseStat(int value)
    {
        switch (value)
        {
            case 1:
                moveSpeed += 1;
                break;
            case 2:
                jumpHeight += 1;
                break;
            case 3:
                sprintMultiplier += 1;
                break;
            case 4:
                jetPackForce += 1;
                break;
            case 5:
                maxFuel += 1;
                break;
        }
    }
    public void LowerStat(int value)
    {
        switch (value)
        {
            case 1:
                moveSpeed -= 1;
                break;
            case 2:
                jumpHeight -= 1;
                break;
            case 3:
                sprintMultiplier -= 1;
                break;
            case 4:
                jetPackForce -= 1;
                break;
            case 5:
                maxFuel -= 1;
                break;
        }
    }
    // Damian's Version of above
    //public void ChangeMoveSpeed(float value)
    //{
    //    moveSpeed += value;
    //}

    public void enterThePauseTheMenu()
    {
        CanvasA.SetActive(!CanvasA.activeSelf);
        if (CanvasA)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
