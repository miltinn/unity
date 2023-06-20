using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeuJogo.Bus.Manager
{


    public class BusManager : MonoBehaviour
    {
        public BusSetup[] busSetups;
    }

    [System.Serializable]

    public class BusSetup
    {
        public GameObject bus;
        public int door;
    }
}