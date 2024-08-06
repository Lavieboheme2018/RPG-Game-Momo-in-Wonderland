using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    //正常   - 战斗状态
    //1-移动
    //2-休息
    public enum EnemyState
    {
        NormalState,
        FightingState,
        MovingState,
        RestingState
    }

    private EnemyState state = EnemyState.NormalState;
    private EnemyState childState = EnemyState.RestingState;
    private NavMeshAgent enemyAgent;
    public float range = 1.5f;
    public int id = 1;
    public float restTime = 2;
    private float restTimer = 0;
    public int atkValue=10;
    private float maxHP = 100;
    public int HP = 100;
    public int exp = 20;
    public GameObject effectPre;
    public GameObject hpUI;
    float atkCD;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = HP;
        enemyAgent = GetComponent<NavMeshAgent>();
        if(id==2)
        {
            player = GameObject.FindWithTag("Player");
        }
        

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        atkCD += Time.fixedDeltaTime;
        if (id==2)
        {
            float distance = Vector3.Distance(transform.position, player.gameObject.transform.position);
        
        
        
        //Debug.Log(distance + " " + atkCD + " ");
        if (id == 2 && distance <= range && atkCD >= 1f)
        {
            transform.gameObject.GetComponent<Animator>().SetBool("ATK", true);
            if(distance<= range)
            {
                player.GetComponent<PlayerProperty>().TakeDamage(atkValue);
            }
            enemyAgent.SetDestination(player.transform.position);
            atkCD = 0;
        }
        else if (distance > range || atkCD < 1f)
        {
            transform.gameObject.GetComponent<Animator>().SetBool("ATK", false);
        }
        }
        if(hpUI != null)
        {
            hpUI.transform.localScale = new Vector3(HP / maxHP, 1, 1);
        }
        
        //Debug.Log(HP / maxHP);
    }
    void Update()
    {
        if (state == EnemyState.NormalState)
        {
            if (childState == EnemyState.RestingState)
            {
                restTimer += Time.deltaTime;

                if (restTimer > restTime)
                {
                    Vector3 randomPosition = FindRandomPosition();
                    enemyAgent.SetDestination(randomPosition);
                    if(id==2)
                    {
                        transform.gameObject.GetComponent<Animator>().SetBool("isWalk", true);
                    }
                    

                    childState = EnemyState.MovingState;
                }
            }else if (childState == EnemyState.MovingState)
            {
                if (enemyAgent.remainingDistance <= 1f)
                {
                    restTimer = 0;
                    if(id==2)
                    {
                        transform.gameObject.GetComponent<Animator>().SetBool("isWalk", false);

                    }
                   
                    childState = EnemyState.RestingState;
                }
            }

        }
        

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(30);
        //}

    }


    Vector3 FindRandomPosition()
    {
        Vector3 randomDir;
        if (id==1)
        {
             randomDir = new Vector3(Random.Range(-1, 1f), 0, Random.Range(-1, 1f));
            return transform.position + randomDir.normalized * Random.Range(2, 5);
        }
        else 
        {
            Vector3 pos = GameObject.FindWithTag("Player").transform.position;
             
            return pos;
        }
        
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            HP = 0;
            Die();
        }
    }

    private void Die()
    {
        GetComponent<Collider>().enabled = false;
        int count = Random.Range(1, 10);
        if (count>=5)
        {
            SpawnPickableItem();
        }
        EventCenter.EnemyDied(this);
        transform.gameObject.GetComponent<Animator>().SetTrigger("isDie");
        Instantiate(effectPre,transform.position, Quaternion.identity);
        Destroy(transform.gameObject, 1f);
        //StartCoroutine("ToDie");
    }

    private void SpawnPickableItem()
    {
        ItemSO item = ItemDBManager.Instance.GetRandomItem();
        //print(transform.position);
        GameObject go = GameObject.Instantiate(item.prefab, transform.position, Quaternion.identity);
        go.tag = Tag.INTERACTABLE;
        Animator anim = go.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = false;
        }
        PickableObject po = go.AddComponent<PickableObject>();
        po.itemSO = item;

        Collider collider = go.GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = true;
            collider.isTrigger = false;
        }
        Rigidbody rgd = go.GetComponent<Rigidbody>();
        if (rgd != null)
        {
            rgd.isKinematic = false;
            rgd.useGravity = true;
        }
    }
    //IEnumerator ToDie()
    //{
    //    yield return new WaitForSeconds(0.65f);
    //    Destroy(this.gameObject);
    //}
}
