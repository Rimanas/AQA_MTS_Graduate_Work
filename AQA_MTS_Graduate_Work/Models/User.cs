using AQA_MTS_Graduate_Work.Models.Enums;

namespace AQA_MTS_Graduate_Work.Models;
public class User
{
    public UserType UserType { get; set; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}