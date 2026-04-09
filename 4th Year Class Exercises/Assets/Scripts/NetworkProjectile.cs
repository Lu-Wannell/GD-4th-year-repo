using UnityEngine;
using Unity.Netcode;
using System.Runtime.CompilerServices;

public class NetworkProjectile : NetworkBehaviour
{
    [SerializeField] private float lifeTime = 3.0f; // Seconds before auto-despawn


    public override void OnNetworkSpawn()
    {
        //Only the server should Despawn network objects (authoritative)
        if (IsServer)
            Invoke(nameof(Despawn), lifeTime);
    }


    private void OnCollisionEnter(Collision other)
    {
        //Only the server should decide when the projectile disappears
        if (IsServer)
            Despawn();
    }

    private void Despawn()
    {
        //Despawn removes it across the network (for everyone)
        if (NetworkObject && NetworkObject.IsSpawned)
            NetworkObject.Despawn();
    }
    
}
