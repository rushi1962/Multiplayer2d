using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLights : Photon.MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointLight, spotLight,pointer;
    public PhotonView photonView;
    void Start()
    {
        if(photonView.isMine)
        {
            GameObject newPointLight = Instantiate(pointLight, transform.position, transform.rotation);
            GameObject newSpotLight = Instantiate(spotLight, transform.position, transform.rotation);
            newPointLight.transform.parent = transform;
            newSpotLight.transform.parent = pointer.transform;
            newSpotLight.transform.localPosition = new Vector3(0f, 2f, 0f);
        }
        
    }

    
}
