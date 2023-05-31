using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnimeController : MonoBehaviour
{
    [SerializeField]
    float attack;

    [SerializeField]
    float speedEnemy;


    [SerializeField]
    float speedRotEnemy;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    GameObject pointStart;

    NavMeshAgent navigation;

    [SerializeField]
    Transform target;

    [Header("Sensors")]
    float SensorsLenth = 2f;


    RaycastHit hit;
    void Start()
    {
        navigation = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        LookAtPlayer();
        Sensors();
        navigation.destination = target.position;
    }
    void Sensors() 
    {
        Vector3 sensorsStartPos = pointStart.transform.position;

        if (Physics.Raycast(sensorsStartPos, transform.forward, out hit, SensorsLenth))
        {
            if (hit.collider.CompareTag("Player")){ 
                _animator.SetBool("running", false);
                navigation.speed = 0f;
                _animator.SetBool("attack", true);
            }
            Debug.DrawLine(sensorsStartPos, hit.point);
        }
        else {

            _animator.SetBool("running", true);
            navigation.speed = speedEnemy;
            _animator.SetBool("attack", false);
        } 
    }

    void LookAtPlayer() 
    {
        var rotation =Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speedRotEnemy);
    }

    //events enemy
    public void attackEnemy() 
    {
        if(hit.collider.CompareTag("Player"))
            hit.collider.gameObject.GetComponent<TakingDamage>().TakeDamage(attack);
    }

}
