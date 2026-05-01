using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // 1. IDs Hardcoded (Nunca cambian, lo que hace que la migración sea estable)
        var userId = Guid.Parse("f2a3b4c5-d6e7-48a9-b0c1-d2e3f4a5b6c7");
        var cinemaId = Guid.Parse("a1b2c3d4-e5f6-47a8-b9c0-d1e2f3a4b5c6");
        var roomId = Guid.Parse("b2c3d4e5-f6a7-48b9-c0d1-e2f3a4b5c6d7");
        var movieId = Guid.Parse("c3d4e5f6-a7b8-49c0-d1e2-f3a4b5c6d7e8");
        var screeningId = Guid.Parse("d4e5f6a7-b8c9-40d1-e2f3-a4b5c6d7e8f9");
        var bookingId = Guid.Parse("e5f6a7b8-c9d0-41e1-f2a3-b4c5d6e7f8a9");
        var seatId = Guid.Parse("f6a7b8c9-d0e1-42f2-a3b4-c5d6e7f8a9b0");

        // Fecha base estática para el seed
        var seedDate = new DateTime(2026, 3, 25, 12, 0, 0, DateTimeKind.Utc);

        // 2. Seed de Cine
        modelBuilder.Entity<Cinema>().HasData(new Cinema
        {
            Id = cinemaId,
            Address = "Av. Arístides Villanueva 123, Mendoza",
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 3. Seed de Sala (Usando Cinema_ID para coincidir con tu configuración)
        modelBuilder.Entity<Room>().HasData(new Room
        {
            Id = roomId,
            Room_Number = 1,
            Capacity = 50,
            CinemaId = cinemaId, // <--- Cambiado a Cinema_ID
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 4. Seed de Película
        modelBuilder.Entity<Movie>().HasData(new Movie
        {
            Id = movieId,
            Title = "Interstellar",
            Duration = new TimeSpan(2, 49, 0),
            Genre = "Sci-Fi",
            Classification = "PG-13",
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 5. Seed de Función (Usando los campos _ID correctos)
        modelBuilder.Entity<Screening>().HasData(new Screening
        {
            Id = screeningId,
            MovieId = movieId, // <--- Cambiado a Movie_ID
            RoomId = roomId,   // <--- Cambiado a Room_ID
            StartDate = seedDate.AddDays(1),
            EndDate = seedDate.AddDays(1).AddHours(3),
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 6. Seed de Usuario
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = userId,
            First_Name = "Ignacio",
            Last_Name = "Dev",
            Phone = "2615551234",
            Address = "Mendoza, Argentina",
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 7. Seed de Reserva (Usando los campos _ID correctos)
        modelBuilder.Entity<Booking>().HasData(new Booking
        {
            Id = bookingId,
            UserId = userId,           // <--- Cambiado a User_ID
            ScreeningId = screeningId, // <--- Cambiado a Screening_ID
            Date = seedDate.AddDays(1),
            Total = 4500.50m,
            PaymentMethod = PaymentMethod.Transfer,
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });

        // 8. Seed de Asiento
        modelBuilder.Entity<Seat>().HasData(new Seat
        {
            Id = seatId,
            RoomId = roomId, // <--- Cambiado a Room_ID
            Row = "A",
            Column = 5,
            State = State.Active,
            Created = seedDate,
            CreatedBy = "SeedUser",
            Modified = seedDate,
            ModifiedBy = "SeedUser"
        });
    }
}
