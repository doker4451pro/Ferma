using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerCollector playerCollector;
    [SerializeField] private PlayerCreator playerCreator;
    [SerializeField] private PlayerSower playerSower;

    [SerializeField]
    private PlayerState state;

    private bool mouseDown = false;

    public void ChahgeState(int i) 
    {
        state = (PlayerState)i;
    }
    public void ChangeState(PlayerState state) 
    {
        this.state = state;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            mouseDown = true;
        }
        if (Input.GetMouseButtonUp(0)) 
        {
            mouseDown = false;
        }
        if (mouseDown) 
        {
            MouseButtonDown(state);
        }
    }

    private void MouseButtonDown(PlayerState playerState) 
    {
        switch (playerState)
        {
            case PlayerState.None: break;
            case PlayerState.Collector:
                break;
            case PlayerState.Creator:
                playerCreator.CustomOnMouseDown();
                break;
            case PlayerState.Sower:
                playerSower.CustomOnMouseDown();
                break;
        }
    }
}
