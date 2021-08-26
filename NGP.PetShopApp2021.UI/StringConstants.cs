using System;

namespace NGP.PetShopApp2021.UI
{
    public class StringConstants
    {
        public const string WelcomeMessage = "*****Welcome to the pet shop menu*****";
        public const string IntErrorMessage = "The input was not valid, please try again";
        public const string AddPetMessage = "Type in the information for the pet";
        public const string PetNameMessage = "Please enter the name of the pet";
        public const string ChooseTypeMessage = "Please choose the correct type of your pet";


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