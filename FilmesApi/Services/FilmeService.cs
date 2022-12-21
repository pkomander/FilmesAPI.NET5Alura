using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Services
{
    public class FilmeService
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeService(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDto AdicionaFilme(CreateFilmeDto filmeDto)
        {
            Filme filme = _mapper.Map<Filme>(filmeDto);
            _context.Filmes.Add(filme);
            _context.SaveChanges();

            return _mapper.Map<ReadFilmeDto>(filme);
        }

        public List<ReadFilmeDto> RecuperaFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes = new List<Filme>();
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(x => x.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }

            if (filmes != null)
            {
                List<ReadFilmeDto> readDto = _mapper.Map<List<ReadFilmeDto>>(filmes);
                return readDto;
            }

            return null;
        }

        public ReadFilmeDto RecuperaFilmesPorId(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme != null)
            {
                ReadFilmeDto filmeDto = _mapper.Map<ReadFilmeDto>(filme);

                return filmeDto;
            }

            return null;
        }

        public Result AtualizaFilme(int id, UpdateFilmeDto filmeDto)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();
            if (filme == null)
            {
                return Result.Fail("Filme nao encontrado");
            }

            _mapper.Map(filmeDto, filme);
            _context.SaveChanges();

            return Result.Ok();
        }

        public Result DeletaFilme(int id)
        {
            var filme = _context.Filmes.Where(x => x.Id == id).FirstOrDefault();

            if (filme == null)
            {
                return Result.Fail("Filme nao encontrado");
            }
            _context.Remove(filme);
            _context.SaveChanges();

            return Result.Ok();
        }
    }
}
