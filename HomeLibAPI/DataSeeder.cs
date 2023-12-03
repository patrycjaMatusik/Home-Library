using HomeLibAPI.Entities;
using HomeLibraryAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibraryAPI
{
    public class DataSeeder
    {
        private readonly HomeLibraryDbContext _dbContext;

        public DataSeeder(HomeLibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Books.Any())
                {
                    var books = GetBooks();
                    _dbContext.Books.AddRange(books);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Magazines.Any())
                {
                    var magazines = GetMagazines();
                    _dbContext.Magazines.AddRange(magazines);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Multimedias.Any())
                {
                    var multimedias = GetMultimedias();
                    _dbContext.Multimedias.AddRange(multimedias);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                Name = "Guest"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }

        private IEnumerable<Book> GetBooks()
        {
            var books = new List<Book>()
            {
                new Book()
                {
                    Author = new Author()
                    {
                        Name = "Adam",
                        Surname = "Mickiewicz"
                    },
                    Title = "Pan Tadeusz",
                    Description = "Pan Tadeusz (a dokładnie Pan Tadeusz, czyli ostatni zajazd na Litwie. Historia szlachecka z r. 1811 i 1812, we dwunastu księgach wierszem), to epicki poemat trzynastozgłoskowy, napisany przez Adama Mickiewicza w Paryżu, w latach 1832-1834. Epos rozgrywa się w ciągu kilku dni roku 1811 i 1812 na Litwie i opowiada o wydarzeniach następujących po powrocie do domu młodego szlachcica - Tadeusza Soplicy - oraz o dziejach jego ojca, Jacka Soplicy, który w gniewie dokonał strasznej zbrodni i wstąpił do zakonu chcąc zmazać swoje winy. W Soplicowie odbywają się polowania i uczty, flirty i spory, dyskusje i agitacje, krążą wspomnienia, rodzą się uczucia, wybuchają konflikty i w końcu dochodzi do pojednania. A wszystko to dzieje się w otoczeniu pięknej przyrody, wśród tradycji i zwyczajów polskiej wsi.",
                    Keywords = new List<Keyword>
                    {
                        new Keyword() { Name = "lektura"},
                        new Keyword() { Name = "epopeja"},
                        new Keyword() { Name = "XIX w."}
                    },
                    Publisher = new Publisher()
                    {
                        Name = "G&P"
                    },
                    NumberOfPages = 373,
                    ISBN = "9788372723703",
                    TableOfContents = "KSIĘGA PIERWSZA: GOSPODARSTWO; KSIĘGA DRUGA: ZAMEK; KSIĘGA TRZECIA: UMIZGI; KSIĘGA CZWARTA: DYPLOMATYKA I ŁOWY; KSIĘGA PIĄTA: KŁÓTNIA; KSIĘGA SZÓSTA: ZAŚCIANEK; KSIĘGA SIÓDMA: RADA; KSIĘGA ÓSMA: ZAJAZD; KSIĘGA DZIEWIĄTA: BITWA; KSIĘGA DZIESIĄTA: EMIGRACJA.JACEK; KSIĘGA JEDENASTA: ROK 1812; KSIĘGA DWUNASTA: KOCHAJMY SIĘ; OBJAŚNIENIA POETY; EPILOG"
                },
                new Book()
                {
                    Author = new Author()
                    {
                        Name = "Juliusz",
                        Surname = "Słowacki"
                    },
                    Title = "Kordian",
                    Description = "Polska pod jarzmem cara - zbrodniarza. Patrioci planują na niego zamach. Jeden z nich, tajemniczy młodzieniec w masce, podejmuje się zabić znienawidzonego tyrana. Wpisuje się tym samym w krąg działań, które zaplanował szatan u progu kolejnego stulecia. Czy mu się powiedzie? Czy ma na tyle odwagi, by działać na rzecz własnego, zniewolonego i upokorzonego narodu? A może Kordian, bo o nim tu mowa, jest zbyt słaby?",
                    Keywords = new List<Keyword>
                    {
                        new Keyword() { Name = "lektura"},
                        new Keyword() { Name = "XIX w."},
                        new Keyword() { Name = ""}
                    },
                    Publisher = new Publisher()
                    {
                        Name = "GREG"
                    },
                    NumberOfPages = 127,
                    ISBN = "9788373271678",
                    TableOfContents = "Motto;  Przygotowanie; Prolog; Akt I; Akt II; Akt III"
                }
            };
            return books;
        }

        private IEnumerable<Magazine> GetMagazines()
        {
            var magazines = new List<Magazine>()
            {
                new Magazine()
                {
                   Author = new Author()
                    {
                        Name = "Bożena",
                        Surname = "Urbanek"
                    },
                   Title = "Medycyna Nowożytna",
                   Description = "Pismo istniejące od 1992/1994 r. poświęcone jest zagadnieniom związanym nie tylko z historią nauk medycznych ale też z szeroko pojętym pojęciem kultury medycznej.",
                   Keywords = new List<Keyword>
                    {
                        new Keyword() { Name = "medycyna"},
                        new Keyword() { Name = "historia"},
                        new Keyword() { Name = "kultura"}
                    },
                   Publisher = new Publisher()
                    {
                        Name = "Instytut Historii Nauki im. L. i A. Birkenmajerów Polskiej Akademii Nauk"
                    },
                    NumberOfPages = 90,
                    ISBN = "9788373271123",
                    TableOfContents = "1. Studia;  2. Prace analityczne; 3. Anachronica; 4. Z archiwów i bibliotek; 5. Recenzje i omówienia; 6. Kronika życia naukowego"

                }
            };
            return magazines;
        }

        private IEnumerable<Multimedia> GetMultimedias()
        {
            var multimedias = new List<Multimedia>()
            {
                new Multimedia()
                {
                    Author = new Author()
                    {
                        Name = "Adele",
                        Surname = "Adkins"
                    },
                    Title = "30",
                    Description = "The fourth studio album by English singer-songwriter Adele, released on 19 November 2021",
                    Keywords = new List<Keyword>
                    {
                        new Keyword() { Name = "melancholia"},
                        new Keyword() { Name = "spokój"},
                        new Keyword() { Name = "melodyjność"}
                    },
                    Publisher = new Publisher()
                    {
                        Name = "Sony Music Entertainment"
                    },
                    Duration = new System.TimeSpan(0, 58, 18),
                    RecordsList = "1. Strangers By Nature; 2. Easy On Me; 3. My Little Love; 4. Cry Your Heart Out; 5. Oh My God; 6. Can I Get It; 7. Drink Wine; 8. All Night Parking (with Erroll Garner) Interlude; 9. Woman Like Me; 10. Hold On; 11. To Be Loved; 12. Love Is A Game"
                }
            };
            return multimedias;
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>
            {
                new User()
                {
                    Email = "testAdmin@test.com",
                    FirstName = "Adam",
                    LastName = "Kowalski",
                    PasswordHash = "AQAAAAEAACcQAAAAEFRLThXW0P77npqOXYf6uc1ayXuN0GcHNW67jHVNPFRwd5A1Ni0yySoGKOkdiwDvGw==",
                    RoleId = 3
                }
            };
            return users;
        }
    }
}
