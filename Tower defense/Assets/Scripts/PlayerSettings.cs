using System.Collections;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    #region Singleton
    public static PlayerSettings instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
    #endregion

    [SerializeField] private int money;
    [SerializeField] private int diamonds;

    [SerializeField] private int moneyPerTime;
    [SerializeField] private int timeToWaitMoney;
    [SerializeField] private int startTimeToGetMoneySpawn;

    private void Start()
    {
        InvokeRepeating("AddMoneyPerTime", startTimeToGetMoneySpawn, timeToWaitMoney);
    }

    public void AddMoney(int addMoney)
    {
        money += addMoney;
    }

    public int GetMoney()
    {
        return money;
    }

    public void AddDiamonds(int _diamonds)
    {
        diamonds += _diamonds;
    }

    public int GetDiamonds()
    {
        return diamonds;
    }

    public void DecreaseDiamonds(int decreaseDiamonds)
    {
        if (diamonds - decreaseDiamonds >= 0)
        {
            diamonds -= decreaseDiamonds;
        }
    }


    public void DecreaseMoney(int decreaseMoney)
    {
        if (money - decreaseMoney >= 0)
        {
            money -= decreaseMoney;
        }
    }

    private void AddMoneyPerTime()
    {
        AddMoney(moneyPerTime);
    }
}
