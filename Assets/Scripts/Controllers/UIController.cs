using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class UIController : Singleton<UIController>
{
    [SerializeField]
    private TMPro.TMP_InputField createInputName;

    [SerializeField]
    private TMPro.TMP_InputField joinInputName;
    [SerializeField]
    private TMPro.TMP_InputField nickName;

    [SerializeField]
    private GameObject lobbyPanel;

    [SerializeField]
    private TMPro.TMP_Dropdown choosedTeam;

    [SerializeField]
    private GameObject loadingPanel;

    [SerializeField]
    private PlayerData playerData;

    private void Start()
    {

        loadingPanel.SetActive(true);
        lobbyPanel.SetActive(false);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInputName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputName.text);
    }

    public void AllPanelClose()
    {
        lobbyPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }
    public void OpenLobbyPanel()
    {
        AllPanelClose();
        lobbyPanel.SetActive(true);
    }

    public void NickNameChanged()
    {
        PhotonNetwork.NickName = nickName.text;
    }
    public void ChoosedTeamChanged()
    {

        if (choosedTeam.value == 0)
            playerData.PlayerTeam = Team.TeamA;
        else if (choosedTeam.value == 1)
            playerData.PlayerTeam = Team.TeamB;

    }
}
