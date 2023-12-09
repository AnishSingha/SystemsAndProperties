using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : ActionsAndEvents
{
    

    PlayerMove playerMove;
    PlayerJump playerJump;
    PlayerDash playerDash;


    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
    }
    private void Update()
    {
        playerMove.Move();
        playerJump.Jump();
       // playerDash.Dash();
    }

    
}
