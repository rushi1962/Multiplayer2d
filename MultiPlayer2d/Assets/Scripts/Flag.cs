using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    //public PhotonView photonView;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<Player>().hasFlag = true;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
