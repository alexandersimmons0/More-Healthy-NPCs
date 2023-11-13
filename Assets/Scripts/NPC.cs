using UnityEngine;

public class NPC : MonoBehaviour
{
    public int damage;

    void OnMouseDown(){
            TakeDamage(damage);
            Debug.Log("NPC hit");
    }
    internal void TakeDamage(int amount)
    {
        GetComponent<IHealth>().TakeDamage(amount);
    }
}