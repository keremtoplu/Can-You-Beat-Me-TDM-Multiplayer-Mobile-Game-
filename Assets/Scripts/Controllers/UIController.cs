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
    private GameObject inGameUI;

    [SerializeField]
    private PlayerData playerData;

    private void Start()
    {

        loadingPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        inGameUI.SetActive(false);
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInputName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInputName.text);
    }

    public void OrganizePanels()
    {
        lobbyPanel.SetActive(false);
        loadingPanel.SetActive(false);
        inGameUI.SetActive(true);
    }
    public void OpenLobbyPanel()
    {
        OrganizePanels();
        inGameUI.SetActive(false);
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
