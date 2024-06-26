﻿using ExoEntityFrameWork.Contexts;
using ExoEntityFrameWork.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoriesExoEntityFrameWork.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoEntityFrameWork.Repositories
{
    public class FilmService : ICRUDRepository<Film,int>
    {

        /// <summary>
        /// Retourne une collection de films
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Film> GetAll()
        {
            using(FilmDbContext context = new FilmDbContext())
            {
                return context.Films;
            }
        }

        /// <summary>
        /// Retourne un film selon un ou des  critere(s) à définir
        /// </summary>
        /// <param name="predicate"> ex : p => p.Id == id</param>
        /// <returns></returns>
        public Film GetOne(Func<Film,bool> predicate)
        {
            using (FilmDbContext context = new FilmDbContext())
            {
                return context.Films.FirstOrDefault(predicate);
            }
        }

        /// <summary>
        /// Retourne une collection de film selon un ou des critére(s)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<Film> GetMany(Func<Film, bool> predicate)
        {
            using (FilmDbContext context = new FilmDbContext())
            {
                return context.Films.Where(predicate);
            }
        }

        /// <summary>
        /// Ajoute un film en base de donnée et le retourne
        /// </summary>
        /// <param name="film">Le film ajouté</param>
        /// <returns></returns>
        public Film Insert(Film film)
        {
            using (FilmDbContext context = new FilmDbContext())
            {
                Film addFilm = context.Films.Add(film).Entity;
                context.SaveChanges();
                return addFilm;
            }
        }

        /// <summary>
        /// Met à jour les données d'un film (Vérifie si il existe en Db => retourne une exception)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="film"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Film Update(int id, Film film)
        {
            using (FilmDbContext context = new FilmDbContext())
            {
                Film existingFilm = context.Films.FirstOrDefault(f => f.Id == id);
                if(existingFilm is null)
                {
                    throw new Exception("Désolé le film n'existe pas");
                }
                existingFilm.Title = film.Title;
                existingFilm.AnneeSortie = film.AnneeSortie;
                existingFilm.Acteur = film.Acteur;
                existingFilm.Genre = film.Genre;
                existingFilm.Realisateur = film.Realisateur;
                context.SaveChanges();
                return existingFilm;
            }
        }
        /// <summary>
        /// Supprime le film selon l'id
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="DbUpdateException"></exception>
        /// <exception cref="DbUpdateConcurrencyException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Delete(int id)
        {
            try 
            {
                using (FilmDbContext context = new FilmDbContext())
                {
                    Film? existingFilm = context.Films.SingleOrDefault(f => f.Id == id);
                    if (existingFilm is null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(id));
                    }
                    context.Remove(existingFilm);
                    context.SaveChanges();
                }
            }catch (Exception ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Retourne un film avec un Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Film GetById(int id)
        {
            using (FilmDbContext context = new FilmDbContext())
            {
                return context.Films.FirstOrDefault(f => f.Id == id);
            }
        }
    }
}
