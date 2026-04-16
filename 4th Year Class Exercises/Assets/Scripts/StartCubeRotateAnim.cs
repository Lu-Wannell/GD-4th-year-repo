using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Components;

public class StartCubeRotateAnim: NetworkBehaviour
{
    private NetworkAnimator netAnim;

    public override void OnNetworkSpawn()
    {
        netAnim = GetComponent<NetworkAnimator>();

        // only the server tells everyone to start - On this machine, is the NGO server running?
        if(IsServer)
        {
            // Trigger is synchronised by network Anuimator
            netAnim.SetTrigger("StartRotate");
        }
    }
}
