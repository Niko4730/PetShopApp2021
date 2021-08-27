using System;

namespace NGP.PetShopApp2021.UI
{
    public class StringConstants
    {
        public const string WelcomeMessage = "*****Welcome to the pet shop menu*****";
        public const string IntErrorMessage = "The input was not valid, please try again";
        public const string AddPetMessage = "Type in the information for the pet";
        public const string PetNameMessage = "Please enter the name of the pet";
        public const string ChooseTypeMessage = "Please enter the Id of the specified pet type";
        public const string PetColorMessage = "Please type in the color of the pet";
        public const string BirthdateMessage = "Please enter the birthdate of your pet using this format DD-MM-YYYY";
        public const string DateTimeErrorMessage = "Please enter a valid date, using the given format DD-MM-YYYY";
        public const string SoldTimeMessage = "Please enter the date your pet was sold, using this format DD-MM-YYYY";
        public const string PriceMessage = "Please enter the price of your pet, in dollars, using numbers only,";
        public const string AddPetSucceedMessage = "You have succesfully added a new pet!";
        public const string BackToMainMessage = "Press 0 to return to Main Menu";
        public const string AddMoreMessage = "Press 1 to add another pet";
        public const string DeletePetMessage = "Please type the id of the pet you wish to remove";
        
        


        public void WelcomeMes()
        {

            Console.WriteLine($"{WelcomeMessage}");
            Console.WriteLine("                             .-.");
            Console.WriteLine("(___________________________()6 -,");
            Console.WriteLine("(   ______________________   /''\"");
            Console.WriteLine("//\\\\                      //\\\\");
            Console.WriteLine("\"\" \"\"                     \"\" \"\"");
            Console.WriteLine();
        }
    }
}