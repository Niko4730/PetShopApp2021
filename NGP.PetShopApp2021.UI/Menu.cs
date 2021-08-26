using System;
using System.Collections.Generic;
using NGP.PetShopApp2021.Core.IServices;
using NGP.PetShopApp2021.Core.Models;

namespace NGP.PetShopApp2021.UI
{
    public class Menu
    {
        private int _menuInput;
        private StringConstants SC = new StringConstants();
        private Utils _ = new Utils();
        private readonly IPetService _service;
        public Menu(IPetService service)
        {
            _service = service;
        }
        public string[] menuItems =
        {
            "List of all Pets",
            "Add new pet",
            "Delete a pet",
            "Edit a Pet",
            "Search for pet",
            "Exit"
        };

        public int ShowMainMenu()
        {
            Console.Clear();
            SC.WelcomeMes();
            for (int i = 0; i < menuItems.Length; i++)
            {
                _.CWL($"Press ({i +1}) {menuItems[i]}");
            }
            string strInput = _.CRL();
            int intInput;
            while (!int.TryParse(strInput, out intInput))
            {
                _.CWL(StringConstants.IntErrorMessage);
                strInput = _.CRL();
            }

            _menuInput = intInput;
            return _menuInput;
        }

        public void MenuSelector()
        {
            while (_menuInput != 6)
            {
                switch (_menuInput)
                {
                    case 1:
                        PetList();
                        break;
                    case 2:
                        AddPet;
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                       _.CWL(StringConstants.IntErrorMessage);
                       _.CRL();
                       break;
                }
                
            }
        }

        public void AddPet()
        {
            bool addMore = true;
            while (addMore)
            {
                _.CWL($"{StringConstants.AddPetMessage}");
                _.CWL($"{StringConstants.PetNameMessage}");
                string strNameInput = _.CRL();
                _.CWL($"{StringConstants.ChooseTypeMessage}");
                
            }
        }
        public void PetList()
        {
            List<Pet> petList = _service.GetAllPets();
            foreach (var pet in petList)
            {
                _.CWL($"Id: {pet.Id} Name: {pet.Name} Type: {pet.Type} Color: {pet.Color} BirthDate: {pet.BirthDate} SoldDate: {pet.SoldDate} Price: {pet.Price}");
            }
            _.CRL();
        }
    }
}