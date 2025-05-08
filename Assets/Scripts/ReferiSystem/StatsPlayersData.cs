using UnityEngine;

public class StatsPlayersData : MonoBehaviour
{


    //[SerializeField] private CalculateNumbers calculate;

    private int _playerHP = 0;
    private int _enemyHP = 0;
     
    private int _playerDamage = 0;
    private int _enemyDamage = 0;

    private int _playerPower = 0;
    private int _enemyPower = 0;

    public int PlayerHP { get => _playerHP; private set => _playerHP = value; }
    public int EnemyHP { get => _enemyHP; private set => _enemyHP = value; }
    public int PlayerDamage { get => _playerDamage; private set => _playerDamage = value; }
    public int EnemyDamage { get => _enemyDamage; private set => _enemyDamage = value; }
    public int PlayerPower { get => _playerPower; set => _playerPower = value; }
    public int EnemyPower { get => _enemyPower; set => _enemyPower = value; }





    private int minusEntity(int Entity, int damage)
    {
        if (damage < 0)
        {
            Entity = Entity - damage;
        }

        return Entity < 0 ? 0 : Entity;
    }

    private int addEntity(int Entity, int heal)
    {
        if (heal > 0)
        {
            return Entity += heal;
        }

        return Entity;

    }






    public int minusPlayerHp(int damage)
    {
        return minusEntity(PlayerHP, damage);
    }

    public int minusEnemyHp(int damage)
    {
        return minusEntity(EnemyHP, damage);
    }


    public int addPlayerHP(int heal)
    { 
        return addEntity(PlayerHP, heal); 
    }

    public int addEnemyHP(int heal)
    {
        return addEntity(EnemyHP, heal);
    }



    public int minusPlayerDamage(int damage)
    {
        return minusEntity(PlayerDamage, damage);
    }

    public int minusEnemyDamage(int damage)
    {
        return minusEntity(EnemyDamage, damage);
    }


    public int addPlayerDamage(int damage)
    {
        return addEntity(PlayerDamage, damage);
    }

    public int addEnemyDamage(int damage)
    {
        return addEntity(EnemyDamage, damage);
    }



    public int minusPlayrePower(int power)
    {
        return minusEntity(PlayerPower, power);
    }

    public int minusEnemyPower(int power)
    {
        return minusEntity(EnemyPower, power);
    }


    public int addPlayrePower(int power)
    {
        return addEntity(PlayerPower, power);
    }

    public int addEnemyPower(int power)
    {
        return addEntity(EnemyPower, power);
    }






    public void resetPlayerHP()
    {
        PlayerHP = 0;
    }

    public void resetEnemyHP()
    {
        EnemyHP = 0;
    }

    public void resetPlayerDamage()
    {
        PlayerDamage = 0;
    }
    public void resetEnemyDamage()
    {
        EnemyDamage = 0;
    }
    public void resetPlayrePower()
    {
        PlayerPower = 0;
    }
    public void resetEnemyPower()
    {
        EnemyPower = 0;
    }








}
