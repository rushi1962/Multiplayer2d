using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Photon.MonoBehaviour
{
    public GameObject bulletPrefab;
    public PhotonView photonView;
    public InputManager inputManager;
    int _frameCount;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = (InputManager)FindObjectOfType(typeof(InputManager));
        _frameCount = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if ((inputManager.horizontalInput > 0.5f || inputManager.horizontalInput < -0.5f || inputManager.verticalInput > 0.5f || inputManager.verticalInput < -0.5f) && photonView.isMine)
        {
            //StartCoroutine(InstantiateBullets());
            if (_frameCount == 10)
            {
                GameObject newBullet = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, transform.rotation, 0);
                newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
                _frameCount = 0;
            }
            _frameCount++;

        }
        else
        {
            _frameCount = 10;
        }
    }
    void SpawnBullets()
    {

        GameObject newBullet = PhotonNetwork.Instantiate(bulletPrefab.name, transform.position, transform.rotation, 0);
       //yield return new WaitForSeconds(0.5f);
        newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * 500f);
        // yield return new WaitForSeconds(0.5f);

    }
    IEnumerator InstantiateBullets()
    {

        Invoke("SpawnBullets",0.5f);
        yield return new WaitForSeconds(0.5f);

    }
}
