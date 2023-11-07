using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class is not a child of MonoBehavior so it's not a game object, and it's static so things are just being stored
public static class Inputs
{
    private static PlayerAction _actions;
    private static PlayerController _owner;
    private static Weapon _weapon;

    public static void BindNewPlayer(PlayerController player)
    {
        _owner = player;
    }

    public static void NewWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }
    
    public static void Init(PlayerController player)
    {
        _actions = new PlayerAction();
        BindNewPlayer(player);

        // Bind Actions
        _actions.Player.Move.performed += ctx => _owner.Move(ctx.ReadValue<Vector2>());
        _actions.Player.Jump.performed += ctx => _owner.Jump();
        _actions.Player.Look.performed += ctx => _owner.SetLook(ctx.ReadValue<Vector2>());
        _actions.Player.Shoot.performed += ctx => _owner.Shoot();
        _actions.Player.SwitchGun1.performed += ctx => _owner.SwitchToShotgun();
        _actions.Player.SwitchGun2.performed += ctx => _owner.SwitchToSniper();
        _actions.Player.SwitchGun3.performed += ctx => _owner.SwitchToSubGun();
        _actions.Player.SwitchGun4.performed += ctx => _owner.SwitchToBurstGun();
        //_actions.Player.Reload.performed += ctx => _weapon.Reload();

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
