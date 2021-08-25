using NGP.PetShopApp2021.Core.IServices;

namespace NGP.PetShopApp2021.UI
{
    public class Menu
    {
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

        public void ShowMainMenu()
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                _.CWL($"Press ({i +1}) {menuItems[i]}");
            }

            _.CRL();

        }
    }
}