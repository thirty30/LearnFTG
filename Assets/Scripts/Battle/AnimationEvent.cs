using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject BoxingCollider;
    public GameObject KickCollider;
    public GameObject BodyCollider;

    public Player PlayerData;

    private void Start()
    {
        this.BoxingCollider.gameObject.SetActive(false);
        this.KickCollider.gameObject.SetActive(false);
        this.BodyCollider.gameObject.SetActive(true);
    }

    public void StartBoxing()
    {
        this.BoxingCollider.gameObject.SetActive(true);
    }

    public void EndBoxing()
    {
        this.BoxingCollider.gameObject.SetActive(false);
    }

    public void StartKick()
    {
        this.KickCollider.gameObject.SetActive(true);
    }

    public void EndKick()
    {
        this.KickCollider.gameObject.SetActive(false);
    }
}
