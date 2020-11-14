using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Parkour
{
    public class Portal : MonoBehaviour
    {
        // Start is called before the first frame update

        public Transform EndPoint;
        private PhotonView PV;

        void Awake()
        {
            PV = GetComponent<PhotonView>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                GameObject target = other.gameObject;
                InputReceive IR = target.GetComponent<InputReceive>();
                if (IR != null)
                {
                    int ItemID = target.GetComponent<PhotonView>().ViewID;
                    PV.RPC("Teleport", RpcTarget.All, new object[] { ItemID });
                }
            }
        }

        [PunRPC]
        void Teleport(int ItemID)
        {
            Debug.Log("teleport");
            GameObject Player = PhotonView.Find(ItemID).gameObject;
            Player.transform.position = EndPoint.position;
        }

    }
}