using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int health;
    private Ability[] abilities; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void TakeDamage (int damage)
    {
        if(damage < 0) return;
        this.health -= damage;
        health = Mathf.Clamp(0, this.health);
        if(this.health == 0) Death();
    }

    // Update is called once per frame
    private void Death()
    {
        Debug.Log("Вы умерли(")
    }
}
