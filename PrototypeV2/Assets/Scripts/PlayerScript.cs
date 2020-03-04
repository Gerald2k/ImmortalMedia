using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public int p1Health = 100;
    private int p2Health = 100;

    [SerializeField]
    private GameObject p1HealthText;

    [SerializeField]
    private GameObject p2HealthText;

    // Get physics and sprite image
    GameManager myGameManager;
    public SpriteRenderer mySpriteRenderer;
    Rigidbody2D myRigidBody2D;
    public GameObject gun;
    public GameObject gunParent;
    GameObject enemyObject;

    // Set starting values and types
    bool isPlayerJumping = false;
    public int playerIndex = 1;
    static int player1Score = 0;
    static int player2Score = 0;
    float beginTimer = 5.0f;
    static float roundTimer;
    Vector2 whereToSpawn;
    float playerX;
    float playerY;

    enum CONTROLS
    {
        LEFT,
        RIGHT,
        JUMP,
        BSCATK,
        SPCATK
    }
    // Start is called before the first frame update
    void Start()
    {
        // I think open stream of physics data from unity
        myRigidBody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        // Fetches enemy object so we can interact across scripts
        GameObject enemyObject = GameObject.Find("Enemy");

        if (playerIndex == 1)
        {
            playerX = gunParent.transform.localPosition.x + gunParent.transform.localScale.x * 3;
            playerY = gunParent.transform.localPosition.y + gunParent.transform.localScale.y / 3;
            whereToSpawn = new Vector2(playerX, playerY);

            // Spawn gun
            Instantiate(gun, whereToSpawn, Quaternion.identity, gunParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text p1HT = p1HealthText.GetComponent<Text>();
        Text p2HT = p2HealthText.GetComponent<Text>();
        p1HT.text = "P1 Health: " + p1Health;
        p2HT.text = "P2 Health: " + p2Health;

        #region Win scenario
        if (player1Score < 200 && player2Score > 200)
        {
            // Player 2 win
        }
        else
        {
            // Player 1 win
        }
        #endregion

        #region round mangement
        // beginning peace time
        if (beginTimer > 0.0f)
        {
            beginTimer -= Time.deltaTime;
        }
        else
        {
            if (roundTimer > 0.0f)
            {
                roundTimer -= Time.deltaTime;
            }
            else if (myGameManager.startRound == false)
            {
                //Round starts
                myGameManager.startRound = true;

                // Add score for surviving round if player is alive

                // Reset round timer till next wave
                roundTimer = 30;

            }
        }
        #endregion

        #region Player controls / Movement
        Vector2 playerVelocity = myRigidBody2D.velocity;
        
        // Player Input
        if (Input.GetKey(GetPlayerKey(CONTROLS.RIGHT)))
        {
            playerVelocity += Vector2.right;
        }
        else if (Input.GetKey(GetPlayerKey(CONTROLS.LEFT)))
        {
            playerVelocity += Vector2.left;
        }
        else if (Input.GetKeyDown(GetPlayerKey(CONTROLS.JUMP)) && !isPlayerJumping)
        {
            // Jump
            playerVelocity += (Vector2.up * 8.0f);

            // Set jump to true
            isPlayerJumping = true;
        }
        else if(Input.GetKeyDown(GetPlayerKey(CONTROLS.BSCATK)))
        {
            // Do basic attack
        }
        else if(Input.GetKeyDown(GetPlayerKey(CONTROLS.SPCATK)))
        {
            // Do special attack
        }

        // Clamp players velocity (player not too fast)
        playerVelocity.x = Mathf.Clamp(playerVelocity.x, -3, 3);
        playerVelocity.y = Mathf.Clamp(playerVelocity.y, -20, 20);

        // Set the velocity of the player
        myRigidBody2D.velocity = playerVelocity;

        // Player controls based on player 1 or 2
        KeyCode GetPlayerKey(CONTROLS requestedControl)
        {
            switch (requestedControl)
            {
                case CONTROLS.LEFT:
                    {
                        if (playerIndex == 1)
                        {
                            return KeyCode.A;
                        }
                        if (playerIndex == 2)
                        {
                            return KeyCode.LeftArrow;
                        }
                        break;
                    }
                case CONTROLS.RIGHT:
                    {
                        if (playerIndex == 1)
                        {
                            return KeyCode.D;
                        }
                        if (playerIndex == 2)
                        {
                            return KeyCode.RightArrow;
                        }
                        break;
                    }
                case CONTROLS.JUMP:
                    {
                        if (playerIndex == 1)
                        {
                            return KeyCode.W;
                        }
                        if (playerIndex == 2)
                        {
                            return KeyCode.UpArrow;
                        }
                        break;
                    }
            }
            // Default return
            return KeyCode.RightWindows;
        }
        #endregion
    }

    // Deal with collision between the player (as this is player script) and the tags of other objects
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            isPlayerJumping = false;
        }
        else if (coll.gameObject.tag == "Player")
        {
            // When the 2 players collide

        }
        else if (coll.gameObject.tag == "Enemy")
        {
            if (playerIndex == 1)
            {
                //EnemyScript enemyScript = enemyObject.GetComponent<EnemyScript>();
                //if (enemyScript.health < 1)
                player1Score += 20;
            }
            else
            {
                player2Score += 20;
            }
        }
    }

    // update GUI based on the if arguments
    void OnGUI()
    {
        if (beginTimer > 0.0f)
        {
            // timer for pre-round
            GUI.Label(new Rect(550, 0, 100, 20), beginTimer.ToString());
        }
        else
        {
            // round timer
            GUI.Label(new Rect(550, 0, 100, 20), roundTimer.ToString());
        }

        // Player scores
        GUI.Label(new Rect(40, 200, 100, 20), "P1: " + player1Score.ToString());
        GUI.Label(new Rect(1060, 200, 100, 20), "P2: " + player2Score.ToString());

        // Player win message
        if (player1Score > 199)
        {
            GUI.Label(new Rect(550, 400, 200, 20), "PLAYER 1 WINS!");
        }
        else if (player2Score > 199)
        {
            GUI.Label(new Rect(550, 400, 200, 20), "PLAYER 2 WINS!");
        }
    }
}
