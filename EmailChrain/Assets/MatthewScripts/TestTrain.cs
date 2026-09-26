using UnityEngine;
using UnityEngine.InputSystem;

public class TestTrain : MonoBehaviour
{

    private float maxHp;
    private float health;
    private TrainHealthScript ths;
    InputAction jumpAction;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHp = 50;
        health = maxHp;
        ths = GetComponent<TrainHealthScript>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPerformedThisFrame()){
            this.Damaged(10);
        }
    }

    void Damaged(float dmg) {
        health -= dmg;
        ths.UpdateHealth(health, maxHp);
        if (this.health <= 0) {
            this.Dead();
        }
    }

    void Dead() {
        print(this.gameObject + " has been destroyed.");
    }

}
