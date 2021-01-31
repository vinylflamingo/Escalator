namespace Escalator.Common.Models
{
    public class Agent
    {
        public long Id { get; set;}
        public string Username { get; set;}
        public string Password { get; set;}
        public string Role {get; set;} 
        public string Email {get; set;}
        public bool NeedsNewPassword {get; set;} //the flag to go to reset password on login

        public bool OptInNotifications {get; set;}
        public bool OptInReports {get; set;}
    }
}