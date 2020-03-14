using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;


    public event System.Action<int, int> OnHealthChanged;




    private void Awake()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage (int damage)
    {
        Debug.Log("ORIGIN " + armor.GetValue() + " damage.");
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);


        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }


        if ( currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        //die in some way
        //this is for overwritting
        Debug.Log(transform.name + " died.");
    }

}
