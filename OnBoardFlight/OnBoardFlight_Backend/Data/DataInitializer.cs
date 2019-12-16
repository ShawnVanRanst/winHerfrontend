using Microsoft.AspNetCore.Identity;
using OnBoardFlight.Model;
using OnBoardFlight_Backend.Model;
using OnBoardFlight_Backend.Model.MediaTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardFlight.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
            //_userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if(_dbContext.Database.EnsureCreated())
            {

                #region Flights
                Flight flight = new Flight()
                {
                    Origin = new Location()
                    {
                        Airport = "Brussels Airport",
                        City = "Zaventem",
                        CountryIso = "bel",
                        Country = "Belgium",
                        Time = new DateTime(2019, 12, 15, 10, 45, 0)
                    },
                    Destination = new Location()
                    {
                        Airport = "Internationale Luchthaven Barcelona",
                        City = "Barcelona",
                        CountryIso = "esp",
                        Country = "Spain",
                        Time = new DateTime(2019, 12, 15, 12, 25, 0)
                    }
                };
                _dbContext.Flights.Add(flight);
                #endregion

                #region Notification
                Notification notification1 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification1);
                Notification notification2 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification2);
                Notification notification3 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification3);
                Notification notification4 = new Notification { Title = "Safety First", Content = "This is a plain, not some kampin kitsch party", SinglePerson = true };
                _dbContext.Add(notification4);
                #endregion

                #region Users
                CabinCrew crewMember1 = new CabinCrew { Login = "RR", Pass = "pornhub", FirstName = "Riley", LastName = "Reid", Flight = flight };
                //await CreateUser(crewMember.Login, "P@ssword1");
                _dbContext.Users.Add(crewMember1);

                CabinCrew crewMember2 = new CabinCrew { Login = "crewmember2", Pass = "234", Flight = flight };
                _dbContext.Users.Add(crewMember2);

                Passenger passenger1 = new Passenger("Arno", "Boel", "01A") { Flight = flight };
                passenger1.AddNotification(notification1);
                

                Passenger passenger2 = new Passenger("Ruben", "Grillaert", "20D") { Flight = flight };
                passenger2.AddNotification(notification2);
                

                Passenger passenger3 = new Passenger("Shawn", "Van Ranst", "12F") { Flight = flight };
                passenger3.AddNotification(notification3);
                

                Passenger passenger4 = new Passenger("Melissa", "Van Belle", "01B") { Flight = flight };
                passenger4.AddNotification(notification4);

                #region Chat
                passenger1.AddTravelCompanion(passenger2);
                passenger1.AddTravelCompanion(passenger3);
                passenger1.AddTravelCompanion(passenger4);
                passenger2.AddTravelCompanion(passenger3);
                passenger2.AddTravelCompanion(passenger4);
                passenger3.AddTravelCompanion(passenger4);
                passenger1.Chats.First().AddMessage(new Message(passenger2, "Test 123 test"));
                #endregion

                _dbContext.Users.Add(passenger1);
                _dbContext.Users.Add(passenger2);
                _dbContext.Users.Add(passenger3);
                _dbContext.Users.Add(passenger4);
                #endregion

                

                #region Media

                #region Movie
                Movie movie1 = new Movie("movie.jfif", "The Dictator", "Exiled to America. What’s a power-abusing world leader to do? Offend EVERYBODY and maybe get his country back.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie1);

                Movie movie2 = new Movie("movie.jfif", "The Hangover", "Three buddies wake up from a bachelor party in Las Vegas, with no memory of the previous night and the bachelor missing. They make their way around the city in order to find their friend before his wedding.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie2);

                Movie movie3 = new Movie("movie.jfif", "The Hangover Part II", "Two years after the bachelor party in Las Vegas, Phil, Stu, Alan, and Doug jet to Thailand for Stu's wedding. Stu's plan for a subdued pre-wedding brunch, however, goes seriously awry.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie3);

                Movie movie4 = new Movie("movie.jfif", "The Hangover Part III", "When one of their own is kidnapped by an angry gangster, the Wolf Pack must track down Mr. Chow, who has escaped from prison and is on the run.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie4);

                Movie movie5 = new Movie("movie.jfif", "Ted", "John Bennett, a man whose childhood wish of bringing his teddy bear to life came true, now must decide between keeping the relationship with the bear or his girlfriend, Lori.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie5);

                Movie movie6 = new Movie("movie.jfif", "Ted 2", "Newlywed couple Ted and Tami-Lynn want to have a baby, but in order to qualify to be a parent, Ted will have to prove he's a person in a court of law.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie6);

                Movie movie7 = new Movie("movie.jfif", "We're the Millers", "A veteran pot dealer creates a fake family as part of his plan to move a huge shipment of weed into the U.S. from Mexico.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie7);

                Movie movie8 = new Movie("movie.jfif", "Bad Neighbours", "After they are forced to live next to a fraternity house, a couple with a newborn baby do whatever they can to take them down.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie8);

                Movie movie9 = new Movie("movie.jfif", "Bad Neighbours 2", "When their new next-door neighbors turn out to be a sorority even more debaucherous than the fraternity previously living there, Mac and Kelly team with their former enemy, Teddy, to bring the girls down.", VideoCategory.comedy, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie9);


                Movie movie11 = new Movie("movie.jfif", "No Time to Die", "Bond has left active service. His peace is short-lived when his old friend Felix Leiter from the CIA turns up asking for help, leading Bond onto the trail of a mysterious villain armed with dangerous new technology.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie11);

                Movie movie12 = new Movie("movie.jfif", "Spectre", "A cryptic message from James Bond's past sends him on a trail to uncover the exsistence of a sinister organisation named SPECTRE. With a new threat dawning, Bond learns the terrible truth about the author of all his pain in his most recent missions.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie12);

                Movie movie13 = new Movie("movie.jfif", "Skyfall", "Bond's loyalty to M is tested when her past comes back to haunt her. When MI6 comes under attack, 007 must track down and destroy the threat, no matter how personal the cost.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie13);

                Movie movie14 = new Movie("movie.jfif", "Casino Royale", "After earning 00 status and a licence to kill, Secret Agent James Bond (Daniel Craig) sets out on his first mission as 007. Bond must defeat a private banker funding terrorists in a high stakes game of poker at Casino Royale, Montenegro.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie14);

                Movie movie15 = new Movie("movie.jfif", "Quantum of Solace", "James Bond (Daniel Craig) descends into mystery as he tries to stop a mysterious organization from eliminating a country's most valuable resource.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie15);

                Movie movie16 = new Movie("movie.jfif", "Tomorrow Never", "James Bond(Pierce Brosnan) heads to stop a media mogul's plan to induce war between China and the U.K. in order to obtain exclusive global media coverage.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie16);

                Movie movie17 = new Movie("movie.jfif", "The World Is Not Enough", "James Bond (Pierce Brosnan) uncovers a nuclear plot when he protects an oil heiress from her former kidnapper, an international terrorist who can't feel pain.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie17);

                Movie movie18 = new Movie("movie.jfif", "Octopussy", "A fake Fabergé egg, and a fellow Agent's death, lead James Bond to uncover an international jewel-smuggling operation, headed by the mysterious Octopussy, being used to disguise a nuclear attack on N.A.T.O. forces.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie18);

                Movie movie19 = new Movie("movie.jfif", "For Your Eyes Only", "Agent 007 is assigned to hunt for a lost British weapons communication/control device and prevent it from falling into enemy hands.", VideoCategory.action, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie19);


                Movie movie111 = new Movie("movie.jfif", "It", "In the summer of 1989, a group of bullied kids band together to destroy a shape-shifting monster, which disguises itself as a clown and preys on the children of Derry, their small Maine town.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie111);

                Movie movie122 = new Movie("movie.jfif", "It Chapter Two", "Twenty-seven years after their first encounter with the terrifying Pennywise, the Losers Club have grown up and moved away, until a devastating phone call brings them back.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie122);

                Movie movie133 = new Movie("movie.jfif", "A Quiet Place", "In a post-apocalyptic world, a family is forced to live in silence while hiding from monsters with ultra-sensitive hearing.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie133);

                Movie movie144 = new Movie("movie.jfif", "The Conjuring", "Paranormal investigators Ed and Lorraine Warren work to help a family terrorized by a dark presence in their farmhouse.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie144);

                Movie movie155 = new Movie("movie.jfif", "The Conjuring 2", "Ed and Lorraine Warren travel to North London to help a single mother raising 4 children alone in a house plagued by a supernatural spirit.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie155);

                Movie movie166 = new Movie("movie.jfif", "Insidious", "A family looks to prevent evil spirits from trapping their comatose child in a realm called The Further.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie166);

                Movie movie177 = new Movie("movie.jfif", "Insidious: Chapter 2", "The Lamberts believe that they have defeated the spirits that have haunted their family, but they soon discover that evil is not beaten so easily.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie177);

                Movie movie188 = new Movie("movie.jfif", "Insidious: Chapter 3", "A prequel set before the haunting of the Lambert family that reveals how gifted psychic Elise Rainier reluctantly agrees to use her ability to contact the dead in order to help a teenage girl who has been targeted by a dangerous supernatural entity.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie188);

                Movie movie199 = new Movie("movie.jfif", "Snakes on a Plane", "An F.B.I. Agent takes on a plane full of deadly venomous snakes, deliberately released to kill a witness being flown from Honolulu to Los Angeles to testify against a mob boss.", VideoCategory.horror, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie199);


                Movie movie1111 = new Movie("movie.jfif", "Seven Worlds, One Planet", "Attenborough is back. The latest environmental epic from the BBC’s Natural History Unit was filmed over 1,794 days, with 91 shoots taking place across 41 different countries. But even that doesn’t quite do justice to the sheer scale of this landmark documentary. As the title suggests, this seven-episode series focuses on Earth’s seven continents. The first episode focuses on Antarctica, diving below the sea ice to reveal a thriving, beautiful world.", VideoCategory.science, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie1111);

                Movie movie1222 = new Movie("movie.jfif", "The Americas with Simon Reeve", "Simon Reeve is back with another epic adventure, this time covering the length and breadth of the Americas. Over the course of five hour-long episodes Reeve winds his way from the tip of Alaska to the foot of South America, telling stories of little-visited places and remarkable people. It's all fans of Reeve have come to expect: great stories, great enthusiasm and a fine collection of scarves. ", VideoCategory.science, "AtjeVoorDeSfeer.mp4");
                _dbContext.Mediafiles.Add(movie1222);
                #endregion

                #region Serie
                Serie serie1 = new Serie("movie.jfif", "Vikings ", "Vikings transports us to the brutal and mysterious world of Ragnar Lothbrok, a Viking warrior and farmer who yearns to explore - and raid - the distant shores across the ocean.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie1);

                Serie serie2 = new Serie("movie.jfif", "Game of Thrones ", "Nine noble families fight for control over the mythical lands of Westeros, while an ancient enemy returns after being dormant for thousands of years.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie2);

                Serie serie3 = new Serie("movie.jfif", "The Witcher", "Geralt of Rivia, a solitary monster hunter, struggles to find his place in a world where people often prove more wicked than beasts.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie3);

                Serie serie4 = new Serie("movie.jfif", "Arrow ", "Spoiled billionaire playboy Oliver Queen is missing and presumed dead when his yacht is lost at sea. He returns five years later a changed man, determined to clean up the city as a hooded vigilante armed with a bow.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie4);

                Serie serie5 = new Serie("movie.jfif", "The Flash", "After being struck by lightning, Barry Allen wakes up from his coma to discover he's been given the power of super speed, becoming the Flash, fighting crime in Central City.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie5);

                Serie serie6 = new Serie("movie.jfif", "Batwoman", "Kate Kane seeks justice for Gotham City as Batwoman.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie6);

                Serie serie7 = new Serie("movie.jfif", "Harley Quinn ", "The series will focus on a newly single Harley Quinn, who sets off to make it on her own in Gotham City.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie7);

                Serie serie8 = new Serie("movie.jfif", "SEAL Team", "The lives of the elite Navy SEALs as they train, plan and execute the most dangerous, high-stakes missions our country can ask.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie8);

                Serie serie9 = new Serie("movie.jfif", "Legends of Tomorrow", "Time-travelling rogue Rip Hunter has to recruit a rag-tag team of heroes and villains to help prevent an apocalypse that could impact not only Earth, but all of time.", VideoCategory.action);
                _dbContext.Mediafiles.Add(serie9);


                Serie serie11 = new Serie("movie.jfif", "Rick and Morty ", "An animated series that follows the exploits of a super scientist and his not-so-bright grandson.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie1);

                Serie serie22 = new Serie("movie.jfif", "Friends", "Follows the personal and professional lives of six twenty to thirty-something-year-old friends living in Manhattan.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie22);

                Serie serie33 = new Serie("movie.jfif", "The Office", "A mockumentary on a group of typical office workers, where the workday consists of ego clashes, inappropriate behavior, and tedium.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie33);

                Serie serie44 = new Serie("movie.jfif", "The Big Bang Theory", "A woman who moves into an apartment across the hall from two brilliant but socially awkward physicists shows them how little they know about life outside of the laboratory.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie44);

                Serie serie55 = new Serie("movie.jfif", "Brooklyn Nine-Nine", "Jake Peralta, an immature, but talented N.Y.P.D. detective in Brooklyn's 99th Precinct, comes into immediate conflict with his new commanding officer, the serious and stern Captain Ray Holt.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie55);

                Serie serie66 = new Serie("movie.jfif", "South Park", "Follows the misadventures of four irreverent grade-schoolers in the quiet, dysfunctional town of South Park, Colorado.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie66);

                Serie serie77 = new Serie("movie.jfif", "The End of the F***ing World", "James is 17 and is pretty sure he is a psychopath. Alyssa, also 17, is the cool and moody new girl at school. The pair make a connection and she persuades him to embark on a road trip in search of her real father.", VideoCategory.comedy);
                _dbContext.Mediafiles.Add(serie77);


                Serie serie31 = new Serie("movie.jfif", "V-Wars", "Dr. Luther Swann, enters a world of horror when a virus is released in ice melting due to climate change.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie31);

                Serie serie32 = new Serie("movie.jfif", "The Walking Dead", "Sheriff Deputy Rick Grimes wakes up from a coma to learn the world is in ruins, and must lead a group of survivors to stay alive.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie32);

                Serie serie333 = new Serie("movie.jfif", "American Horror Story", "An anthology series centering on different characters and locations, including a house with a murderous past, an insane asylum, a witch coven, a freak show circus, a haunted hotel, a possessed farmhouse, a cult, the apocalypse, and a slasher summer camp.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie333);

                Serie serie34 = new Serie("movie.jfif", "Stranger Things", "When a young boy disappears, his mother, a police chief, and his friends must confront terrifying supernatural forces in order to get him back.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie34);

                Serie serie35 = new Serie("movie.jfif", "The Vampire Diaries", "The lives, loves, dangers and disasters in the town, Mystic Falls, Virginia. Creatures of unspeakable horror lurk beneath this town as a teenage girl is suddenly torn between two vampire brothers.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie35);

                Serie serie36 = new Serie("movie.jfif", "The Purge", "Set in an altered United States, several unrelated people discover how far they will go to survive a night where all crime is legal for 12 hours.", VideoCategory.horror);
                _dbContext.Mediafiles.Add(serie36);

                #region MindField
                Serie MindField = new Serie("MF.jpg", "Mind Field",
                    "In Mind Field, host Michael Stevens brings his passion for science to " +
                    "his most ambitious subject yet: something we still know very little about, " +
                    "human behavior." +
                    "Using real subjects (including guest stars and Michael himself) " +
                    "Mind Field reveals some of the most mind-blowing, " +
                    "significant, and least-understood aspects of the human psyche." +
                    "Through expert interviews, rare footage from historical experiments, " +
                    "and brand-new, ground-breaking demonstrations of human nature at work, " +
                    "Mind Field explores the surprising things we know (and don’t know) about " +
                    "why people are the way they are.", VideoCategory.science);

                _dbContext.Add(MindField);

                List<SerieEpisode> serieEpisodes = new List<SerieEpisode>();

                serieEpisodes.Add(new SerieEpisode("MF1.png", "Isolation", "What happens when your brain is deprived of stimulation? What effect does being cut off from interaction with the outside world have on a person?  What effect does it have on me, when I am locked in a windowless, soundproof isolation chamber for three days?", 1, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF2.png", "Conformity", "We are all unique individuals.  We follow the beat of our own drum.  We wouldn’t throw our own beliefs out the window just to fit in...or would we?  In this episode of Mind Field, I demonstrate the strong, human urge to conform, and just how far people will go to fall in with the crowd.", 2, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF3.png", "Destruction", "We humans love to build, create, and organize.  So why do we also love to destroy things?  Can violently breaking stuff really help to calm us down, or does it just make us more angry?  In this episode of Mind Field, I take a hard look at our urge to destroy.", 3, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF4.png", "Artificial Intelligence", "So you say you love your computer or smartphone...but can it love you back? As we become more dependent on technology, and our technology becomes more lifelike, where does the line between human and computer lie?  And what happens when our relationships become romantic?", 4, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF5.png", "Freedom of Choice", "We may value having Freedom of Choice, but are we actually happier when we have limited choices...or even no choice at all?  Do we truly have control over our decisions, or are they really predetermined by other forces?  My fellow YouTubers and I have our minds read by a “box” that reveals who - or what - is really calling the shots. ", 5, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF6.png", "Touch", "How much of the sensations we feel is determined by our physical bodies?  Maybe our minds play a bigger role than we know.  I’ll see if people can be tricked into feeling intense physical pain, even though it’s all in their heads.  I’ll also look at a machine that makes it possible for you to tickle yourself, and I’ll show you a weird physical illusion you can do at home.", 6, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF7.png", "In Your Face", "How much do we communicate through facial expressions?  Are our expressions affected by our moods, or is it the other way around?  And what happens to your ability to relate to others when your facial muscles are frozen by Botox?  In this episode of Mind Field, I take a look at what’s In Your Face.", 7, 1, "AtjeVoorDeSfeer.mp4"));
                serieEpisodes.Add(new SerieEpisode("MF8.png", "Dou You Know Yourself?", "What makes you, you?  If even the most basic parts of you, like your memories or your past, can be forgotten or manipulated, how can you know ever really know who “you” are?  In this episode of Mind Field I look at how well Do You Know Yourself?", 8, 1, "AtjeVoorDeSfeer.mp4"));

                foreach(SerieEpisode serie in serieEpisodes)
                {
                    MindField.AddEpisode(serie);
                    _dbContext.Mediafiles.Add(serie);
                }

                
                #endregion

                #endregion

                #region Serie Episode
                SerieEpisode episode1 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode1);
                    _dbContext.Mediafiles.Add(episode1);

                    SerieEpisode episode2 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode2);
                    _dbContext.Mediafiles.Add(episode2);

                    SerieEpisode episode3 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie2.AddEpisode((SerieEpisode)episode3);
                    _dbContext.Mediafiles.Add(episode3);

                    SerieEpisode episode4 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie2.AddEpisode((SerieEpisode)episode4);
                    _dbContext.Mediafiles.Add(episode4);

                    SerieEpisode episode5 = new SerieEpisode("movie.jfif", "episode1", "This is episode 1", 1, 1, "AtjeVoorDeSfeer.mp4");
                    serie3.AddEpisode((SerieEpisode)episode5);
                    _dbContext.Mediafiles.Add(episode5);

                    SerieEpisode episode6 = new SerieEpisode("movie.jfif", "episode2", "This is episode 2", 2, 1, "AtjeVoorDeSfeer.mp4");
                    serie1.AddEpisode((SerieEpisode)episode6);
                    _dbContext.Mediafiles.Add(episode6);

                    #endregion

                #region Music
                Music song1 = new Music("music.png", "Song1", "This is song1", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song1);

                Music song2 = new Music("music.png", "Song2", "This is song2", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song2);

                Music song3 = new Music("music.png", "Song1", "This is song1", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song3);

                Music song4 = new Music("music.png", "Song2", "This is song2", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song4);

                Music song5 = new Music("music.png", "Song1", "This is song1", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song5);

                Music song6 = new Music("music.png", "Song2", "This is song2", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song6);

                Music song7 = new Music("music.png", "Song1", "This is song1", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song7);

                Music song8 = new Music("music.png", "Song2", "This is song2", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song8);

                Music song9 = new Music("music.png", "Song1", "This is song1", MusicCategory.edm, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song9);


                Music song21 = new Music("music.png", "Song2", "This is song2", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song21);

                Music song32 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song32);

                Music song33 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song33);

                Music song34 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song34);

                Music song35 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song35);

                Music song36 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song36);

                Music song37 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song37);

                Music song38 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song38);

                Music song39 = new Music("music.png", "Song3", "This is song3", MusicCategory.pop, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song39);


                Music song311 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song311);

                Music song322 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song322);
                
                Music song333 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song333);

                Music song344 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song344);

                Music song355 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song355);

                Music song366 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song366);

                Music song377 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song377);

                Music song388 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song388);

                Music song399 = new Music("music.png", "Song3", "This is song3", MusicCategory.house, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song399);


                Music song3112 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song311);

                Music song3222 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song322);
                
                Music song3332 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song333);

                Music song3442 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song344);

                Music song3552 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song355);

                Music song3662 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song366);

                Music song3772 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song377);

                Music song3882 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song388);

                Music song3992 = new Music("music.png", "Song3", "This is song3", MusicCategory.rap, "PiewPiew.mp3");
                _dbContext.Mediafiles.Add(song399);
                #endregion

                #endregion

                #region Product
                Product product1 = new Product("Cola 33cl","link", 2.50,ProductCategory.Drinks, false);
                _dbContext.Products.Add(product1);
                Product product2 = new Product("Cola 50cl", "link", 3.50, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product2);
                Product product3 = new Product("Ice tea 33cl", "link", 2.50, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product3);
                Product product4 = new Product("Ice tea 50cl", "link", 3.50, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product4);
                Product product5 = new Product("fanta 33cl", "link", 2.50, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product5);
                Product product6 = new Product("ice tea 50cl", "link", 3.50, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product6);
                Product product7 = new Product("Water 50cl", "link", 3.00, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product7);
                Product product8 = new Product("Sparkling water 50cl", "link", 3.00, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product8);
                Product product9 = new Product("Sprite 33cl", "link", 3.00, ProductCategory.Drinks, false);
                _dbContext.Products.Add(product9);

                Product product11 = new Product("hamburger", "link", 5.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product11);
                Product product42 = new Product("Panini ", "link", 5.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product42);
                Product product43 = new Product("French Fries", "link", 4.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product43);
                Product product44 = new Product("Pizza margarita", "link", 7.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product44);
                Product product455 = new Product("Pizza hawai", "link", 7.00, ProductCategory.Food, false);
                _dbContext.Products.Add(product455);

                Product product57 = new Product("Horloge", "link", 50.00, ProductCategory.Gifts, false);
                _dbContext.Products.Add(product57);

                Product product58 = new Product("Pillow", "link", 20.00, ProductCategory.Gifts, false);
                _dbContext.Products.Add(product58);

                Product product59 = new Product("The Book Of Wisdom", "link", 32.00, ProductCategory.Gifts, false);
                _dbContext.Products.Add(product59);

                #endregion


                #region Order



                Passenger passenger1MetOrder = passenger1 as Passenger;
                _dbContext.Passengers.Add(passenger1MetOrder);
                Passenger passenger2MetOrder = passenger2 as Passenger;
                _dbContext.Passengers.Add(passenger2MetOrder);
                Order order1 = new Order(passenger1MetOrder, DateTime.MinValue);
                Order order2 = new Order(passenger1MetOrder, DateTime.MinValue);
                Order order3 = new Order(passenger2MetOrder, DateTime.MinValue);

                #region Orderline
                Orderline orderline1 = new Orderline(2, product1, order1);
                Orderline orderline2 = new Orderline(1, product2, order2);
                Orderline orderline3 = new Orderline(3, product3, order3);
                #endregion

                order1.AddOrderline(orderline1);
                order2.AddOrderline(orderline2);
                order3.AddOrderline(orderline3);
                _dbContext.Orders.Add(order1);
                _dbContext.Orders.Add(order2);
                _dbContext.Orders.Add(order3);
                #endregion

                #region Save changes
                _dbContext.SaveChanges();
                #endregion

            }


        }


        //private async Task CreateUser(string username, string password)
        //{
        //    var user = new IdentityUser { UserName = username};
        //    await _userManager.CreateAsync(user, password);
        //}
    }

}
