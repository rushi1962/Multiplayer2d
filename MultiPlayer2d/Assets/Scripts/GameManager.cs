using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab, player,flagManagerPrefab;
    public GameObject startPanel;
    public GameObject sceneCamera;
    public Vector3[] spawnPositions;
    public Vector3[] flagPositions;
    // public GameObject pauseMenuUI;
    public GameObject playerFeed;
    public Text timerText,winnerSentence;
    public float timerLength = 120f;
    public GameObject feedGrid;
    public GameObject deadPanel, gameOverPanel;
    public bool playerDead;
    private bool _paused = false;
    public bool gameStarted;
    public string winner;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SpawnPlayer", 3f);
        playerDead = false;
        gameStarted = false;
        
        float randomValue = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[Random.Range(0,3)], Quaternion.identity, 0);
        
       
    }
    // Update is called once per frame
    void Update()
    {

        // CheckInput();
        if(!gameStarted)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            if(players.Length>=4)
            {
                Invoke("SpawnPlayer",1f);
                gameStarted = true;
            }
        }
        
        if (!GameObject.FindGameObjectWithTag("FlagManager"))
        {
            PhotonNetwork.Instantiate(flagManagerPrefab.name, flagPositions[Random.Range(0, 3)], Quaternion.identity, 0);
        }
       /* if (GameObject.FindGameObjectsWithTag("FlagManager").Length > 1)
        {
            GameObject[] flags = GameObject.FindGameObjectsWithTag("FlagManager");
            for (int i = 1; i < flags.Length; i++)
            {
                PhotonNetwork.Destroy(flags[i]);
            }
        }*/
        if (!player && !playerDead)
        {
            GetPlayer();
        }
       if (player && player.GetComponent<PhotonView>().isMine)
        {
            if (CheckHealth() < 10f)
            {
                playerDead = true;
            }
        }
        if (playerDead)
        {
            sceneCamera.SetActive(true);
            if(player.GetComponent<Player>().hasFlag)
            {
                flagManagerPrefab.GetComponent<FlagManager>().SpawnFlag(player.transform.position);
            }
            PhotonNetwork.Destroy(player);
            deadPanel.SetActive(true);
            playerDead = false;
            float randomValue = Random.Range(-1f, 1f);
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPositions[Random.Range(0, 3)], Quaternion.identity, 0);
            Invoke("RespawnPlayer",3);
        }
        
    }
    void FixedUpdate()
    {
        if(gameStarted)
        {
            timerLength -= Time.fixedDeltaTime;
            timerText.text = timerLength.ToString("0.0");
        }
        if(timerLength<=0f)
        {
            timerText.text = "0:0";
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach(GameObject each in players)
            {
                
                if(each.GetComponent<Player>().hasFlag)
                {
                    winner = each.GetComponent<Player>().playerName;
                }
                each.SetActive(false);
            }
            gameOverPanel.SetActive(true);
            sceneCamera.SetActive(true);
            winnerSentence.text = winner + " won!";
            Invoke("Restart",3f);
        }
    }
    void Restart()
    {
        PhotonNetwork.LeaveRoom();
       // PhotonNetwork.LoadLevel("MainMenu");
        PhotonNetwork.LoadLevel("MainMenu");
    }
    float CheckHealth()
    {
        return player.GetComponent<Health>().health;
    }
    void GetPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject eachPlayer in players)
        {
            print(eachPlayer.name);
            if (eachPlayer.GetComponent<PhotonView>().isMine)
            {
                player = eachPlayer;
            }
        }
    }
    /* void CheckInput()
     {
         if (_paused && Input.GetKeyDown(KeyCode.Escape))
         {
             pauseMenuUI.SetActive(false);
             _paused = false;
         }
         else if (!_paused && Input.GetKeyDown(KeyCode.Escape))
         {
             pauseMenuUI.SetActive(true);
             _paused = true;
         }
     }*/
    public void SpawnPlayer()
    {
        
        startPanel.SetActive(false);
        sceneCamera.SetActive(false);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("MainMenu");
    }
    public void OnPhotonPlayerConnected(PhotonPlayer player)
    {
        GameObject textFeed = Instantiate(playerFeed, new Vector2(0, 0), Quaternion.identity);
        textFeed.transform.SetParent(feedGrid.transform, false);
        textFeed.GetComponent<Text>().text = player.name + " joined the Game";
    }
    public void OnPhotonPlayerDisconnected(PhotonPlayer player)
    {
        GameObject textFeed = Instantiate(playerFeed, new Vector2(0, 0), Quaternion.identity);
        textFeed.transform.SetParent(feedGrid.transform, false);
        textFeed.GetComponent<Text>().text = player.name + " left the Game";
        textFeed.GetComponent<Text>().color = Color.red;
    }
   void RespawnPlayer()
    {
        
        
        sceneCamera.SetActive(false);
        deadPanel.SetActive(false);
    }
}
