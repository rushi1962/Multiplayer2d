using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flag;
    public Vector3[] flagPositions;
    //public bool hasSpawned;
    
    void Start()
    {
        if(!GameObject.FindGameObjectWithTag("Flag"))
        {
            SpawnFlag(flagPositions[Random.Range(0, 3)]);
        }
       /* if (GameObject.FindGameObjectsWithTag("Flag").Length > 1)
        {
            GameObject[] flags = GameObject.FindGameObjectsWithTag("FlagManager");
            for (int i = 1; i < flags.Length;i++ )
            {
                PhotonNetwork.Destroy(flags[i]);
            }
        }*/

    }

    // Update is called once per frame
    public void SpawnFlag(Vector3 position)
    {
        PhotonNetwork.Instantiate(flag.name,position , Quaternion.identity, 0);
    }
}
