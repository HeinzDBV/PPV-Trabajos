using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
     if(other.tag == "Enemy")
        {
            //acá haré daño

            //si enemy tiene metodo get hurt, llamar al metodo de ese script
            //si no tiene metodo, pero tiene propiedad publica puntos de vida, se debe alterar directamente, "enemy.puntos_vida"
        }
    }
}
