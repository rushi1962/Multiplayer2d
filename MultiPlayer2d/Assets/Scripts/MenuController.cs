using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string _versionName = "0.1";
    [SerializeField] private GameObject _userNamePanel;
    [SerializeField] private GameObject _connectPanel;
    [SerializeField] private InputField _usernameInput;
    [SerializeField] private InputField _joinGameInput;
    [SerializeField] private InputField _createGameInput;
    [SerializeField] private GameObject _StartButton;
    void Awake()
    {
       // PhotonNetwork.Disconnect();
        PhotonNetwork.ConnectUsingSettings(_versionName);
    }
    void Start()
    {
        _userNamePanel.SetActive(true);
    }
    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainGame");
    }
    public void ChangeOnUsernameInput()
    {
        if (_usernameInput.text.Length > 3)
        {
            _StartButton.SetActive(true);
        }
        else
        {
            _StartButton.SetActive(false);
        }
    }
    public void SetUserName()
    {
        _userNamePanel.SetActive(false);
        PhotonNetwork.playerName = _usernameInput.text;
    }
    public void CreateGame()
    {
        PhotonNetwork.CreateRoom(_createGameInput.text, new RoomOptions() { maxPlayers = 5 }, null);
    }
    public void JoinGame()
    {
        RoomOptions room = new RoomOptions();
        room.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_joinGameInput.text, room, TypedLobby.Default);
    }
}
