using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float time = 180f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        gameObject.GetComponent<Text>().text=time.ToString("0.00");
    }
}
