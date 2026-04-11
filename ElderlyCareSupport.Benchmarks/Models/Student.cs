namespace ElderlyCareSupport.Benchmarks.Models;

public record Student(
    Guid Id,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Gender,
    string Email,
    string PhoneNumber,
    string Address,
    string City,
    string State,
    string Country,
    string PostalCode,
    string EnrollmentNumber,
    DateTime EnrollmentDate,
    string Course,
    int YearOfStudy,
    double GPA,
    bool IsActive,
    string GuardianName,
    string GuardianPhone
);