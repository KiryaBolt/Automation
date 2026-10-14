using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SauceDemo.Core.Api.Models;

public class ReqresUser
{
    public int Id { get; init; }
    public string Email { get; init; } = string.Empty;

    [JsonPropertyName("first_name")]
    public string FirstName { get; init; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string LastName { get; init; } = string.Empty;

    public string Avatar { get; init; } = string.Empty;
}

public class ReqresResource
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Year { get; init; }
    public string Color { get; init; } = string.Empty;

    [JsonPropertyName("pantone_value")]
    public string PantoneValue { get; init; } = string.Empty;
}

public class ListResponse<T>
{
    public int Page { get; init; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; init; }

    public int Total { get; init; }

    [JsonPropertyName("total_pages")]
    public int TotalPages { get; init; }

    public List<T> Data { get; init; } = new();
}

public class SingleResponse<T>
{
    public T Data { get; init; } = default!;
}

public class UserRequest
{
    public string? Name { get; init; }
    public string? Job { get; init; }
}

public class CreateUserResponse
{
    public string? Name { get; init; }
    public string? Job { get; init; }
    public string? Id { get; init; }
    public DateTime? CreatedAt { get; init; }
}

public class UpdateUserResponse
{
    public string? Name { get; init; }
    public string? Job { get; init; }
    public DateTime? UpdatedAt { get; init; }
}

public class AuthRequest
{
    public string? Email { get; init; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Password { get; init; }
}

public class RegisterResponse
{
    public int Id { get; init; }
    public string Token { get; init; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; init; } = string.Empty;
}

public class ErrorResponse
{
    public string Error { get; init; } = string.Empty;
}