using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace Assets
{
    public class Enemy : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Transform player;

        public LayerMask enviromentLayer, playerLayer;

        //public float health;

        //Patroling
        private Vector3 walkPoint;
        bool walkPointSet;
        public float walkPointRange;
        //States
        public float sightRange;


        private bool playerInSightRange ;
        private bool IsWalking , isCatched;
        

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);

            if (!playerInSightRange) Patroling();
            if (playerInSightRange) ChasePlayer();
        }

        private void Patroling()
        {
            isCatched = false;

            if (!walkPointSet) SearchWalkPoint();
            if (walkPointSet) agent.SetDestination(walkPoint);

            Vector3 distanceToWalkPoint = transform.position - walkPoint;

            //Walkpoint reached
            if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false;

            


        }
        private void SearchWalkPoint()
        {
            Debug.Log("SearchWalkPoint");
            //Calculate random point in range
            float randomZ = UnityEngine.Random.Range(-walkPointRange, walkPointRange);
            float randomX = UnityEngine.Random.Range(-walkPointRange, walkPointRange);

            walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);


            if (Physics.Raycast(walkPoint, -transform.up, 2f, enviromentLayer))
                walkPointSet = true;
        }

        private IEnumerator FoundPerson()
        {
            var catched = Physics.CheckSphere(transform.position, 0.5f, playerLayer);


            if (catched && !isCatched)
            {
                agent.SetDestination(transform.position);

                Debug.Log(isCatched);
                isCatched = true;
                yield return new WaitForSeconds(5);
                isCatched = false;

            }
            else
            {
                agent.SetDestination(player.position);
            }


        }

        private IEnumerable Walking()
        {
            yield return new WaitForSeconds(5);
        }

        private void ChasePlayer()
        {

            transform.LookAt(player.position);
            agent.SetDestination(player.position);

            StartCoroutine(FoundPerson());
            
        }

       
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            
            Gizmos.DrawWireSphere(transform.position, sightRange);
        }
    }
}
