﻿namespace SecretMessages_Library.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
    }
}
