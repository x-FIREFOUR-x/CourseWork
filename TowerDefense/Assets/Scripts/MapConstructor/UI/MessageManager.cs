using UnityEngine;


namespace TowerDefense.MapConstructor.UI
{
    public class MessageManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject uncorrectMapMessage;

        public void CloseUncorrectMapMessage()
        {
            uncorrectMapMessage.SetActive(false);
        }
        public void OpenUncorrectMapMessage()
        {
            uncorrectMapMessage.SetActive(true);
        }
    }
}