using StorageTest.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageTest.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // for web apps use this:
            // AppDomain.CurrentDomain.SetData("DataDirectory", Server.MapPath("~/App_Data/"));

            // for desktop apps this:
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory + "App_Data\\");


            Console.Write("Opening DB Context...");
            try {
                using (DvdContext db = new DvdContext())
                {
                    Console.WriteLine(" success!");

                    System.Data.Entity.Database dbObject = db.Database;

                    Console.WriteLine();
                    Console.WriteLine(String.Format("{0,25}: {1}", "Type of connection", dbObject.Connection.GetType().ToString()));
                    Console.WriteLine(String.Format("{0,25}: '{1}'", "Connection string", dbObject.Connection.ConnectionString));
                    if (dbObject.Connection is System.Data.SqlServerCe.SqlCeConnection)
                    {
                        Console.WriteLine(String.Format("{0,25}: {1}", "Data Directory", AppDomain.CurrentDomain.GetData("DataDirectory").ToString()));
                        Console.WriteLine(String.Format("{0,25}: {1}", "Server version", dbObject.Connection.ServerVersion));
                    }
                    Console.WriteLine();

                    Console.WriteLine("Gettings film genres...");
                    // film generes
                    Genre actionGenre = db.Genres.Where(g => g.Name == "Action").SingleOrDefault();
                    Genre scifiGenre = db.Genres.Where(g => g.Name == "SciFi").SingleOrDefault();

                    Console.WriteLine("Getting J. J. Abrams the producer...");
                    // find the producer
                    Producer jjAbrams = db.Producers.Include("Films").Where(p => p.FullName == "J.J. Abrams").SingleOrDefault();
                    // we found the producer
                    if (jjAbrams != null)
                    {
                        if (jjAbrams.Films.Count == 0)
                        {
                            // and add a film
                            Film film1 = new Film()
                            {
                                Title = "Mission: Impossible III",
                                ReleaseYear = 2006,
                                Duration = 126,
                                Story = "Ethan Hunt comes face to face with a dangerous and ...",
                                Genre = actionGenre
                            };
                            film1.Producers = new List<Producer>();
                            film1.Producers.Add(jjAbrams);

                            db.Films.Add(film1);
                           

                            // add some films to that producer
                            Console.WriteLine("Adding 'Star Trek Into Darkness' as his film...");
                            Film film2 = new Film()
                            {
                                Title = "Star Trek Into Darkness",
                                ReleaseYear = 2013,
                                Duration = 132,
                                Story = "After the crew of the Enterprise find an unstoppable force  ...",
                                Genre = scifiGenre
                            };
                            
                            film2.Producers = new List<Producer>();
                            film2.Producers.Add(jjAbrams);

                            film2.Notes = new List<Note>();
                            film2.Notes.Add(new Note() { Text = "Was it a good film?" });
                            film2.Notes.Add(new Note() { Text = "Well, I liked it!" });
                            
                            db.Films.Add(film2);


                            Console.WriteLine("Adding lead and supporting roles to these films...");
                            
                            // add some film roles
                            Role leadRole = db.Roles.Where(r => r.Name == "Lead").SingleOrDefault();
                            Role supportingRole = db.Roles.Where(r => r.Name == "Supporting").SingleOrDefault();
                            
                            // load the actors
                            Actor tom = db.Actors.Where(a => a.Surname == "Cruise").SingleOrDefault();
                            Actor quinto = db.Actors.Where(a => a.Surname == "Quinto").SingleOrDefault();
                            Actor pine = db.Actors.Where(a => a.Surname == "Pine").SingleOrDefault();
                            
                            // add filmroles
                            db.FilmActorRoles.Add(new FilmActorRole()
                            {
                                Actor = tom,
                                Role = leadRole,
                                FilmTitle = film1,
                                Character = "Ethan",
                                Description = "Ethan Hunt comes face to face with a dangerous and sadistic arms dealer while trying to keep his identity secret in order to protect his girlfriend."
                            });

                            db.FilmActorRoles.Add(new FilmActorRole()
                            {
                                Actor = pine,
                                Role = leadRole,
                                FilmTitle = film2,
                                Character = "Kirk",
                                Description = "Captain Kirk"
                            });

                            db.FilmActorRoles.Add(new FilmActorRole()
                            {
                                Actor = quinto,
                                Role = supportingRole,
                                FilmTitle = film2,
                                Character = "Spock",
                                Description = "Spock was born in 2230, in the city of Shi'Kahr on the planet Vulcan"
                            });
                        }
                        else
                        {
                            Console.WriteLine("There are " + jjAbrams.Films.Count + " films of J. J. Abrams in the DB, so we don't need to insert anything!");
                        }
                    }

                    Console.Write("Saving changes to DB...");
                    // save data to db
                    db.SaveChanges();
                    Console.WriteLine(" done!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(" failed!");
                
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }
    }
}
