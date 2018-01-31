using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceEscape
{
    [RequireComponent(typeof(GenericObjectPoolerMultiType))]
    public class GameManager : MonoBehaviour
    {
        public GameObject player;
        public string initScene = "Init";
        public string gameScene = "Game";
        public string gameOverScene = "GameOver";

        public float asteroidSpawnDistance = 50f;
        public float asteroidSpawnDelay = 0.5f;

        private static GameManager m_Instance = null;
        private GenericObjectPoolerMultiType m_Pooler;
        private string m_CurrentSceneName;

        private int m_Score = 0;

        private float m_AsteroidTimer = 0f;

        public int score
        {
            get
            {
                return m_Score;
            }
        }

        public static GameManager instance
        {
            get
            {
                return m_Instance;
            }
        }

        public GenericObjectPoolerMultiType pooler
        {
            get
            {
                return m_Pooler;
            }
        }

        private void Awake()
        {
            if (m_Instance == null)
                m_Instance = this;
            else if (m_Instance != this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Start()
        {
            m_Pooler = GetComponent<GenericObjectPoolerMultiType>();
        }

        private void Update()
        {
            if(m_CurrentSceneName == initScene)
            {
               
            }
            else if(m_CurrentSceneName == gameScene)
            {
                /*
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ShootAnAsteroid();
                }
                */
                m_AsteroidTimer += Time.deltaTime;
                if(m_AsteroidTimer >= asteroidSpawnDelay)
                {
                    ShootAnAsteroid();
                    m_AsteroidTimer = 0f;
                }

                if (player.GetComponent<SpaceshipController>().health <= 0)
                {
                    GameOverScene();
                }
            }
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            //Debug.Log("XCVXCXCVXCVXCVXCVXCVXCVXCVXCVXCVXCVXCV");
        }

        private void OnSceneLoaded(Scene curScene, LoadSceneMode mode)
        {
            m_CurrentSceneName = curScene.name;
            if (curScene.name == gameScene)
            {
                m_Score = 0;
                pooler.PoolGameObjects();
                if(!player)
                {
                    player = GameObject.FindGameObjectWithTag("Player");
                }
            }
            else
            {
                //pooler.ClearGameObjects();
                if(pooler)
                {
                    pooler.ClearGameObjects();
                }
            }
        }

        public void InitScene()
        {
            SceneManager.LoadScene(initScene);
        }

        public void GameScene()
        {
            SceneManager.LoadScene(gameScene);
        }

        public void GameOverScene()
        {
            SceneManager.LoadScene(gameOverScene);
        }

        public void AddScore()
        {
            m_Score += 1;
        }

        public void ShootAnAsteroid()
        {
            GameObject obj = pooler.GetPooledGameObject("asteroid");
            if(obj)
            {
                RockMovement rm = obj.GetComponent<RockMovement>();
                if(rm)
                {
                    float scl = Random.Range(rm.minScale, rm.maxScale);
                    obj.transform.localScale = new Vector3(
                            scl,
                            scl,
                            scl
                        );
                    //Debug.Log(scl);
                    Vector3 pos = Camera.main.WorldToViewportPoint(player.transform.position);
                    pos.x = Random.Range(0f, 1f);
                    pos.y = Random.Range(0f, 1f);
                    obj.transform.position = Camera.main.ViewportToWorldPoint(pos);
                    //Debug.Log(obj.transform.position.x);
                    obj.transform.position = new Vector3(
                            obj.transform.position.x,
                            obj.transform.position.y,
                            asteroidSpawnDistance
                        );

                    //obj.transform.position = new Vector3(2, 0, 0);
                    obj.SetActive(true);
                }
            } 
        }
    }
}
