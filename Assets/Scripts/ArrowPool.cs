    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Pool;


    public class ArrowPool : MonoBehaviour
    {
        [SerializeField] private Arrow _arrowPrefab;
        [SerializeField] private Transform arrowSpawnPoint;
        [SerializeField] private float arrowSpeed = 40;
        private bool asiaIsAttacking = false;
        private Animator _animator;
        public static event Action ShootHappend;
        private ObjectPool<Arrow> arrowPool;
        private static readonly int Attack = Animator.StringToHash("Attack");


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            arrowPool = new ObjectPool<Arrow>(
                CreatePooledObject,
                OnTakeFromPool,
                OnReturnToPool,
                OnDestroyObject,
                false,
                10,
                20);
        }

        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && !asiaIsAttacking)
            {
                asiaIsAttacking = true;
                _animator.SetBool(Attack,true);
                StartCoroutine("ShoorArrow");
            }
        }

        private IEnumerator ShoorArrow()
        {
            yield return new WaitForSeconds(1.6f);
            arrowPool.Get();
            _animator.SetBool(Attack,false);
            asiaIsAttacking = false;
        }


        void SpawnBullet(Arrow obj)
        {
            var arrow = arrowPool.Get();
            arrow.Shoot(arrowSpawnPoint.transform.position,gameObject.transform.forward , arrowSpeed);
        }
        

        private void OnDestroyObject(Arrow obj)
        {
            Destroy(obj.gameObject);
        }

        private void OnReturnToPool(Arrow obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnTakeFromPool(Arrow obj)
        {
            obj.gameObject.SetActive(true);
            obj.Shoot(arrowSpawnPoint.transform.position,gameObject.transform.forward , 20);
        }

        Arrow CreatePooledObject()
        {
            Arrow arrow = Instantiate(_arrowPrefab, Vector3.zero, Quaternion.identity);
            arrow.Disable += KillArrow;
            arrow.gameObject.SetActive(false);

            return arrow;
        }

        void KillArrow(Arrow obj)
        {
            arrowPool.Release(obj);
        }
    }
