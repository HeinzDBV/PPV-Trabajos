using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitch : MonoBehaviour
{
    public GameObject Terminar;
    public GameObject Iniciar;
    // Start is called before the first frame update

    public void IniciarEnemigo()
    {
        Iniciar.SetActive(true);
    }
        public void TerminarEnemigo()
    {
        Terminar.SetActive(false);
    }
}
