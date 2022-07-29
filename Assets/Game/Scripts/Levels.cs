using UnityEngine;

namespace SortItems
{
    public class Levels : MonoBehaviour
    {
        private int level = 0;

        [SerializeField] private GameObject[] getters;

        [SerializeField] private ItemSpwner collectCoins;

        [SerializeField] private ItemSpwner tossCoins;


        private void Start() 
        {
            var x = PlayerPrefs.GetInt("Level",0);

            if (level != x)

                LoadLevel(level);
        }

        public void LoadNextLevel()
        { 
            RemoveItems(tossCoins);
            RemoveItems(collectCoins);
            foreach(var im in getters)
               Destroy(im);
               level++;
            LoadLevel(level);
            
        }
        
        public void RemoveItems(ItemSpwner collectCoins)
        {
            foreach(var child in collectCoins.GetComponentsInChildren<Transform>())
            {  
                Destroy(child.gameObject);
            }
        }
        public void LoadLevel(int level)
        {
            var coinbasePlus = Instantiate(Resources.Load<GameObject>("Prefabs / CoinBasePlus"));
            var rez = coinbasePlus.transform.gameObject.GetComponent<ScoreHandler>();
            rez._getters[0].targetCount=1;
        }
         
    }
}
