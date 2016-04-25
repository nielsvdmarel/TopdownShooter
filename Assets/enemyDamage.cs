using UnityEngine;
using System.Collections;




public class enemyDamage : MonoBehaviour
{


    public int maxEnemyHealth=1000;
   public    int theDamage = 5;
    [SerializeField]
    public int currentHealth;

    void Start()
    {
        currentHealth = maxEnemyHealth;
    }

    public void ouchThatHurts()
    {
        print("hit" + currentHealth);
        currentHealth -=5;
        print("auw" + currentHealth);
        //theDingDongIsDead();
        if (currentHealth <= 0)
        {
            theDingDongIsDead();    
        }
        
    }

    void theDingDongIsDead()
    {
        
        Destroy(gameObject);

        // enemyHealth = 1000;
    }
 



}