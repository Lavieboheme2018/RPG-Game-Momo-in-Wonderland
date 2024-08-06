using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    public const string ANIM_PARM_ISATTACK = "IsAttack";

    private Animator anim;
    private PlayerProperty PlayerProperty;
    private int player_atkValue;
    public int atkValue = 50;
    public float atk = 0;
    public AudioSource AudioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        PlayerProperty = GameObject.FindWithTag("Player").GetComponent<PlayerProperty>();
        player_atkValue = PlayerProperty.atkValue;
        atk = PlayerProperty.mentalValue * 0.1f;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Attack();
    //    }
    //}

    public override void Attack()
    {
        
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("WeaponScythe_Attack"))
        {
            anim.SetTrigger(ANIM_PARM_ISATTACK);
            AudioSource.Play();
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tag.ENEMY)
        {
            other.GetComponent<Enemy>().TakeDamage(( int)(atkValue+ player_atkValue+atk));
            Debug.Log("One Attack");
        }
    }
}
