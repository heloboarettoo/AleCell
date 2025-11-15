
using AleCell.API.DTOs;

namespace AleCell.API.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}