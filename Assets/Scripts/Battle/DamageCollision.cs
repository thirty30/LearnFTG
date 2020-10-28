using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public AnimationEvent PlayerEvent;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boxing" && this.PlayerEvent.BoxingCollider != other.gameObject)
        {
            this.PlayerEvent.PlayerData.Hurt(0.17f);
        }

        if (other.tag == "Kick" && this.PlayerEvent.KickCollider != other.gameObject)
        {
            this.PlayerEvent.PlayerData.Hurt(0.23f);
        }
    }
}
