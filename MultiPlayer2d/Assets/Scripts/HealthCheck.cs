using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Health player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale=new Vector3(player.health/100f,1f,1f);
    }
}
