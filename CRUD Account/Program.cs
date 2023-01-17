using System;
using System.Collections.Generic;

namespace CRUDAccount{

    public static class Program
    {
            class Account { 
        
            public int ID { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public bool IsActive { get; set; }
        }


        class AccountRepository
        {
            private List<Account> Accounts = new List<Account>();

            public AccountRepository()
            {
                // Initialize some test data
                Accounts.Add(new Account { ID = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", Password = "password", IsActive = true });
                Accounts.Add(new Account { ID = 2, FirstName = "Jane", LastName = "Doe", Email = "janedoe@example.com", Password = "password", IsActive = true });
            }

            public List<Account> GetAll()
            {
                return Accounts;
            }

            public Account GetByID(int id)
            {
                return Accounts.Find(x => x.ID == id);
            }

            public void Insert(Account account)
            {
                Accounts.Add(account);
            }

            public void Update(Account account)
            {
                var existingAccount = Accounts.Find(x => x.ID == account.ID);
                existingAccount.FirstName = account.FirstName;
                existingAccount.LastName = account.LastName;
                existingAccount.Email = account.Email;
                existingAccount.Password = account.Password;
                existingAccount.IsActive = account.IsActive;
            }

            public void Delete(int id)
            {
                Accounts.Remove(Accounts.Find(x => x.ID == id));

            }

            class Program
            {
                static void Main()
                {
                    var repository = new AccountRepository();

                    // Get all accounts
                    var accounts = repository.GetAll();
                    foreach (var account in accounts)
                    {
                        Console.WriteLine("ID: {0}, Name: {1} {2}, Email: {3}, IsActive: {4}",
                            account.ID, account.FirstName, account.LastName, account.Email, account.IsActive);
                    }

                    // Get account by ID
                    var account1 = repository.GetByID(1);
                    Console.WriteLine("\nAccount 1: ID: {0}, Name: {1} {2}, Email: {3}, IsActive: {4}",
                        account1.ID, account1.FirstName, account1.LastName, account1.Email, account1.IsActive);

                    // Insert new account
                    var newAccount = new Account
                    {
                        FirstName = "Bob",
                        LastName = "Smith",
                        Email = "bobsmith@example.com",
                        Password = "password",
                        IsActive = true
                    };
                    repository.Insert(newAccount);
                    Console.WriteLine("\nNew account added: ID: {0}, Name: {1} {2}, Email: {3}, IsActive: {4}",
                        newAccount.ID, newAccount.FirstName, newAccount.LastName, newAccount.Email, newAccount.IsActive);

                    // Update existing account

                    var account2 = repository.GetByID(2);
                    account2.FirstName = "Jane";
                    account2.Email = "janedoe@example.com";
                    account2.IsActive = false;
                    repository.Update(account2);
                    Console.WriteLine("\nAccount 2 updated: ID: {0}, Name: {1} {2}, Email: {3}, IsActive: {4}",
                        account2.ID, account2.FirstName, account2.LastName, account2.Email, account2.IsActive);

                    // Delete existing account
                    repository.Delete(1);
                    Console.WriteLine("\nAccount 1 deleted");
                }
            }

        }
    }
    

}




