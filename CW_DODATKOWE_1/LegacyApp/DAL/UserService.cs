using System;

namespace LegacyApp
{
    public class UserService : IUserService
    {
        //AddUser_ShouldAddUserCorrectly
        //AddUser_ShouldFail_IncorrectEmail
 

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!Validate(firstName,lastName,email,dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = GetNewUser(firstName, lastName, email, dateOfBirth, client);

            SetCreditCardLimit(client, user);

            if (!HasEnoughLimit(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
        // walidacja danych
        public bool Validate(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (ValidateNameAndSurname(firstName,lastName) && ValidateEmail(email) && ValidateAge(dateOfBirth))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // walidacja tego czy email jest prawidłowy
        public bool ValidateEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // walidacja tego czy imię bądź nazwisko są puste
        public bool ValidateNameAndSurname(string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // walidacji poprawności wieku ( czy wynosi ponad 21 )
        public bool ValidateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        //Utworzenie nowego usera
        public User GetNewUser(string firstName, string lastName, string email, DateTime dateOfBirth, Client client)
        {
            return new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
        }
        // ustawienie właściwości karty
        public void SetCreditCardLimit(Client client, User user)
        {
            if (client.Name == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Name == "ImportantClient")
            {
                SetCardProperties(user, 2, new UserCreditService());
            }
            else
            {
                SetCardProperties(user, 1, new UserCreditService());
            }
        }
        // Przypisanie karcie limitu 
        public void SetCardProperties(User user,int value, UserCreditService userCreditService)
        {
            int creditLimit = userCreditService.GetCreditLimit(user.FirstName, user.LastName, user.DateOfBirth);
            creditLimit *= value;
            user.CreditLimit = creditLimit;
            userCreditService.Dispose();
        }
        // Sprawdzenie czy klient posiada zdoność kredytową
        public bool HasEnoughLimit(User user)
        {
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    
}
