using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallScript : MonoBehaviour
{
    Rigidbody2D Player;

    //Bar systems
    public int maxHealth = 100;
    public int currentHealth;

    public int maxWater = 100;
    public int currentWater;

    public int maxHunger = 100;
    public int currentHunger;

    public HealthScript healthScript;
    public WaterScript waterScript;
    public HungerScript hungerScript;

    //player
    float walkspeed = 10f;
    float speedlimiter = 0.7f;
    float inputHorizontal;
    float inputVerical;

    // animations and state
    Animator animator;
    string currentState;
    const string BALL_IDLE = "Ball Idle";
    const string BALL_LEFT = "Ball Left";
    const string BALL_RIGHT = "Ball Right";
    const string BALL_UP = "Ball Up";
    const string BALL_DOWN = "Ball Down";


    void Start()
    {
        currentHealth = maxHealth;
        healthScript.SetMaxHealth(maxHealth);

        currentWater = maxWater;
        waterScript.SetMaxWater(maxWater);

        currentHunger = maxHunger;
        hungerScript.SetMaxHunger(maxHunger);

        Player = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVerical = Input.GetAxisRaw("Vertical");
        //Moveanimation
        if (inputHorizontal > 0)
        {
            ChangeAnimationsState(BALL_RIGHT);
        }
        else if (inputHorizontal < 0)
        {
            ChangeAnimationsState(BALL_LEFT);
        }
        else if (inputVerical > 0)
        {
            ChangeAnimationsState(BALL_UP);
        }
        else if (inputVerical < 0)
        {
            ChangeAnimationsState(BALL_DOWN);
        }

        //detectors

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5);
        }

      
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            TakeWater(5);
        }

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            MoreHunger(5);
        }
    }


    //Damage subtractor

    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthScript.setHealth(currentHealth);
    }

    //Water subtractor

    void TakeWater(int Water)
    {
        currentWater -= Water;
        waterScript.setWater(currentWater);
    }

    void MoreHunger(int Hunger)
    {
        currentHunger -= Hunger;
        hungerScript.setHunger(currentHunger);
    }

    void FixedUpdate()
    {
        //player movement
        if (inputHorizontal != 0 || inputVerical != 0)
        {
            if (inputHorizontal != 0 && inputVerical != 0)
            {
                inputHorizontal *= speedlimiter;
                inputVerical *= speedlimiter;
            }
            Player.velocity = new Vector2(inputHorizontal * walkspeed, inputVerical * walkspeed);
        }
        else
        {
            Player.velocity = new Vector2(0f, 0f);
            //Idle animtion
            ChangeAnimationsState(BALL_IDLE);
        }

    }

    //animation changer
    void ChangeAnimationsState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
    
}
