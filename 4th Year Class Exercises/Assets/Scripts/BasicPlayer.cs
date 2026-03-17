using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicPlayer : NetworkBehaviour
{
    private float speed = 5f;
    private PlayerInput playerInput;
    private InputAction moveAction;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return;

        //Get playerinput on THIS spawned player object
        playerInput = GetComponent<PlayerInput>();

        //Grab the action by name from the controls action asset
        moveAction = playerInput.actions["Move"];

        //Enable the map/actions for the local owner only
        playerInput.enabled = true;
        moveAction.Enable();
    }

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) return;
    }
   
}
