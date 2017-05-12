namespace Player_Three
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PrefabClone : MonoBehaviour
    {

        public GameObject playerPrefabObject;
        public GameObject groundPrefabObject;
        public GameObject airPrefabObject;

        private GameObject m_PlayerPrefabObjectClone;
        private GameObject m_GroundPrefabObjectClone;
        private GameObject m_AirPrefabObjectClone;

        void Start()
        {
            m_PlayerPrefabObjectClone = Instantiate(playerPrefabObject, transform.position, Quaternion.identity);
            m_GroundPrefabObjectClone = Instantiate(groundPrefabObject, transform.position, Quaternion.identity);
            m_AirPrefabObjectClone = Instantiate(airPrefabObject, transform.position, Quaternion.identity);
        }
    }
}