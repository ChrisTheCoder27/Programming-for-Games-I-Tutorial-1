using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class is not a child of MonoBehavior so it's not a game object, and it's static so things are just being stored
public static class Inputs
{
    private static PlayerAction _actions;
    private static PlayerController _owner;

    public static void BindNewPlayer(PlayerController player)
    {
        _owner = player;
    }
    
    public static void Init(PlayerController player)
    {
        _actions = new PlayerAction();
        BindNewPlayer(player);
        _actions.Player.Move.performed += ctx => _owner.Move(ctx.ReadValue<Vector2>());
        _actions.Player.Jump.performed += ctx => _owner.Jump();

        _actions.Permanent.Enable();

        PlayMode();
    }

    public static void PlayMode()
    {
        _actions.Player.Enable();
        _actions.UI.Disable();
    }

    public static void SetUIControls()
    {
        _actions.UI.Enable();
        _actions.Player.Disable();
    }
}