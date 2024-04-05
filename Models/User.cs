namespace product.Models
{
    public class User
    {
          
        public string Username { get; set; }
         public string Password { get; set; }
 
         public User(string userName,string passWord)
         {
            Username=userName;
            Password=passWord;
 
         }
    }
}