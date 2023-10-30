namespace Shopping_List_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the market!\n");

            Dictionary<string, decimal> menu = new Dictionary<string, decimal>()
            {
                {"Cookies", 4.99m},
                {"Juice", 4.50m},
                {"Cereal", 3.75m},
                {"Grapes", 3.25m},
                {"Apples", 4.50m},
                {"Oranges", 7.99m},
                {"Milk", 5.50m},
                {"Cheese", 6.79m}
            };

            List<string> groceries = new List<string>();

            ShowMenu(menu);

            string keepOrdering;
            do
            {
                string userReply = GetItemOrder(menu);
                groceries.Add(userReply);
                Console.WriteLine("Would you like to keep ordering? (y/n)");
                keepOrdering = Console.ReadLine();

            }
            while (keepOrdering == "y");

            decimal itemTotal = 0;
            Console.WriteLine("Thanks for your order!\nHere's what you got: ");
            foreach(string item in groceries)
            {
                itemTotal += menu[item];
                Console.WriteLine($"{item}\t\t${menu[item]}");
            }

            Console.WriteLine($"Your order total is: {itemTotal}");   

        }

        static string GetItemOrder(Dictionary<string, decimal> menu)
        {
            string userReply;
            bool isInMenu;

            do
            {
                Console.WriteLine("\nWhat item would you like to order?");
                userReply = Console.ReadLine();

                isInMenu = menu.ContainsKey(userReply);
                if (isInMenu)
                {
                    Console.WriteLine($"Adding {userReply} to cart at ${menu[userReply]}");                    
                }
                else
                {
                    Console.WriteLine("That item is not available, please choose another item from the menu");
                }
            }
            while (!isInMenu);

            return userReply;                  
        }
        
        static void ShowMenu(Dictionary<string, decimal> menu)
        {
            Console.WriteLine("Item\t\t Price");
            Console.WriteLine("========================");
            foreach (var item in menu)
            {
                Console.WriteLine($"{item.Key}\t\t ${item.Value}");
            }
        }
    }
}