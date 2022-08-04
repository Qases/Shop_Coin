using UnityEngine;
using UnityEngine.SceneManagement;

namespace SortItems
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField] private GameObject Lvl_Prev;
        [SerializeField] private GameObject Lvl_Next;
        [SerializeField] private GameObject[] CoinBases;



        public void LoadNextLevel()
        {
            Destroy(Lvl_Prev);
            foreach(var _base in CoinBases)
                Destroy (_base);
            Lvl_Prev.SetActive(false);
            Instantiate(Lvl_Next);        
        }

        

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Update() 
        {
            if (Input.GetKeyUp(KeyCode.R))
            {
                ReloadScene();
            }
        }

    }
}
