using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public GameObject BoxingCollider;   //boxing atk
    public GameObject KickCollider;     //kick atk
    public GameObject BodyCollider;     //body use to take damage
    public GameObject FireBallPrefab;

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

    public void FireBall()
    {
        GameObject obj = GameObject.Instantiate(this.FireBallPrefab);
        Vector3 pos = this.transform.position;
        pos.y = 1.4f;
        pos.x += this.PlayerData.Avatar.transform.forward.x * 1.6f;
        obj.transform.position = pos;
        obj.GetComponent<FireBall>().Dir = this.PlayerData.Avatar.transform.forward;
    }

    public void SetState(int aState)
    {
        this.PlayerData.State = (EPlayerState)aState;
    }
}
