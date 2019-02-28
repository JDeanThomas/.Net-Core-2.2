using MovieApp.Entities;
using MovieApp.Models;

namespace MovieApp.Helpers
{
    public static class CreateFilmDetail
    {
        public static FilmDetailModel CreateFilmDetailModel(Film film)
        {
            var model = film.Copy<Film, FilmDetailModel>();

            if (film.FilmImage != null)
            {
                //model.FilmImageId = film.FilmImage.FilmImageId;
                model = film.FilmImage.FilmImageId;
            }

            return (FilmDetailModel)model;
        }

        public static FilmDetailModel CreateFilmDetailModel(FilmImage image)
        {
            var model = image.Film.Copy<Film, FilmDetailModel>();

            //model.FilmImageId = image.FilmImageId;
            model = image.FilmImageId;

            return (FilmDetailModel)model;
        }
    }
}