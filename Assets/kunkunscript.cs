using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunkunscript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength=10;
    public logicScript logic;
    public bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (isAlive && (transform.position.y > 9 || transform.position.y < -9))
            endGame();
       


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        endGame();
    }

    private void endGame()
    {
        isAlive = false;
        logic.gameOver();
        
    }
}
