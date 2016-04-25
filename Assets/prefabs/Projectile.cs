using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    private float _speed;


    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()

    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);


    }

    public void SetSpeed(float value)
    {
        _speed = value;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy4"))
        {
            enemyDamage ed = other.GetComponent<enemyDamage>();
            ed.ouchThatHurts();


            Destroy(gameObject);

            
            

         

           // Destroy(other.gameObject);

        }
        else if (other.CompareTag("obstacle"))
        {



            Destroy(gameObject);
        }

        
        

        

    }
}
