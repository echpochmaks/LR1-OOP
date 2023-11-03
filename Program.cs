using System.ComponentModel.Design;
using System.Globalization;

List<string> artists = new List<string>() { "Nirvana", "Miles Davis", "Arctic Monkeys" };
List<string> album = new List<string>() { "Nevermind", "In Utero", "Kind of Blue", "AM"};
List<string> style = new List<string>() { "Rock", "Jazz", "Indie"};
List<string> collections = new List<string>() { "Rock Classics", "Jazz Legends", "Indie Anthems" };

List<Tracks> MusicLibrary = new List<Tracks>()
{
    new Tracks("Lithium",               artists[0],album[0],style[0],collections[0]),
    new Tracks("Smells Like Teen Spirit",artists[0],album[0],style[0],collections[1]),
    new Tracks("Come as You Are",       artists[0],album[0],style[0],collections[2]),
    new Tracks("Heart-Shaped Box",      artists[0],album[1],style[0],collections[0]),
    new Tracks("All Apologies",         artists[0],album[1],style[0],collections[1]),
    new Tracks("Rape Me",               artists[0],album[1],style[0],collections[2]),
    new Tracks("So What",               artists[1],album[2],style[1],collections[0]),
    new Tracks("All Blues",             artists[1],album[2],style[1],collections[1]),
    new Tracks("Blue in Green",         artists[1],album[2],style[1],collections[2]),
    new Tracks("Arabella",              artists[2],album[3],style[2],collections[0]),
    new Tracks("Do I Wanna Know?",      artists[2],album[3],style[2],collections[1])
};
start:
int a = 0;
while (a != 1 && a != 2 && a != 3 && a != 4)
{
    Console.WriteLine("Что бы вы хотели найти?(Введите число)" +
    "\n 1. Музыку по жанру" +
    "\n 2. Песню по названию" +
    "\n 3. Исполнителя" +
    "\n 4. Альбом или сборник");
    a = Convert.ToInt32(Console.ReadLine());
}
string b = "";
while(b.Length == 0)
{
    Console.WriteLine("Введите поисковый запрос:");
    b = Console.ReadLine();
}

switch (a)
{
    case 1:
        int check = 0;
        for (int i = 0; i < MusicLibrary.Count(); i++)
        {
            if (MusicLibrary[i].Style.ToLower() == b.ToLower())
            {
                Tracks.Info(MusicLibrary[i]);
                check++;
            }             
        }
        if (check == 0) Console.WriteLine("\nПесни с введенным жанром отсутствуют");
        break;
    case 2:
        check = 0;
        for (int i = 0; i < MusicLibrary.Count(); i++)
        {
            if (MusicLibrary[i].TrackName.ToLower() == b.ToLower())
            {
                Tracks.Info(MusicLibrary[i]);
                check++;
                break;
            }
        }
        if (check == 0) Console.WriteLine("\nПесня не найдена");
        break;
    case 3:
        List<Tracks> SortedList = new List<Tracks>();
        int trk = 0;
        int albm = 0;
        string al = "";
        SortedList = MusicLibrary.OrderBy(u => u.Artist).ToList();
        for (int i = 0; i < SortedList.Count(); i++)
        {
            if (SortedList[i].Artist.ToLower() == b.ToLower())
            {
                trk++;
                if (al != SortedList[i].Artist)
                {
                    albm++;
                    al = SortedList[i].Artist;
                }
                
            }
        }
        if (trk == 0) { Console.WriteLine("\nВведенный исполнитель не найден"
            + "\n---------------------------------------------"); }
        else {
            Console.WriteLine("\nИсполнитель: " + MusicLibrary.First(u => u.Artist.ToLower() == b.ToLower()).Artist +
            "\nКоличество песен: " + trk +
            "\nКоличество альбомов: " + albm +
            "\n---------------------------------------------");
        }
            break;
    case 4:
        trk = 0;
        for (int i = 0; i < MusicLibrary.Count(); i++)
        {
            if (MusicLibrary[i].Album.ToLower() == b.ToLower() || MusicLibrary[i].Group.ToLower() == b.ToLower())
            {
                trk++;
            }
        }
        if (trk == 0) { Console.WriteLine("\nВведенный исполнитель не найден"
            + "\n---------------------------------------------"); }
        else
        {
            if (MusicLibrary.FirstOrDefault(u => u.Album.ToLower() == b.ToLower()) is not null)
            {
                Console.WriteLine("\nИсполнитель: " + MusicLibrary.First(u => u.Album.ToLower() == b.ToLower()).Artist +
                "\nНазвание альбома: " + MusicLibrary.First(u => u.Album.ToLower() == b.ToLower()).Album +
                "\nКоличество песен в альбоме: " + trk +
                "\n---------------------------------------------");
            }
            else
            {
                Console.WriteLine("\nНазвание сборника: " + MusicLibrary.First(u => u.Group.ToLower() == b.ToLower()).Group +
                "\nКоличество песен в сборнике: " + trk +
                "\n---------------------------------------------");
            }
        }
        break;
}
goto start;
public class Tracks
{
    public string TrackName { get; set; }
    public string Artist { get;set; }
    public string Album { get; set; }
    public string Style { get; set; }
    public string Group { get; set; }

    public Tracks(string name, string artist, string album, string style, string group) 
    
    { 
        this.TrackName = name;
        this.Artist = artist;   
        this.Album = album;
        this.Style = style;
        this.Group = group;
    }

    public static void Info(Tracks tracks)
    {
        Console.WriteLine("\n" + tracks.TrackName + "\n" + tracks.Artist + "\n" + tracks.Album + "\n" + tracks.Style +
               "\n---------------------------------------------");
    }
}