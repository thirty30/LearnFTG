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
            Main.GetSingleton().PlaySound("hit");
            this.PlayerEvent.PlayerData.Hurt(0.17f);    //different damage
        }

        if (other.tag == "Kick" && this.PlayerEvent.KickCollider != other.gameObject)
        {
            Main.GetSingleton().PlaySound("hit");
            this.PlayerEvent.PlayerData.Hurt(0.23f);    //different damage
        }

        if (other.tag == "FireBall")
        {
            Main.GetSingleton().PlaySound("hit");
            this.PlayerEvent.PlayerData.Hurt(0.3f); //different damage
        }
    }
}
