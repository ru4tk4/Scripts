using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Input_Handler : gamedata
{
	public Animator anim;
	public Player.State currentState;
    public int Attack_Num = 0;
	public float Attack_Time = 0;
	public List<Command> commandBuffer;
	public SwordCollideDetector swordCollider;

	//Command Input
	private Command attack1Button;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		swordCollider = transform.GetComponentInChildren<SwordCollideDetector>();
		attack1Button = gameObject.AddComponent<Command_Input.Attack_1>();
		attack1Button.enter(this);
		currentState = Player.State.Idle;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState != Player.State.Dead) {
			handleInput();
		}
	}
    float at;
	private void handleInput() {
        if (Input.GetButtonDown(PlayerPrefs.GetString("Attack1", "Fire1")) && currentState != Player.State.Aim && fortEnter.fortopen == false)
        {
            anim.SetTrigger("AttackTG");
            //GunFire.lockWait = true;
            currentState = Player.State.Attack;
            attack1Button.execute();
            at = Time.time;
        }
		if (Time.time > at+Attack_Time && currentState != Player.State.Disable && currentState != Player.State.Dead) {
			Attack_Num=0;
            anim.ResetTrigger("AttackTG");
			currentState = Player.State.Idle;
			swordCollider.goAttack = false;
			anim.SetInteger("Attack1_Num", 0);
           // anim.SetBool("Run", false);
        }
	}

	public void executeCommandBuffer() {
		if (commandBuffer.Count > 0) {
			commandBuffer[commandBuffer.Count-1].execute();
			commandBuffer.Clear();
		}
	}


	public void Zero (){
		print("77");
		anim.SetInteger("Attack1_Num", 0);
		Attack_Num = 0;
		
	}



}
