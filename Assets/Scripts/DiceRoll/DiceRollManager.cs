using SODL.Core;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace SODL.DiceRoll
{
    public class DiceRollManager : MonoBehaviour
    {
        [SerializeField] private GameObject mainSceneRoot;
        private DiceRollController controller;

        public event Action<int> onDiceRollEnded;
        public void StartDiceRolling()
        {
            LoadScene();
        }

        public void InitScene(DiceRollController controller)
        {
            this.controller = controller;
            controller.diceResultObtained += ProcessResult;
        }

        void ProcessResult(int value)
        {
            Debug.Log("ProcessResult");
            onDiceRollEnded?.Invoke(value);
            controller.diceResultObtained -= ProcessResult;
            UnloadScene();
        }

        #region SceneLoading
        void LoadScene()
        {
            SceneManager.LoadScene("DiceScene", LoadSceneMode.Additive);
            StartCoroutine(LoadSceneCoroutine());
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("DiceScene"));
        }

        void UnloadScene()
        {
            GameObject diceRoot = GameObject.FindGameObjectWithTag("DiceSceneRoot");
            //GameObject mainRoot = GameObject.FindGameObjectWithTag("SceneRoot");
            diceRoot.SetActive(false);
            mainSceneRoot.SetActive(true);
            SceneManager.UnloadSceneAsync("DiceScene");
            
            
        }
        #endregion

        IEnumerator LoadSceneCoroutine()
        {
            yield return null;
            GameObject diceRoot = GameObject.FindGameObjectWithTag("DiceSceneRoot");
            GameObject mainRoot = GameObject.FindGameObjectWithTag("SceneRoot");
            diceRoot.SetActive(true);
            mainRoot.SetActive(false);
        }
    }

}