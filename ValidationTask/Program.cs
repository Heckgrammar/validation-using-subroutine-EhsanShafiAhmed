namespace ValidationTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstName, lastName, username, password, emailAddress;
            int age;

          
            Console.Write("Enter first name: ");
            firstName = Console.ReadLine();
            while (!ValidName(firstName))
            {
                Console.Write("Enter a valid first name: ");
                firstName = Console.ReadLine();
            }

        
            Console.Write("Enter last name: ");
            lastName = Console.ReadLine();
            while (!ValidName(lastName))
            {
                Console.Write("Enter a valid last name: ");
                lastName = Console.ReadLine();
            }

      
            Console.Write("Enter age: ");
            age = Convert.ToInt32(Console.ReadLine());
            while (!ValidAge(age))
            {
                Console.Write("Enter a valid age (between 11 and 18): ");
                age = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Enter password: ");
            password = Console.ReadLine();
            while (!ValidPassword(password))
            {
                Console.Write("Enter a valid password: ");
                password = Console.ReadLine();
            }


            Console.Write("Enter email address: ");
            emailAddress = Console.ReadLine();
            while (!ValidEmail(emailAddress))
            {
                Console.Write("Enter a valid email address: ");
                emailAddress = Console.ReadLine();
            }


            username = CreateUserName(firstName, lastName, age);
            Console.WriteLine($"Username is {username}, you have successfully registered. Please remember your password.");
        }

        static bool ValidName(string name)
        {
         
            if (name.Length < 2)
                return false;

            foreach (char c in name)
            {
                int asciiValue = Convert.ToInt32(c);
                if (!(asciiValue >= 65 && asciiValue <= 90) && !(asciiValue >= 97 && asciiValue <= 122))
                    return false;
            }

            return true;
        }

        static bool ValidAge(int age)
        {

            return age >= 11 && age <= 18;
        }

        static bool ValidPassword(string password)
        {

            if (password.Length < 8)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasSpecialChar = false;

            for (int i = 0; i < password.Length; i++)
            {
                int asciiValue = Convert.ToInt32(password[i]);

                if (asciiValue >= 65 && asciiValue <= 90)
                    hasUpperCase = true; 

                if (asciiValue >= 97 && asciiValue <= 122)
                    hasLowerCase = true; 

                if ((asciiValue >= 33 && asciiValue <= 47) || 
                    (asciiValue >= 58 && asciiValue <= 64) ||  
                    (asciiValue >= 91 && asciiValue <= 96) ||  
                    (asciiValue >= 123 && asciiValue <= 126))  
                    hasSpecialChar = true; 

    
                if (i >= 2)
                {
                    int prevAscii1 = Convert.ToInt32(password[i - 1]);
                    int prevAscii2 = Convert.ToInt32(password[i - 2]);

           
                    if ((asciiValue == prevAscii1 + 1 && prevAscii1 == prevAscii2 + 1) ||
                        (asciiValue == prevAscii1 && prevAscii1 == prevAscii2))
                    {
                        return false;
                    }
                }
            }

        
            return hasUpperCase && hasLowerCase && hasSpecialChar;
        }

        static bool ValidEmail(string email)
        {


            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');

            if (atIndex == -1 || dotIndex == -1 || atIndex >= dotIndex)
                return false;

          
            if (atIndex < 2 || (dotIndex - atIndex) < 3 || (email.Length - dotIndex) < 3)
                return false;

        
            foreach (char c in email)
            {
                int asciiValue = Convert.ToInt32(c);

                if (!((asciiValue >= 65 && asciiValue <= 90) ||   
                      (asciiValue >= 97 && asciiValue <= 122) ||  
                      (asciiValue >= 48 && asciiValue <= 57) ||
                      c == '@' || c == '.'))                        
                {
                    return false;
                }
            }

            return true;
        }

        static string CreateUserName(string firstName, string lastName, int age)
        {
            string username = firstName.Substring(0, 2) + lastName.Substring(lastName.Length - 2) + age;
            return username;
        }

    }
}
