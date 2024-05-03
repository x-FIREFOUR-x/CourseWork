using System;

using UnityEngine;
using UnityEngine.UI;

using TowerDefense.Main.Towers;


namespace TowerDefense.Main.UI.TowerMenu
{
    public class TowerShopComponent : MonoBehaviour
    {
        public bool IsSelected { get; private set; }

        [SerializeField]
        private Tower tower;

        [Header("Components")]
        [SerializeField]
        private Image background;
        [field: SerializeField]
        public Button buttonBuy { get; private set; }
        [SerializeField]
        private TMPro.TextMeshProUGUI textName;
        [SerializeField]
        private TMPro.TextMeshProUGUI textPrice;

        [Header("Buttons Components")]
        [SerializeField]
        private GameObject characterTower;
        [SerializeField]
        private GameObject textCharacter;

        [Header("Colors")]
        [SerializeField]
        private Color colorSelected;
        [SerializeField]
        private Color colorUnselected;
        [SerializeField]
        private Color colorText;
        [SerializeField]
        private Color colorCharacterText;

        public void Initialize(int price)
        {
            IsSelected = false;

            textName.color = colorText;
            textPrice.color = colorText;

            textPrice.text = price.ToString() + "$";

            InitializetextCharacters();
        }

        private void InitializetextCharacters()
        {
            textCharacter.GetComponent<TMPro.TextMeshProUGUI>().color = colorCharacterText;
            textCharacter.GetComponent<TMPro.TextMeshProUGUI>().text =
                "\n   Characters: \n" +
                " Count Bullet: " + tower.CountProjectileEntitys.ToString() + "\n" +
                " Range: " + tower.ShootRange.ToString() + "\n" +
                " Cooldown: " + tower.TimeBetweenShoots.ToString() + "\n" +
                " DPS: " + Math.Round(tower.DamageInSecond(), 1).ToString();
        }

        public void ChangeImageToCharacter()
        {
            if (characterTower.activeSelf)
            {
                characterTower.SetActive(false);
                textCharacter.SetActive(false);
            }
            else
            {
                characterTower.SetActive(true);
                textCharacter.SetActive(true);
            }

        }

        public void SetComponentSelected(bool isSelected)
        {
            IsSelected = isSelected;
            if (IsSelected)
            {
                background.color = colorSelected;
            }
            else
            {
                background.color = colorUnselected;
            }
        }
    }

}
