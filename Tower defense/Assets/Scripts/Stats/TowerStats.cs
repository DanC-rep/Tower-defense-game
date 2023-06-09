using UnityEngine;

public class TowerStats : ObjStats
{
    [SerializeField] private int diamonds;
    [SerializeField] private float moneyPerTime;

    public override void TakeDamage(int damage)
    {
        if (health <= 0 || health - damage / 2 <= 0)
        {
            health -= damage / 2;
            healthBar.SetHealth(health);

            animator.SetTrigger("0%");
        }
        else
        {
            health -= damage / 2;
            healthBar.SetHealth(health);

            if (health <= startHealth * 75 / 100 && health > startHealth * 50 / 100)
            {
               animator.SetTrigger("75%");
            }
            else if (health <= startHealth * 50 / 100 && health > startHealth * 25 / 100)
            {
                animator.SetTrigger("50%");
            }
            else if (health <= startHealth * 25 / 100 && health > 0)
            {
                animator.SetTrigger("25%");
            }
        }
        GlobalEventManager.SendTowerDamaged();
    }

    private void DestroyTower()
    {
        Destroy(gameObject);

        PlayerSettings.instance.AddDiamonds(diamonds);

        GlobalEventManager.SendTowerDestroy(gameObject.tag);
    }

    public int GetAddedDiamonds()
    {
        return diamonds;
    }

    public float GetMoneyPerTime()
    {
        return moneyPerTime;
    }
}
