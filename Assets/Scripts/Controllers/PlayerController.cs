using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerController : Singleton<PlayerController>
{

    [SerializeField]
    private Vector3 teamADesPos;

    [SerializeField]
    private Vector3 teamBDesPos;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private FixedJoystick fixedJoystick;

    private TextMeshPro teamText;
    private Vector3 playerDesiredPos;
    private Player playerVar;
    private Transform missileDesiredPos;
    private Transform missilePoint;

    public FixedJoystick FixedJoystick => fixedJoystick;
    public Transform MissileDesiredPos => missileDesiredPos;
    public Transform MissilePoint => missilePoint;
    void Start()
    {
        playerData.PlayerTeam = Team.TeamA;

    }

    public void InıtPlayer()
    {
        if (playerData.PlayerTeam == Team.TeamA)
            playerDesiredPos = teamADesPos;
        else
            playerDesiredPos = teamBDesPos;

        var player = PhotonNetwork.Instantiate(playerPrefab.name, playerDesiredPos, Quaternion.identity);
        missileDesiredPos = player.transform.GetChild(0);
        missilePoint = player.transform.GetChild(1);
        MissileController.Instance.InıtMissile();
        var playerView = player.GetComponent<PhotonView>();
        playerVar = player.GetComponent<Player>();
        teamText = player.transform.GetChild(2).GetComponent<TextMeshPro>();
        teamText.text = playerView.Owner.NickName;

        if (!playerView.IsMine)
        {
            playerView.RPC("SetPlayerVarriables", RpcTarget.Others);
        }

    }

    public void Reborn(Player player)
    {
        player.gameObject.SetActive(false);
        LeanTween.delayedCall(3f, () =>
        {
            if (playerData.PlayerTeam == Team.TeamA)
            {
                player.transform.position = teamADesPos;
                player.gameObject.SetActive(true);
            }
            else
            {
                player.transform.position = teamBDesPos;
                player.gameObject.SetActive(true);
            }

        });
    }

    [PunRPC]
    public void SetPlayerVarriables()
    {
        Debug.Log(playerData.PlayerTeam);
        playerVar.Health = playerData.PlayerHealth;
        playerVar.Team = playerData.PlayerTeam;
    }
}
