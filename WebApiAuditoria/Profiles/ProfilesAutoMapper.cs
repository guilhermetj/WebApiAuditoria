using AutoMapper;
using WebApiAuditoria.Dto.Usuario;
using WebApiAuditoria.Models;

namespace WebApiAuditoria.Profiles
{
    public class ProfilesAutoMapper : Profile
    {
        public ProfilesAutoMapper()
        {
            CreateMap<UsuarioCriacaoDto, UsuarioModel>().ReverseMap();
        }
    }
}
