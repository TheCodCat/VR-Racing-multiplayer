using UnityEngine;
using Fusion;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
public class SerXROrigin : NetworkBehaviour 
{
    [SerializeField] private Transform point;
    [SerializeField] private TeleportationAnchor teleportationAnchor;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            teleportationAnchor.RequestTeleport();
            var player = FindAnyObjectByType<XROrigin>();
            player.transform.SetParent(point, false);
            //player.transform.localPosition = Vector3.zero;
        }
    }
}
