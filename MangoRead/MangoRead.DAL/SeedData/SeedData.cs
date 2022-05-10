using MangoRead.Domain.Models;
using MangoRead.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRead.DAL.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, string path)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context == null || context.Manuscripts == null)
                {
                    throw new ArgumentNullException($"{nameof(context)} is null at SeedData.");
                }

                if (context.Manuscripts.Any())
                {
                    return;
                }

                context.Manuscripts.Add(GetManuscriptOne(path));
                context.Manuscripts.Add(GetManuscriptTwo(path));
                context.Manuscripts.Add(GetManuscriptThree(path));

                context.SaveChanges();
            }
        }

        private static ManuscriptReview GetReviewOne()
        {
            ManuscriptReview review = new ManuscriptReview();

            review.Rating = 4;
            review.CouplingGuid = Guid.NewGuid();
            review.Content = "Lorem ipsum ...";
            review.Author = "Simaon";
            review.UploadDate = DateTime.Now;

            return review;
        }

        private static ManuscriptReview GetReviewTwo()
        {
            ManuscriptReview review = new ManuscriptReview();

            review.Rating = 3;
            review.CouplingGuid = Guid.NewGuid();
            review.Content = "Isuzu ipsum ...";
            review.Author = "Ergo";
            review.UploadDate = DateTime.Now;

            return review;
        }

        private static ManuscriptReview GetReviewThree()
        {
            ManuscriptReview review = new ManuscriptReview();

            review.Rating = 3;
            review.CouplingGuid = Guid.NewGuid();
            review.Content = "Lorem ipsum colour ...";
            review.Author = "Sokka";
            review.UploadDate = DateTime.Now;

            return review;
        }

        private static Manuscript GetManuscriptOne(string path)
        {
            Manuscript manuscript = new Manuscript();

            manuscript.Type = ManuscriptType.Manhwa;
            manuscript.Title = "Orewa no kokoro tadashi nii";
            manuscript.Description = "Main character becoming popular thanks to his ability to be super handsome.";
            manuscript.Genres.AddRange(
                new GenreHolder[]
                {
                    new GenreHolder()
                    {
                        Genre = Genre.Action
                    },
                    new GenreHolder()
                    {
                        Genre = Genre.Drama
                    }
                });
            manuscript.UploadDate = new DateTime(2022, 09, 20);
            manuscript.UpdateDate = DateTime.Now;
            manuscript.IsRequireLegalAge = true;
            manuscript.Author = "Kiminoshi Oghakku";
            manuscript.Publisher = "Ergo";
            manuscript.Translator = "Io";
            manuscript.OriginCountry = "Japanese";
            manuscript.TitleImage = new byte[32];
            manuscript.Reviews.Add(GetReviewOne());

            string rootpath = GetRootPath(path, manuscript.Type.ToString());
            manuscript.Content = GetManuscriptContent(manuscript.Index, 9, rootpath, ".png");


            return manuscript;
        }

        private static Manuscript GetManuscriptTwo(string path)
        {
            Manuscript manuscript = new Manuscript();

            manuscript.Type = ManuscriptType.Manga;
            manuscript.Title = "Kiss la Kiss";
            manuscript.Description = "Bro's fighting";
            manuscript.Genres.AddRange(
                new GenreHolder[]
                {
                    new GenreHolder()
                    {
                        Genre = Genre.Action
                    },
                    new GenreHolder()
                    {
                        Genre = Genre.Drama
                    },
                    new GenreHolder()
                    {
                        Genre = Genre.Adventure
                    },
                    new GenreHolder()
                    {
                        Genre = Genre.Detective
                    }
                });
            manuscript.UploadDate = new DateTime(2014, 06, 23);
            manuscript.UpdateDate = DateTime.Now;
            manuscript.IsRequireLegalAge = false;
            manuscript.Author = "Siminoske Rouka";
            manuscript.Publisher = "Ergo";
            manuscript.Translator = "Io";
            manuscript.OriginCountry = "Japanese";
            manuscript.TitleImage = new byte[48];
            manuscript.Reviews.Add(GetReviewTwo());

            string rootpath = GetRootPath(path, manuscript.Type.ToString());
            manuscript.Content = GetManuscriptContent(manuscript.Index, 15, rootpath, ".jpg");


            return manuscript;
        }

        private static Manuscript GetManuscriptThree(string path)
        {
            Manuscript manuscript = new Manuscript();

            manuscript.Type = ManuscriptType.Webtoon;
            manuscript.Title = "Romance on Krasnogvardeyskaya street";
            manuscript.Description = "Just a two lover trying to survive in this dangerous world.";
            manuscript.Genres.AddRange(
                new GenreHolder[]
                {
                    new GenreHolder()
                    {
                        Genre = Genre.Romance
                    }
                });
            manuscript.UploadDate = new DateTime(1996, 06, 15);
            manuscript.UpdateDate = DateTime.Now;
            manuscript.IsRequireLegalAge = false;
            manuscript.Author = "Maoyka Ushigahara";
            manuscript.Publisher = "Ergo";
            manuscript.Translator = "Io";
            manuscript.OriginCountry = "Japanese";
            manuscript.TitleImage = new byte[32];
            manuscript.Reviews.Add(GetReviewThree());

            string rootpath = GetRootPath(path, manuscript.Type.ToString());
            manuscript.Content = GetManuscriptContent(manuscript.Index, 33, rootpath, ".jpg");


            return manuscript;
        }

        private static string GetRootPath(string relativePath, string manuscriptType)
        {
            string relativePathToContent = relativePath;
            string projectPath = Directory.GetCurrentDirectory();
            string rootContentPath = string.Concat(projectPath, relativePathToContent, manuscriptType);

            return rootContentPath;
        }

        private static ManuscriptContent GetManuscriptContent(Guid folderName, int pagesAmount, string path, string extension)
        {
            ManuscriptContent manuscriptContent = new ManuscriptContent();

            manuscriptContent.FolderName = folderName.ToString();

            Volume volume = new Volume();
            Chapter chapter = new Chapter();

            for (int i = 0; i < pagesAmount; i++)
            {
                chapter.Pages.AddPage(i.ToString(), extension, path);
            }

            volume.Chapters.Add(chapter);
            manuscriptContent.Volumes.Add(volume);

            return manuscriptContent;
        }

        private static void AddPage(this List<Page> content, string name, string extension, string path)
        {
            string pagePath = string.Concat(path, $@"\{name}{extension}");

            content.Add(new Page()
            {
                Name = name,
                Extension = extension,
                Path = pagePath,
                Comments = new List<Comment>
                {
                    new Comment()
                    {
                        Content = "Really breathtaking story!",
                        CreationDate = DateTime.Now,
                        Author = "Simaon",
                        /*Replies = new List<Comment> {
                            new Comment()
                            {
                                Content = "Completely agree",
                                CreationDate = DateTime.Now,
                                Author = "Jorsh"
                            }
                        }*/
                    },
                    new Comment()
                    {
                        Content = "Fascinating!",
                        CreationDate = DateTime.Now,
                        Author = "Sokka"
                    },
                    new Comment()
                    {
                        Content = "Cool and brave fable!",
                        CreationDate = DateTime.Now,
                        Author = "Aang"
                    }
                }
            });
        }
    }
}
