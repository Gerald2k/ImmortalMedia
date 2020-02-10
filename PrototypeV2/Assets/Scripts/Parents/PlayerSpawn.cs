using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    GameManager myGameManager;
    public GameObject parent;
    public GameObject player1;
    public GameObject player2;

    Vector2 player1SpawnPlace = new Vector2(-7, -3);
    Vector2 player2SpawnPlace = new Vector2(7, -3);
    private int playerindex;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player1, player1SpawnPlace, Quaternion.identity, parent.transform);
        Instantiate(player2, player2SpawnPlace, Quaternion.identity, parent.transform);
        myGameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
// Bomb tag code
/*if (noBacksiesTimer <= 0.0f)
{
    if (playerWithBomb == playerIndex)
    {
        PlayerControls otherPlayersControls = coll.gameObject.GetComponent<PlayerControls>();
        playerWithBomb = otherPlayersControls.playerIndex;
    }
    else
    {
        playerWithBomb = playerIndex;
    }

    noBacksiesTimer = MAX_TIME_FOR_NO_BACKSIES;
}*/
