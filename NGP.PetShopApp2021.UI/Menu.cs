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
        private readonly IPetTypeService _typeService;
        public Menu(IPetService service, IPetTypeService typeService)
        {
            _typeService = typeService;
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

        public void ShowMainMenu()
        {
            Console.Clear();
            SC.WelcomeMes();
            for (int i = 0; i < menuItems.Length; i++)
            {
                _.CWL($"Press ({i +1}) {menuItems[i]}");
            }
            _menuInput = IntTryParse();
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
                        AddPet();
                        break;
                    case 3:
                        DeletePet();
                        break;
                    case 4:
                        EditPet();
                        break;
                    case 5:
                        SearchByType();
                        break;
                    default:
                       _.CWL(StringConstants.IntErrorMessage);
                       _.CRL();
                       break;
                }
                ShowMainMenu();
            }
        }

        public void EditPet()
        {
            _.CWL(StringConstants.EditPetMessage);
            var petId = IntTryParse();
            Pet pet = _service.GetBetById(petId);
            while (pet != null)
            {
                _.CWL(StringConstants.IntErrorMessage);
                petId = IntTryParse();
                pet = _service.GetBetById(petId);
            }
            //Edit pet name
            _.CWL($"{StringConstants.PetNameMessage}");
            string strNameInput = _.CRL();
            //Edit Pet Type
            _.CWL($"\n{StringConstants.ChooseTypeMessage}");
            PrintPetTypeList();
            PetType petType = _typeService.PetTypeById(IntTryParse());
            //Edit Pet Color
            _.CWL($"\n{StringConstants.PetColorMessage}");
            string strColorInput = _.CRL();
            //Enter the owner of the pet
            _.CWL($"\n{StringConstants.AddOwnerMessage}");
            string strOwnerInput = _.CRL();
            //Edit Birthdate
            _.CWL($"\n{StringConstants.BirthdateMessage}");
            DateTime birthDate = DateTimeTryParse();
            //Edit SoldDate
            _.CWL($"\n{StringConstants.SoldTimeMessage}");
            DateTime soldDate = DateTimeTryParse();
            //Edit The price of the pet
            _.CWL($"\n{StringConstants.PriceMessage}");
            double price = DoubleTryParse();

            pet.Name = strNameInput;
            pet.Type = petType;
            pet.Color = strColorInput;
            pet.BirthDate = birthDate;
            pet.SoldDate = soldDate;
            pet.Price = price;
            pet.Owner = strOwnerInput;

            _.CRL();
            _.CWL($"You have edited the pet succesfully");
            _.CWL($"The pets information is now as following Name: {strNameInput} PetType: {petType.Name} Color: {strColorInput} Birthdate: {birthDate} SoldDate: {soldDate} Price: {price}");


        }

        public void AddPet()
        {
            bool addMore = true;
            while (addMore)
            {
                //Message of add pet and save input
                _.CWL($"{StringConstants.AddPetMessage}");
                _.CWL($"{StringConstants.PetNameMessage}");
                string strNameInput = _.CRL();
                //Message when choosing a type, printling list and saving input
                _.CWL($"\n{StringConstants.ChooseTypeMessage}");
                PrintPetTypeList();
                PetType petType = _typeService.PetTypeById(IntTryParse());
                //Message of add pet color and save input
                _.CWL($"\n{StringConstants.PetColorMessage}");
                string strColorInput = _.CRL();
                //Message of addOwner and save input
                _.CWL($"\n{StringConstants.AddOwnerMessage}");
                string strOwnerInput = _.CRL();
                //Message to birthday, tryparse and save input
                _.CWL($"\n{StringConstants.BirthdateMessage}");
                DateTime birthDate = DateTimeTryParse();
                //Message to soldDate, tryparse and save input
                _.CWL($"\n{StringConstants.SoldTimeMessage}");
                DateTime soldDate = DateTimeTryParse();
                //Message to price, tryparse and save input
                _.CWL($"\n{StringConstants.PriceMessage}");
                double price = DoubleTryParse();
                //Add all saved inputs to the inMemory list
                var pet = new Pet
                {
                    Name = strNameInput,
                    Type = petType,
                    Color = strColorInput,
                    Owner = strOwnerInput,
                    BirthDate = birthDate,
                    SoldDate = soldDate,
                    Price = price
                };
                _service.CreatePet(pet);
                _.CWL($"\n{StringConstants.AddPetSucceedMessage}");
                _.CWL($"The pets information is as following Name: {strNameInput} PetType: {petType.Name} Color: {strColorInput} Owner:{strOwnerInput} Birthdate: {birthDate} SoldDate: {soldDate} Price: {price}");
                _.CRL();
                _.CWL($"{StringConstants.AddMoreMessage} \n{StringConstants.BackToMainMessage}");
                int intAddMore = IntTryParse();
                if (intAddMore != 1)
                {
                    addMore = false;
                }
            }
        }

        public void DeletePet()
        {
            _.CWL($"{StringConstants.DeletePetMessage}");
            int intInput = IntTryParse();
            _service.DeletePet(intInput);

        }

        public void SearchByType()
        {
            string typeInput;
            _.CWL(StringConstants.SearchTypeMessage);
            typeInput = _.CRL();
            typeInput = $"{typeInput[0].ToString().ToUpper() + typeInput.Substring(1).ToLower()}";
            switch (typeInput)
            {
                case "Cat":
                case "Dog":
                case "Guineapig":
                    var petList = _service.SearchByType(typeInput);
                    foreach (var pet in petList)
                    {
                        _.CWL($"Id: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name} Color: {pet.Color} BirthDate: {pet.BirthDate} SoldDate: {pet.SoldDate} Price: {pet.Price}");
                    }
                    _.CRL();
                    break;
                default:
                    _.CWL(StringConstants.IntErrorMessage);
                    SearchByType();
                    break;
            }
        }
        public void PetList()
        {
            List<Pet> petList = _service.GetAllPets(null);
            foreach (var pet in petList)
            {
                _.CWL($"Id: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name} Color: {pet.Color} Owner: {pet.Owner} BirthDate: {pet.BirthDate} SoldDate: {pet.SoldDate} Price: {pet.Price}");
            }
            _.CRL();
        }
        public DateTime DateTimeTryParse()
        {
            DateTime dateTimeInput;
            string strInput = _.CRL();
            while (!DateTime.TryParse(strInput, out dateTimeInput))
            {
                _.CWL($"{StringConstants.DateTimeErrorMessage}");
                strInput = _.CRL();
            }

            return dateTimeInput;
        }

        public double DoubleTryParse()
        {
            double doubleInput;
            string strInput = _.CRL();
            while (!double.TryParse(strInput, out doubleInput))
            {
                _.CWL($"{StringConstants.IntErrorMessage}");
                strInput = _.CRL();
            }

            return doubleInput;
        }
        public int IntTryParse()
        {
            string strInput = _.CRL();
            int intInput;
            while (!int.TryParse(strInput, out intInput))
            {
                _.CWL(StringConstants.IntErrorMessage);
                strInput = _.CRL();
            }

            return intInput;
        }

        public void PrintPetTypeList()
        {
            List<PetType> petTypeList = _typeService.GetAllTypes();

            foreach (var petType in petTypeList)
            {
                _.CWL($"Name: {petType.Name} Id: {petType.Id}");
            }
        }
    }
}