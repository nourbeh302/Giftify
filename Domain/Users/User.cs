namespace Domain.Users;

public class User
{
    public User()
    {
    }

    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string passwordHash,
        string phoneNumber,
        Gender gender,
        DateTime createdAtUtc,
        DateTime modifiedOnUtc,
        bool isVerified,
        bool isLocked,
        string address,
        string profileImageUrl)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        PhoneNumber = phoneNumber;
        Gender = gender;
        CreatedAtUtc = createdAtUtc;
        ModifiedOnUtc = modifiedOnUtc;
        IsVerified = isVerified;
        IsLocked = isLocked;
        Address = address;
        ProfileImageUrl = profileImageUrl;
    }

    public Guid Id { get; private set; }
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public Gender Gender { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }
    public DateTime ModifiedOnUtc { get; private set; }
    public bool IsVerified { get; private set; } = new();
    public bool IsLocked { get; private set; } = new();
    public string ProfileImageUrl { get; private set; } = string.Empty;
}

public enum Gender
{
    Female,
    Male
}
