using DBDrive;

//using (ApplicationContext db = new ApplicationContext())
//
    // создаем два объекта User
    // User tom = new User { Name = "Tom", Age = 33 };
    //User alice = new User { Name = "Alice", Age = 26 };
    //    User dima = new User { Name = "Дима", Age = 54 };
    //    User olga = new User { Name = "Ольга", Age = 45 };

    // добавляем их в бд
    //    db.Users.Add(dima);
    //    db.Users.Add(olga);
    //    db.SaveChanges();
    //Console.WriteLine("Объекты успешно сохранены");
    // ============================================================
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder();
// установка пути к текущему каталогу
builder.SetBasePath(Directory.GetCurrentDirectory());
// получаем конфигурацию из файла appsettings.json
builder.AddJsonFile("appsettings.json");
// создаем конфигурацию
var config = builder.Build();
// получаем строку подключения
string connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseSqlite(connectionString).Options;

using (ApplicationContext db = new ApplicationContext(options))
{

    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }

    bool isCreated = db.Database.EnsureCreated();
    //bool isCreated2 = await db.Database.EnsureCreatedAsync();
    if (isCreated) Console.WriteLine("База данных была создана");
    else Console.WriteLine("База данных уже существует");

    Console.WriteLine($"{isCreated} база данных");

    users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
    // асинхронная версия
    await db.Database.EnsureCreatedAsync();
    
    bool isAvalaible = db.Database.CanConnect();
    // bool isAvalaible2 = await db.Database.CanConnectAsync();
    if (isAvalaible) Console.WriteLine("База данных доступна");
    else Console.WriteLine("База данных не доступна");

    // получаем первый объект
    User? user = db.Users.FirstOrDefault();
    if (user != null)
    {
        user.Name = "Bob";
        user.Age = 44;
        //обновляем объект
        //db.Users.Update(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после редактирования:");
    
    users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }

    // получаем первый объект
    user = db.Users.FirstOrDefault();
    if (user != null)
    {
        //удаляем объект
        db.Users.Remove(user);
        db.SaveChanges();
    }
    // выводим данные после обновления
    Console.WriteLine("\nДанные после удаления:");
    users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}