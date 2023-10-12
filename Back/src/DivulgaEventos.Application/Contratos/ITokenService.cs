using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DivulgaEventos.Application.Dtos;

namespace DivulgaEventos.Application.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDto userUpdateDto);
    }
}