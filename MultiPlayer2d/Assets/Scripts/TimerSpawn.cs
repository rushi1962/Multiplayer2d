using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject timer;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Timer"))
        {
            GameObject newTimer = PhotonNetwork.Instantiate(timer.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
            newTimer.transform.parent = transform;
        }
    }
}
