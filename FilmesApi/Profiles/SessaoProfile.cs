using FilmesApi.Data.Dtos.Sessao;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : AutoMapper.Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            //readeSessao calculando o horario de inicio de forma dinamica
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto =>
                dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
        }
    }
}
