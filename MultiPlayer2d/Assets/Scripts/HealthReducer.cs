using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReducer : Photon.MonoBehaviour
{
    public PhotonView photonView;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player"&&!photonView.isMine)
        {
            other.gameObject.GetComponent<Health>().health -= 20f;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
