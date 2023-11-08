using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScript : MonoBehaviour
{
    [SerializeField] public float m_HP;
    [SerializeField] protected int m_TP;
    [SerializeField] public int m_Attack;
    [SerializeField] protected int m_Defence;
    [SerializeField] public int m_SpecialAttack;
    [SerializeField] protected int m_SpecialDefence;
    protected bool defenseActivated;

    public event System.Action<float> HPreduce;
    public void Attack(float hpDecrease)
    {
        Debug.Log(hpDecrease);
        //if (defenseActivated)
        //{
        //    hpDecrease = hpDecrease * 0.5f * (m_Defence / 100);
        //}
        //else
        //{
        //    hpDecrease = hpDecrease * (m_Defence / 100);
        //}
        m_HP -= hpDecrease;
        HPreduce?.Invoke(m_HP);
        
    }

    public void SpecialAttack(float hpDecrease)
    {
        if (defenseActivated)
        {
            hpDecrease = hpDecrease * 0.5f * (m_Defence / 100);
        }
        else
        {
            hpDecrease = hpDecrease * (m_Defence / 100);
        }
        m_HP -= hpDecrease;
    }

    public float GetHp()
    {
        return m_HP;
    }

    public float GetTP()
    {
        return m_TP;
    }

    public void SetTP(int TPdecrease)
    {
        m_TP -= TPdecrease;
        //call this when you do a speical attack
    }
}
