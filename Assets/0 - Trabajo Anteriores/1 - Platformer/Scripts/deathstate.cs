using UnityEngine;

public class deathstate : MonoBehaviour
{
    public bool isinDead;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Platforms") || other.gameObject.CompareTag("Enemy"))
        {   
            isinDead = true;
        }
        else
        {
            isinDead = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        isinDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
