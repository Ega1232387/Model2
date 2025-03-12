using DefaultNamespace;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _health;
    private Ability[] _abilities;
    private int _selectedAbility;

    private void Awake()
    {
        _abilities = new Ability[6];
    }

    public void TakeDamage (int damage)
    {
        if(damage < 0) return;
        this._health -= damage;
        this._health = Mathf.Clamp(this._health, 0, this._health);
        if(this._health == 0) Death();
    }
    
    private void Death()
    {
        Debug.Log("Вы умерли(");
    }
    
    public bool AddAbility(Ability ab, int slot)
    {
        if (slot < 0 | slot >= _abilities.Length)
        {
            Debug.LogError("Неверный слот способности: " + slot.ToString());
            return false;
        }
        
        _abilities[slot] = ab;
        return true;
    }
}
