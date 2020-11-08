using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminLTE.MVC.Models;
using AdminLTE.MVC.Models.School;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AdminLTE.MVC.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>());
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R",
                },

                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "R",
                },

                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M
                },

                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M
                }
            );

            context.Course.AddRange(new Course()
            {
                Name = "Буквата Р",
                UnitList = new List<Unit>()
                {
                    new Unit()
                    {
                        Name = "Час 1",
                        Description = "Гимнастика на јазик и образи",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "Јазикот го плазиме надвор"
                            },
                            new Exercise()
                            {
                                Name = "Јазикот го креваме према нос и надолу према брада"
                            },
                            new Exercise()
                            {
                                Name = "Јазикот е надвор и правиме кружни движења (како оближување)"
                            },
                            new Exercise()
                            {
                                Name = "Ги дуваме образите"
                            },
                            new Exercise()
                            {
                                Name = "Со затворени заби буткаме со јазикот"
                            },
                            new Exercise()
                            {
                                Name = "ОД насмевка во бакнеж"
                            },
                            new Exercise()
                            {
                                Name = "Имитираме џвакање"
                            },
                            new Exercise()
                            {
                                Name = "Силно отвораме уста"
                            },
                            new Exercise()
                            {
                                Name = "Вежбите ги правиме секој ден со најмалку 5 повторувања"
                            },
                        },
                    },
                    new Unit()
                    {
                        Name = "Час 2",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "тра, тре, три, тро, тру",
                            },
                            new Exercise()
                            {
                                Name = "ра, ре, ри, ро, ру",
                            },
                            new Exercise()
                            {
                                Name = "ар, ер, ир, ор, ур",
                            },
                            new Exercise()
                            {
                                Name = "ара, ере, ири, оро, ару",
                            },
                            new Exercise()
                            {
                                Name = "ера, ери, еро, еру",
                            },
                            new Exercise()
                            {
                                Name = "ира, ире, иро, иру",
                            },
                            new Exercise()
                            {
                                Name = "ора, оре, ори, ору",
                            },
                            new Exercise()
                            {
                                Name = "ура,уре, ури, уро",
                            },
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 3",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "работа, рака, река, ресен, риба, рис, рог, роба, румен, рум"
                            },
                            new Exercise()
                            {
                                Name = "рара, рере, рири, роро, руру"
                            },
                            new Exercise()
                            {
                                Name = "рера, рере, рери, реро, реру"
                            },
                            new Exercise()
                            {
                                Name = "рира, рире, риро, риру"
                            },
                            new Exercise()
                            {
                                Name = "рора, роре, рори, рору"
                            },
                            new Exercise()
                            {
                                Name = "рура, руре, рури, руро"
                            },
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 4",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "рамка, расипан, ранец, рака, работа, рало, расеан, рачка, рамно, раса, рано, раб"
                            },
                            new Exercise()
                            {
                                Name = "река, ресен, рен, рели, рече, ремче, реми, релна, ребро"
                            },
                            new Exercise()
                            {
                                Name = "рима, рило, рика, рис, риба, рибар, рид, рингла, рипне"
                            },
                            new Exercise()
                            {
                                Name = "роб, робот, рог, род, роден, роди, родител, роза, розов, рок, роман, рони"
                            },
                            new Exercise()
                            {
                                Name = "ружа, румен, рус, руча, ручек, рузи, рудник, рудар"
                            }
                        },
                    },
                    new Unit()
                    {
                        Name = "Час 5",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "автор, аждер, актер, америка, астролог, архив, арија, аптекар"
                            },
                            new Exercise()
                            {
                                Name = "бабура, багер, багрем, бајрак, балерина, божур,болничар, борец, борба"
                            },
                            new Exercise()
                            {
                                Name = "варди,вари, вароса, ведар, ведрина, внатре, воденичар, водомер"
                            },
                            new Exercise()
                            {
                                Name = "гради, гајдар, географија, градба, градина, граѓанин, граница, грб, греалка, гребе, гризе, грее, грми, грозд, гром, гусар"
                            },
                            new Exercise()
                            {
                                Name = "дар, дарува, дворец, дрво, дрдори, држава, дроби, другар, друго, дружи, друштво"
                            },
                            new Exercise()
                            {
                                Name = "свирач, секира, сестра, срам, срами, среди, средба, срна, срце, средина"
                            },
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 6",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "Горан гради зграда"
                            },
                            new Exercise()
                            {
                                Name = "Сара гризе круша"
                            },
                            new Exercise()
                            {
                                Name = "Марко е гусар на брод"
                            },
                            new Exercise()
                            {
                                Name = "Обрав грозд црно грозје"
                            },
                            new Exercise()
                            {
                                Name = " Добро друштво е собрано"
                            },
                            new Exercise()
                            {
                                Name = "Срна е срце на стрина"
                            },
                            new Exercise()
                            {
                                Name = "Маријан е аптекар"
                            },
                            new Exercise()
                            {
                                Name = "Греалката грее"
                            },
                            new Exercise()
                            {
                                Name = "Рибарот фати риба"
                            },
                            new Exercise()
                            {
                                Name = "Мачорот гребе"
                            },
                            new Exercise()
                            {
                                Name = "Боро дрдори"
                            },
                            new Exercise()
                            {
                                Name = "Бабурата е пиперка"
                            },
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 6",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "Ра-ла    Ла-ра"
                            },
                            new Exercise()
                            {
                                Name = "Ре-ле    Ле-ре"
                            },
                            new Exercise()
                            {
                                Name = "Ри-ли   Ли-ри"
                            },
                            new Exercise()
                            {
                                Name = "Ро-ло    Ло-ро"
                            },
                            new Exercise()
                            {
                                Name = "Ру-лу    Лу-ру"
                            },
                            new Exercise()
                            {
                                Name = "мисирка"
                            },
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 7",
                        Description = "Л,Р",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "Лавор, лекар, линеарен, лозар, лустер"
                            },
                            new Exercise()
                            {
                                Name = "разболи, разгален, разгледа, реклама, република, рингла, ролат, родител, разлути, ролна, разлади"
                            },
                            new Exercise()
                            {
                                Name = "игралиште, истрел"
                            }
                        }
                    },
                    new Unit()
                    {
                        Name = "Час 8",
                        ExerciseList = new List<Exercise>()
                        {
                            new Exercise()
                            {
                                Name = "Штркот е птица преселница"
                            },
                            new Exercise()
                            {
                                Name = "Имам розов лустер"
                            },
                            new Exercise()
                            {
                                Name = "Родителите се разлутија на игралиштето"
                            },
                            new Exercise()
                            {
                                Name = "Свирачите свират на средина"
                            },
                            new Exercise()
                            {
                                Name = "Дарија има румени образи"
                            },
                            new Exercise()
                            {
                                Name = "Ратка Рипа Преку Пруга"
                            },
                        }
                    }
                }

            },
                new Course()
                {
                    Name = "Буквата Л",
                    UnitList = new List<Unit>()
                    {
                        new Unit()
                        {
                            Name = "Час 1",
                            ExerciseList = new List<Exercise>()
                            {
                                new Exercise()
                                {
                                    Name = "Ла, ле, ли, ло, лу"
                                },
                                new Exercise()
                                {
                                    Name = "Ал, ел, ил, ол, ул"
                                },
                                new Exercise()
                                {
                                    Name = "ала, еле, или, оло, улу"
                                },
                                new Exercise()
                                {
                                    Name = "Але, али, ало, алу"
                                },
                                new Exercise()
                                {
                                    Name = "ела, ели, ело, елу"
                                },
                                new Exercise()
                                {
                                    Name = "ила, иле, ило, илу"
                                },
                                new Exercise()
                                {
                                    Name = "Ола, оле, оли, олу"
                                },
                                new Exercise()
                                {
                                    Name = "Ула, уле, ули, уло"
                                },
                                new Exercise()
                                {
                                    Name = "Лала, лале, лали, лало, лалу"
                                },
                                new Exercise()
                                {
                                    Name = "лела, леле, лели, лело, лелу"
                                },
                                new Exercise()
                                {
                                    Name = "лилал, лиле, лили, лило, лилу"
                                },
                                new Exercise()
                                {
                                    Name = "лола, лоле, лоли, лоло, лолу"
                                },
                                new Exercise()
                                {
                                    Name = "лула, луле, лули, луло, лулу"
                                },
                            }
                        },
                        new Unit()
                        {
                            Name = "Час 2",
                            ExerciseList = new List<Exercise>()
                            {
                                new Exercise()
                                {
                                    Name = "Ла-ва, ва-ла"
                                },
                                new Exercise()
                                {
                                    Name = "ле-ве, ве-ле"
                                },
                                new Exercise()
                                {
                                    Name = "ли-ви, ви-ли"
                                },
                                new Exercise()
                                {
                                    Name = "ло-во, во-ло"
                                },
                                new Exercise()
                                {
                                    Name = "лу-ву, ву-лу"
                                },
                                new Exercise()
                                {
                                    Name = "ла-ва-ра"
                                },
                                new Exercise()
                                {
                                    Name = "ле-ве-ре"
                                },
                                new Exercise()
                                {
                                    Name = "ли-ви-ри"
                                },
                                new Exercise()
                                {
                                    Name = "ло-во-ро"
                                },
                                new Exercise()
                                {
                                    Name = "лу-ву-ру"
                                },
                                new Exercise()
                                {
                                    Name = "ва-ла-ра"
                                },
                                new Exercise()
                                {
                                    Name = "ве-ле-ре"
                                },
                                new Exercise()
                                {
                                    Name = "ви-ли-ри"
                                },
                                new Exercise()
                                {
                                    Name = "во-ло-ро"
                                },
                                new Exercise()
                                {
                                    Name = "ву-лу-ру"
                                },
                                new Exercise()
                                {
                                    Name = "ва-ра  ра-ва"
                                },
                                new Exercise()
                                {
                                    Name = "ве-ре  ре-ве"
                                },
                                new Exercise()
                                {
                                    Name = "ви-ри  ри-ви"
                                },
                                new Exercise()
                                {
                                    Name = "во-ро  ро-во"
                                },
                                new Exercise()
                                {
                                    Name = "ву-ру  ру-ву"
                                },
                                new Exercise()
                                {
                                    Name = "ла-ра  ра-ла"
                                },
                                new Exercise()
                                {
                                    Name = "ле-ре  ре-ле"
                                },
                                new Exercise()
                                {
                                    Name = "ли-ри  ри-ли"
                                },
                                new Exercise()
                                {
                                    Name = "ло-ро  ро-ло"
                                },
                                new Exercise()
                                {
                                    Name = "лу-ру  ру-лу"
                                },
                            }
                        }
                    }

                });
            context.SaveChanges();
        }
    }
}
