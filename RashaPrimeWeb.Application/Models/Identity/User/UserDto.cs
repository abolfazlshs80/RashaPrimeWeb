﻿namespace RashaPrimeWeb.Application.Models.Identity.User
{
    public class UserDto
    {
        public string Id { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }=false;
    }
}
