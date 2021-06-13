using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public GameObject healthBar;
    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine)
        {
            healthBar.transform.localScale = new Vector3(health / 100f, 1f, 1f);
        }

    }
}
