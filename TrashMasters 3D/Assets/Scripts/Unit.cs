using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour
{

    private int HP;    
    private int woundLevel;

    public int maxHP;
    public int damage;
    public int armor;
    public int hitChance;

    private float effectiveArmorMultiplier;
    private GameObject healthBar;

    void Start()
    {
        healthBar = transform.Find("Health Bar").gameObject;

        /* calculo multiplicador de daño en base al valor porcentual de armadura.

           0 armor  =>  100% daño  =>  EAM: 1
           5 armor  =>  95% daño  =>  EAM: 0.99
           10 armor  =>  90% daño  =>  EAM: 0.95
           100 armor  =>  0% daño  =>  EAM: 0;
        */

        effectiveArmorMultiplier = 1 - (damage / 100);
    }

    void Update()
    {
        woundLevel = (HP / maxHP) * 100;  // Usado por el Medico para determinar cantidad de curación
    }


    public bool Damage(Unit damageSource, int rawDamage) // Devuelve si la unidad murió
    {
        Debug.Log( this.gameObject.name + "is being damaged.");
        if (HP > rawDamage * effectiveArmorMultiplier)
        {
            HP -= (int)(rawDamage * effectiveArmorMultiplier);
            return false;
        }
        else {
            HP = 0;
            KillUnit();
            return true;
        }
        // MODIFICAR BARRA DE VIDA
    }


    public void Heal(GameObject healSource, int rawHealing)
    {
        if (maxHP <= HP + rawHealing)
        {
            HP += rawHealing;
        }
        else {
            HP = maxHP;
        }
        // MODIFICAR BARRA DE VIDA
    }


    private void KillUnit()
    {
        // AÑADIR ANIMACIONES
        Destroy(this.gameObject);
    }

    public void Attack(Unit objective) // ESTE NO IRIA EN UNIT SINO EN LOS HIJOS QUE PUEDAN ATACAR. LO MISMO PARA HEAL
    {
        if(Random.value <= hitChance/100 )
        {
            objective.Damage(this, damage);
            // AÑADIR ANIMACIONES, PROYECTILES, ETC 
        } else
        {
            // MANEJAR FALLO
        }        
    }
}