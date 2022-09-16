using UnityEngine;
using Photon.Pun;
public class CreateAndJoin : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private GameObject[] enviroment;


    [SerializeField]
    private Vector3[] enviromentDesiredPos;


    public override void OnJoinedRoom()
    {
        UIController.Instance.OrganizePanels();
        PlayerController.Instance.InıtPlayer();
    }
    public override void OnCreatedRoom()
    {
        for (int i = 0; i < enviroment.Length; i++)
        {
            PhotonNetwork.Instantiate(enviroment[i].name, enviromentDesiredPos[i], Quaternion.identity);
        }
    }

}
